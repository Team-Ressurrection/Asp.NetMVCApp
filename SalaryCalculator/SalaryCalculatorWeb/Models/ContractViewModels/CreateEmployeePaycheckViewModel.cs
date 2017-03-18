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
    public class CreateEmployeePaycheckViewModel : IMapFrom<EmployeePaycheck>
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal GrossFixedBonus { get; set; }

        public decimal GrossNonFixedBonus { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}