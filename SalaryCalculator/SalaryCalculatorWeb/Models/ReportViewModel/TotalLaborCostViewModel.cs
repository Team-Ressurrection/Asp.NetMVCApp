using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.ReportViewModel
{
    public class TotalLaborCostViewModel
    {
        public decimal TotalIncomeTaxes { get; set; }

        public decimal TotalSocialSecurityIncome { get; set; }

        public decimal TotalEmployerInsuranceTaxes { get; set; }
    }
}