using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class UsersViewModel : IMapFrom<User>
    {
        public IEnumerable<User> Users { get; set; }
    }
}