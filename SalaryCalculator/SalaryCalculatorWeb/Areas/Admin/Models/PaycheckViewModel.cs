﻿using System;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class PaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        public virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

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