using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.ReportViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.ReportsControllerTests
{
    [TestFixture]
    public class LaborCost_Should
    {
        [Test]
        public void ReturnTotalLaborCostViewModel_WhenActionResultIsCalled()
        {
            // Arrange
            var mockedPaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedBillService = new Mock<IRemunerationBillService>();

            var totalCostModel = new Mock<TotalLaborCostViewModel>();
            totalCostModel.SetupProperty(x => x.TotalEmployerInsuranceTaxes, 1000m);
            totalCostModel.SetupProperty(x => x.TotalIncomeTaxes, 1000m);
            totalCostModel.SetupProperty(x => x.TotalSocialSecurityIncome, 500m);

            // Act
            var reportController = new ReportsController(mockedPaycheckService.Object, mockedBillService.Object);
            var result = reportController.LaborCost(totalCostModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<TotalLaborCostViewModel>(result.Model);
        }
    }
}
