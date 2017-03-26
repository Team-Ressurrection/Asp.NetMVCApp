using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculatorWeb.Areas.Admin.Models;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers.Base;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = ValidationConstants.AdminRole)]
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IMapService mapService, IPagerFactory pagerFactory,IUserService userService )
            :base(mapService,pagerFactory)
        {
            Guard.WhenArgument<IUserService>(userService, "userService").IsNull().Throw();

            this.userService = userService;
        }

        // GET: Admin/Users
        [HttpGet]
        public ActionResult Index(int? page, PageViewModel<UsersViewModel> pageViewModel)
        {

            var users = this.userService.GetAll().OrderBy(x=> x.UserName).AsEnumerable();
            var pager = this.pagerFactory.CreatePager(users.Count(), page);

            pageViewModel.Items = this.mapService.Map<IEnumerable<UsersViewModel>>(users)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize);
            pageViewModel.Pager = pager;

            return View("Index",pageViewModel);
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