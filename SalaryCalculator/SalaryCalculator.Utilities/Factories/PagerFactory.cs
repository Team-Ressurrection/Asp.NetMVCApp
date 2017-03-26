using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Utilities.Factories
{
   public interface IPagerFactory
    {
        Pager CreatePager(int totalItems, int? page, int pageSize = ValidationConstants.DefaultPageItems);
    }
}
