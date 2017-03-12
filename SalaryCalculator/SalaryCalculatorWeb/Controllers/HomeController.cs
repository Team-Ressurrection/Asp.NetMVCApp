using Bytes2you.Validation;
using SalaryCalculator.Configuration.Caching;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheService cacheService;
        private readonly IUserService userService;
        private readonly IEmployeePaycheckService paycheckService;
        private readonly IRemunerationBillService billService;
        private readonly ISelfEmploymentService selfEmploymentService;

        public HomeController(ICacheService cacheService, IUserService userService, IEmployeePaycheckService paycheckService, IRemunerationBillService billService, ISelfEmploymentService selfEmploymentService)
        {                                                                           
            Guard.WhenArgument(cacheService, "cacheService").IsNull().Throw();      
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(paycheckService, "paycheckService").IsNull().Throw();
            Guard.WhenArgument(billService, "billService").IsNull().Throw();
            Guard.WhenArgument(selfEmploymentService, "selfEmploymentService").IsNull().Throw();

            this.cacheService = cacheService;
            this.userService = userService;
            this.paycheckService = paycheckService;
            this.billService = billService;
            this.selfEmploymentService = selfEmploymentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Information(InfoViewModel infoViewModel)
        {
            var registeredUsers = this.cacheService.Get("totalRegisteredUsers", () => this.userService.GetAll().Count(), 60);
            var totalPaychecks = this.cacheService.Get("totalPaychecks", () => this.paycheckService.GetAll().Count(), 60);
            var totalRemunerationBills = this.cacheService.Get("totalRemunerationBills", () => this.billService.GetAll().Count(), 60);
            var totalSelfEmployments = this.cacheService.Get("totalSelfEmployments", () => this.paycheckService.GetAll().Count(), 60);

            infoViewModel.TotalRegisteredUsers = registeredUsers;
            infoViewModel.TotalPaychecks = totalPaychecks;
            infoViewModel.TotalRemunerationBills = totalRemunerationBills;
            infoViewModel.TotalSelfEmployments = totalSelfEmployments;

            return this.PartialView("InformationPartial", infoViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}