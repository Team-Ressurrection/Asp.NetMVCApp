using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.ContractViewModels
{
    public class CreateEmployeePaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        [Required(ErrorMessage ="Date field is required")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:dd/MM/yyyy}")]
        [DefaultValue(typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage ="Gross Salary is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinimumSalaryValue,Double.MaxValue)]
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