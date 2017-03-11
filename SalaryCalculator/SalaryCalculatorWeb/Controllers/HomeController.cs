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

        public HomeController(ICacheService cacheService, IUserService userService)
        {
            Guard.WhenArgument(cacheService, "cacheService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.cacheService = cacheService;
            this.userService = userService;
        }

        public ActionResult Index(InfoViewModel infoViewModel)
        {
            var registeredUsers = this.cacheService.Get("totalRegisteredUsers", () => this.userService.GetAll().Count(), 60);

            infoViewModel.TotalRegisteredUsers = registeredUsers;
            return View(infoViewModel);
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