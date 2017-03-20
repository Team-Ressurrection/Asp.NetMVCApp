using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.ContractViewModels
{
    public class PreviewEmployeePaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Gross Salary is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinimumSalaryValue, (double)ValidationConstants.MaximumSalaryValue)]
        public virtual decimal GrossSalary { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {0} and {1}.")]
        public virtual decimal GrossFixedBonus { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {0} and {1}.")]
        public virtual decimal GrossNonFixedBonus { get; set; }

        [Required(ErrorMessage = "Social Security Income is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinSocialSecurityIncome, (double)ValidationConstants.MaxSocialSecurityIncome)]
        public decimal SocialSecurityIncome { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal PersonalInsurance { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal IncomeTax { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal NetWage { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }
    }
}