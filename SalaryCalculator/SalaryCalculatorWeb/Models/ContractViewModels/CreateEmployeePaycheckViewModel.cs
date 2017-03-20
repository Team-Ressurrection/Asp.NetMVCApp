using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculatorWeb.Models.ContractViewModels
{
    public class CreateEmployeePaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        [Required(ErrorMessage ="Date field is required")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:MM/dd/yyyy}")]
        [DefaultValue(typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage ="Gross Salary is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinimumSalaryValue,1000000)]
        public decimal GrossSalary { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "The field must be between {0} and {1}.")]
        public decimal GrossFixedBonus { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "The field must be between {0} and {1}.")]
        public decimal GrossNonFixedBonus { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}