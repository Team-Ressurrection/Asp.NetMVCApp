using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Utilities.Pagination;
using SalaryCalculatorWeb.Areas.Admin.Models;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers.Base;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = ValidationConstants.AdminRole)]
    public class PaychecksController : BaseController
    {
        private readonly IEmployeePaycheckService employeePaycheckService;

        public PaychecksController(IMapService mapService, IPagerFactory pagerFactory, IEmployeePaycheckService employeePaycheckService)
            : base(mapService, pagerFactory)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(employeePaycheckService, "employeePaycheckService").IsNull().Throw();

            this.employeePaycheckService = employeePaycheckService;
        }

        // GET: Admin/Employees
        [HttpGet]
        public ActionResult Index(int? page, PageViewModel<PaycheckViewModel> pageViewModel)
        {

            var paychecks = this.employeePaycheckService.GetAll().OrderBy(x=> x.Id).AsEnumerable();
            var pager = this.pagerFactory.CreatePager(paychecks.Count(), page);

            pageViewModel.Items = this.mapService.Map<IEnumerable<PaycheckViewModel>>(paychecks)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize);
            pageViewModel.Pager = pager;

            return View("Index",pageViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id, PaycheckViewModel paycheckModel)
        {
            var paycheck = this.employeePaycheckService.GetById(id);
            if (paycheck == null)
            {
                return HttpNotFound();
            }
            paycheckModel = this.mapService.Map<PaycheckViewModel>(paycheck);

            return View("Edit", paycheckModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaycheckViewModel paycheckModel)
        {
            if (this.ModelState.IsValid)
            {
                var paycheck = this.mapService.Map<EmployeePaycheck>(paycheckModel);

                this.employeePaycheckService.UpdateById(paycheck.Id, paycheck);
                return RedirectToAction("Index", "Paychecks");
            }
            return View(paycheckModel);
        }

        [HttpGet]
        public ActionResult Delete(int id, EmployeePaycheck paycheck)
        {
            paycheck = this.employeePaycheckService.GetById(id);
            if (paycheck == null)
            {
                return HttpNotFound();
            }

            var paycheckViewModel = this.mapService.Map<PaycheckViewModel>(paycheck);
            return View(paycheckViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, PaycheckViewModel paycheckViewModel)
        {
            this.employeePaycheckService.DeleteById(id);

            return RedirectToAction("Index", "Paychecks");
        }
    }
}