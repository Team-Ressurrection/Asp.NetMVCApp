using System.Collections.Generic;

using SalaryCalculator.Utilities.Pagination;
using SalaryCalculatorWeb.Areas.Admin.Models.Base;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class PageViewModel<T> where T : class
    {
        public virtual IEnumerable<T> Items { get; set; }

        public virtual Pager Pager { get; set; }
    }
}