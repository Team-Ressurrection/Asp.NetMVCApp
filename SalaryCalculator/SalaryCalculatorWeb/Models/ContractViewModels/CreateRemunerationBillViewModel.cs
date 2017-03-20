using System;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculatorWeb.Models.ContractViewModels
{
    public class CreateRemunerationBillViewModel : IMapFrom<RemunerationBill>
    {
        [Required(ErrorMessage = "Date field is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DefaultValue(typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Gross Salary is required and must be greater than zero.")]
        [Range((double)ValidationConstants.MinimumSalaryValue, 1000000)]
        public virtual decimal GrossSalary { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}