using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class PaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual decimal GrossSalary { get; set; }

        public virtual decimal GrossFixedBonus { get; set; }

        public virtual decimal GrossNonFixedBonus { get; set; }

        public virtual decimal SocialSecurityIncome { get; set; }

        public virtual decimal PersonalInsurance { get; set; }

        public virtual decimal IncomeTax { get; set; }

        public virtual decimal NetWage { get; set; }

        public virtual int EmployeeId { get; set; }
    }
}