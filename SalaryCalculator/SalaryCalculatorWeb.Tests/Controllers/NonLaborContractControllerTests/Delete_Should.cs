using System.Web.Mvc;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.ContractViewModels;

namespace SalaryCalculatorWeb.Tests.Controllers.NonLaborContractControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnRedirectToRouteResult_WhenPassedIdIsCorrect()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();

            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            var result = nonLaborController.DeleteConfirmed(id, nonLaborContractModel.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            RemunerationBill nonLaborContractModel = new FakeRemunerationBill()
            {
                Id = id,
                GrossSalary = 1000,
                SocialSecurityIncome = 1110,
                PersonalInsurance = 50,
            };
            billService.Setup(x => x.GetById(id)).Returns(nonLaborContractModel).Verifiable();

            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<ViewResult>(nonLaborController.Delete(id,nonLaborContractModel));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            RemunerationBill nonLaborContractModel = null;

            billService.Setup(x => x.GetById(id)).Returns(nonLaborContractModel).Verifiable();
            
            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(nonLaborController.Delete(id,nonLaborContractModel));
        }
    }
}
