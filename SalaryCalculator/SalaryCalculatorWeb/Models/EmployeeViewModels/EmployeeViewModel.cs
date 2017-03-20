using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.EmployeeViewModels
{
    public class EmployeeViewModel : IMapFrom<Employee>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(ValidationConstants.MaximumNameLength, MinimumLength = ValidationConstants.MinimumNameLength, ErrorMessage = "Name must be between {2} and {1} character in length.")]
        [RegularExpression(ValidationConstants.AllowedNameCharacters)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(ValidationConstants.MaximumNameLength, MinimumLength = ValidationConstants.MinimumNameLength, ErrorMessage = "Name must be between {2} and {1} character in length.")]
        [RegularExpression(ValidationConstants.AllowedNameCharacters)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(ValidationConstants.MaximumNameLength, MinimumLength = ValidationConstants.MinimumNameLength, ErrorMessage = "Name must be between {2} and {1} character in length.")]
        [RegularExpression(ValidationConstants.AllowedNameCharacters)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(ValidationConstants.PersonalIdLength, MinimumLength = ValidationConstants.PersonalIdLength, ErrorMessage = "Personal Id must be exactly {1} symbols long")]
        [RegularExpression(ValidationConstants.PersonalIdCharacters)]
        public string PersonalId { get; set; }

        public IEnumerable<EmployeePaycheck> EmployeePaychecks { get; set; }

        public IEnumerable<RemunerationBill> RemunerationBills { get; set; }

        public IEnumerable<SelfEmployment> SelfEmployments { get; set; }
    }
}