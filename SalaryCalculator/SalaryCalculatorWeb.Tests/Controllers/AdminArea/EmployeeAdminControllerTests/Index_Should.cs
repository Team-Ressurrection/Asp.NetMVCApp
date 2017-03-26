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

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.EmployeeAdminControllerTests
{
    [TestFixture]
   public class Index_Should
    {
        [Test]
        public void ReturnIEnumerableOfEmployeesViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            var model = new Mock<EmployeesViewModel>();
            var pageModel = new Mock<PageViewModel<EmployeesViewModel>>();
            var employee = new FakeEmployee() { Id = 15 };
            model.SetupProperty(x => x.Id, 15);
            IEnumerable<Employee> collectionUsers = new List<Employee>() { employee };
            IEnumerable<EmployeesViewModel> collectionModelUsers = new List<EmployeesViewModel>() { model.Object };

            mockedEmployeeService.Setup(x => x.GetAll()).Returns(collectionUsers.AsQueryable()).Verifiable();
            mockedMapService.Setup(x => x.Map<IEnumerable<EmployeesViewModel>>(collectionUsers)).Returns(collectionModelUsers).Verifiable();
            mockedPagerFactory.Setup(x => x.CreatePager(1, null, 10)).Returns(new Pager(1, null, 10)).Verifiable();
            pageModel.SetupProperty(x => x.Items, collectionModelUsers);
            pageModel.SetupProperty(x => x.Pager, new Pager(collectionModelUsers.Count(),null));
            // Act
            EmployeeAdminController userController = new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, mockedEmployeeService.Object);

            var result = userController.Index(null, pageModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(pageModel.Object, result.Model);
        }
    }
}
