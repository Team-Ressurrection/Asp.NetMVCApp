using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.HomeViewModels
{
    public class InfoViewModel
    {
        public int TotalRegisteredUsers { get; set; }

        public int TotalPaychecks { get; set; }

        public int TotalRemunerationBills { get; set; }

        public int TotalSelfEmployments { get; set; }
    }
}