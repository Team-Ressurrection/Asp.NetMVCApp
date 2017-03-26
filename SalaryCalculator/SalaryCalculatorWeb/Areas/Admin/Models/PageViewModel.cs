using System.Collections.Generic;

using SalaryCalculator.Utilities.Pagination;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class PageViewModel
    {
        public virtual IEnumerable<UsersViewModel> Items { get; set; }

        public virtual Pager Pager { get; set; }
    }
}