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

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.PaycheckControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnIEnumerableOfPaychecksViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedPaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            var model = new Mock<PaycheckViewModel>();
            var pageModel = new Mock<PageViewModel<PaycheckViewModel>>();
            EmployeePaycheck paycheck = new EmployeePaycheck();
            model.SetupProperty(x => x.Id, 15);
            IEnumerable<EmployeePaycheck> collectionPaychecks = new List<EmployeePaycheck>() { paycheck };
            IEnumerable<PaycheckViewModel> collectionModelUsers = new List<PaycheckViewModel>() { model.Object };

            mockedPaycheckService.Setup(x => x.GetAll()).Returns(collectionPaychecks.AsQueryable()).Verifiable();
            mockedMapService.Setup(x => x.Map<IEnumerable<PaycheckViewModel>>(collectionPaychecks)).Returns(collectionModelUsers).Verifiable();
            mockedPagerFactory.Setup(x => x.CreatePager(1, null, 10)).Returns(new Pager(1, null, 10)).Verifiable();
            pageModel.SetupProperty(x => x.Items, collectionModelUsers);
            pageModel.SetupProperty(x => x.Pager, new Pager(collectionModelUsers.Count(), null));

            // Act
            PaychecksController paycheckController = new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, mockedPaycheckService.Object);

            var result = paycheckController.Index(null, pageModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(pageModel.Object, result.Model);
        }
    }
}
