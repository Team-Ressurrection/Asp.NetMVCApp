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
            var totalSocialSecurityIncomes =  this.paycheckService.GetAll().Sum(x => x.SocialSecurityIncome);
            var totalEmployerSSI = totalSocialSecurityIncomes * ValidationConstants.EmployerInsurancePercent;
            var totalTaxIncomes = this.paycheckService.GetAll().Sum(x => x.IncomeTax);
            costViewModel.TotalIncomeTaxes = totalTaxIncomes;
            costViewModel.TotalSocialSecurityIncome = totalSocialSecurityIncomes;
            costViewModel.TotalEmployerInsuranceTaxes = totalEmployerSSI;
            return View(costViewModel);
        }
    }
}