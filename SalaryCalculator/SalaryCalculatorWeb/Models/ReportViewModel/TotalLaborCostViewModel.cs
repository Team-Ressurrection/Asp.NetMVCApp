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

        public virtual decimal TotalLaborIncomeTaxes { get; set; }

        public virtual decimal TotalLaborSocialSecurityIncome { get; set; }

        public virtual decimal TotalLaborEmployerInsuranceTaxes { get; set; }

        public virtual decimal TotalNonLaborIncomeTaxes { get; set; }

        public virtual decimal TotalNonLaborSocialSecurityIncome { get; set; }

        public virtual decimal TotalNonLaborEmployerInsuranceTaxes { get; set; }
    }
}