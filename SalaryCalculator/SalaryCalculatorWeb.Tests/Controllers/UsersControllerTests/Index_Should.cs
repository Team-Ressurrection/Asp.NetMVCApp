using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculator.Utilities.Pagination;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
   public class Index_Should
    {
        [Test]
        public void ReturnIEnumerableOfUsersViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            var model = new Mock<UsersViewModel>();
            var pageModel = new Mock<PageViewModel<UsersViewModel>>();
            var user = new FakeUser() { UserName = "Payroll" };
            model.SetupProperty(x => x.UserName, "Payroll");
            IEnumerable<User> collectionUsers = new List<User>() { user };
            IEnumerable<UsersViewModel> collectionModelUsers = new List<UsersViewModel>() { model.Object };

            mockedUserService.Setup(x => x.GetAll()).Returns(collectionUsers.AsQueryable()).Verifiable();
            mockedMapService.Setup(x => x.Map<IEnumerable<UsersViewModel>>(collectionUsers)).Returns(collectionModelUsers).Verifiable();
            mockedPagerFactory.Setup(x => x.CreatePager(1, null, 10)).Returns(new Pager(1, null, 10)).Verifiable();
            pageModel.SetupProperty(x => x.Items, collectionModelUsers);
            pageModel.SetupProperty(x => x.Pager, new Pager(collectionModelUsers.Count(),null));
            // Act
            UsersController userController = new UsersController(mockedMapService.Object, mockedUserService.Object, mockedPagerFactory.Object);
            var result = userController.Index(null, pageModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(pageModel.Object, result.Model);
        }
    }
}
