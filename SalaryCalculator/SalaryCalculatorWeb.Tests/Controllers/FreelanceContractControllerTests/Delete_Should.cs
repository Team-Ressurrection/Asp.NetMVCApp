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

namespace SalaryCalculatorWeb.Tests.Controllers.FreelanceContractControllerTests
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
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();

            // Act
            var freelanceController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            var result = freelanceController.DeleteConfirmed(id, freelanceContractModel.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            SelfEmployment freelanceContractModel = new FakeSelfEmployment()
            {
                Id = id,
                GrossSalary = 1000,
                SocialSecurityIncome = 1110,
                PersonalInsurance = 50,
            };
            selfEmploymentService.Setup(x => x.GetById(id)).Returns(freelanceContractModel).Verifiable();

            // Act
            var freelanceController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<ViewResult>(freelanceController.Delete(id,freelanceContractModel));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            SelfEmployment freelanceContractModel = null;

            selfEmploymentService.Setup(x => x.GetById(id)).Returns(freelanceContractModel).Verifiable();
            
            // Act
            var freelanceController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(freelanceController.Delete(id,freelanceContractModel));
        }
    }
}
