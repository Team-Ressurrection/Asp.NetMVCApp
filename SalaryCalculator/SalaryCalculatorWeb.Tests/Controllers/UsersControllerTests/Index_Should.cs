using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
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

            var model = new Mock<UsersViewModel>();
            var user = new FakeUser() { UserName = "Payroll"};
            model.SetupProperty(x => x.UserName, "Payroll");
            IEnumerable<User> collectionUsers = new List<User>() { user};
            IEnumerable<UsersViewModel> collectionModelUsers = new List<UsersViewModel>() { model.Object};

            mockedUserService.Setup(x => x.GetAll()).Returns(collectionUsers.AsQueryable()).Verifiable();
            mockedMapService.Setup(x => x.Map<IEnumerable<UsersViewModel>>(collectionUsers)).Returns(collectionModelUsers).Verifiable();

            // Act
            var usersController = new UsersController(mockedMapService.Object, mockedUserService.Object);
            var result = usersController.Index(collectionModelUsers) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(collectionModelUsers, result.Model);
        }
    }
}
