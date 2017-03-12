using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Models.HomeViewModels
{
    public class InfoViewModel
    {
        public virtual int TotalRegisteredUsers { get; set; }
               
        public virtual int TotalPaychecks { get; set; }
               
        public virtual int TotalRemunerationBills { get; set; }
              
        public virtual int TotalSelfEmployments { get; set; }
    }
}