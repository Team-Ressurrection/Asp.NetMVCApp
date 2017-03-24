using Bytes2you.Validation;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IMapService mapService;
        private readonly IUserService userService;

        public UsersController(IMapService mapService, IUserService userService)
        {
            Guard.WhenArgument<IMapService>(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument<IUserService>(userService, "userService").IsNull().Throw();

            this.mapService = mapService;
            this.userService = userService;
        }

        // GET: Admin/Users
        public ActionResult Index(IEnumerable<UsersViewModel> usersViewModel)
        {

            var users = this.userService.GetAll().AsEnumerable();

            usersViewModel = this.mapService.Map<IEnumerable<UsersViewModel>>(users);
            return View("Index",usersViewModel);
        }
    }
}