using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculatorWeb.Areas.Admin.Models.Base;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class UsersViewModel : IBaseViewModel, IMapFrom<User> 
    {
        public virtual string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string CompanyAddress { get; set; }
    }
}