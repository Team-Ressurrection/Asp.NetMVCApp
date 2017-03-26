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
    public class PreviewRemunerationBillViewModel : IMapFrom<RemunerationBill>
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Gross Salary is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinimumSalaryValue, (double)ValidationConstants.MaximumSalaryValue)]
        public virtual decimal GrossSalary { get; set; }

        //[Required(ErrorMessage = "Social Security Income is required and must be greater than zero.")]
        //[Range((double)ValidationConstants.MinSocialSecurityIncome, (double)ValidationConstants.MaxSocialSecurityIncome)]
        public decimal SocialSecurityIncome { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal PersonalInsurance { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal IncomeTax { get; set; }

        [Range(0, (double)ValidationConstants.MaximumSalaryValue, ErrorMessage = "The field must be between {1} and {2}.")]
        public decimal NetWage { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }

        public decimal LawGrantedCosts { get; set; }

        public decimal TaxableAmount { get; set; }

        public decimal AdvanceTaxAmount { get; set; }
    }
}