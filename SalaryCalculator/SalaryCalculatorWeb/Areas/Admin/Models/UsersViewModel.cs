using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class UsersViewModel : IMapFrom<User>
    {
        public virtual string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string CompanyAddress { get; set; }
    }
}