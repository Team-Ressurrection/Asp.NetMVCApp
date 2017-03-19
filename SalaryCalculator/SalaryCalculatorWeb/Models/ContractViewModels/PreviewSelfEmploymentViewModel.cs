using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.ContractViewModels
{
    public class PreviewSelfEmploymentViewModel : IMapFrom<SelfEmployment>
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public virtual decimal GrossSalary { get; set; }

        public virtual decimal SocialSecurityIncome { get; set; }

        public decimal PersonalInsurance { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal NetWage { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }
    }
}