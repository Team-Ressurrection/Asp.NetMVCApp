using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.ReportViewModel
{
    public class TotalLaborCostViewModel
    {
        public virtual decimal TotalIncomeTaxes { get; set; }

        public virtual decimal TotalSocialSecurityIncome { get; set; }

        public virtual decimal TotalEmployerInsuranceTaxes { get; set; }
    }
}