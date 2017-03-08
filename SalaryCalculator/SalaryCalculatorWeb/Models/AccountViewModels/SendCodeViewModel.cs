using System.Collections.Generic;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Models.AccountViewModels
{
    public class SendCodeViewModel
    {
        public virtual string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}