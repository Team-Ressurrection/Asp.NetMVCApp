using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.SettingsViewModels
{
    public class EmployeeViewModel : IMapFrom<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }

        public IEnumerable<EmployeePaycheck> EmployeePaychecks { get; set; }

        public IEnumerable<RemunerationBill> RemunerationBills { get; set; }

        public IEnumerable<SelfEmployment> SelfEmployments { get; set; }
    }
}