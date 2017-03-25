using Bytes2you.Validation;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculatorWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = ValidationConstants.AdminRole)]
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

            var users = this.userService.GetAll().OrderBy(x=> x.UserName).AsEnumerable();

            usersViewModel = this.mapService.Map<IEnumerable<UsersViewModel>>(users);
            return View("Index",usersViewModel);
        }

        [HttpGet]
        public ActionResult Edit(Guid id,UsersViewModel userModel)
        {
            var user = this.userService.GetById(id.ToString());
            if (user == null)
            {
                return HttpNotFound();
            }
            userModel = this.mapService.Map<UsersViewModel>(user);

            return View("Edit", userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersViewModel userModel)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.mapService.Map<User>(userModel);

                this.userService.UpdateById(user.Id, user);
                return RedirectToAction("Index", "Users");
            }
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Delete(Guid id, User user)
        {
            user = this.userService.GetById(id.ToString());
            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = this.mapService.Map<UsersViewModel>(user);
            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, UsersViewModel userViewModel)
        {
            this.userService.DeleteById(id.ToString());

            return RedirectToAction("Index", "Users");
        }
    }
}