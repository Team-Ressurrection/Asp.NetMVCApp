using Bytes2you.Validation;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculatorWeb.Models.ReportViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Controllers
{
    public class ReportsController : Controller
    {
        private IEmployeePaycheckService paycheckService; 
        private IRemunerationBillService billService;

        public ReportsController(IEmployeePaycheckService paycheckService, IRemunerationBillService billService)
        {
            Guard.WhenArgument(paycheckService, "paycheckService").IsNull().Throw();
            Guard.WhenArgument(billService, "billService").IsNull().Throw();

            this.paycheckService = paycheckService;
            this.billService = billService;
        }

        // GET: Reports
        [HttpGet]
        public ActionResult LaborCost(TotalLaborCostViewModel costViewModel)
        {
            var totalLaborSocialSecurityIncomes =  this.paycheckService.GetAll().Sum(x => x.SocialSecurityIncome);
            var totalLaborEmployerSSI = totalLaborSocialSecurityIncomes * ValidationConstants.EmployerInsurancePercent;
            var totalLaborTaxIncomes = this.paycheckService.GetAll().Sum(x => x.IncomeTax);

            var totalNonLaborSocialSecurityIncomes = this.billService.GetAll().Sum(x => x.SocialSecurityIncome);
            var totalNonLaborEmployerSSI = totalNonLaborSocialSecurityIncomes * ValidationConstants.EmployerInsurancePercent;
            var totalNonLaborTaxIncomes = this.billService.GetAll().Sum(x => x.IncomeTax);

            costViewModel.TotalLaborIncomeTaxes = totalLaborTaxIncomes;
            costViewModel.TotalLaborSocialSecurityIncome = totalLaborSocialSecurityIncomes;
            costViewModel.TotalLaborEmployerInsuranceTaxes = totalLaborEmployerSSI;

            costViewModel.TotalNonLaborIncomeTaxes = totalNonLaborTaxIncomes;
            costViewModel.TotalNonLaborSocialSecurityIncome = totalNonLaborSocialSecurityIncomes;
            costViewModel.TotalNonLaborEmployerInsuranceTaxes = totalNonLaborEmployerSSI;

            costViewModel.TotalIncomeTaxes = totalLaborTaxIncomes + totalNonLaborTaxIncomes;
            costViewModel.TotalSocialSecurityIncome = totalLaborSocialSecurityIncomes + totalNonLaborSocialSecurityIncomes;
            costViewModel.TotalEmployerInsuranceTaxes = totalLaborEmployerSSI + totalNonLaborEmployerSSI;

            return View(costViewModel);
        }
    }
}