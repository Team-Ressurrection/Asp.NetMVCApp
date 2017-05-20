using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Data.Models;

using SalaryCalculatorWeb.Areas.Admin.Controllers.Base;
using SalaryCalculatorWeb.Areas.Admin.Models;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = ValidationConstants.AdminRole)]
    public class BillsController : BaseController
    {
        private readonly IRemunerationBillService billService;

        public BillsController(IMapService mapService, IPagerFactory pagerFactory, IRemunerationBillService billService) 
            : base(mapService, pagerFactory)
        {
            Guard.WhenArgument<IRemunerationBillService>(billService, "billService").IsNull().Throw();

            this.billService = billService;
        }

        // GET: Admin/Bills
        public ActionResult Index(int? page, PageViewModel<BillViewModel> pageViewModel)
        {
            var remunerationBills = this.billService.GetAll().OrderBy(x => x.Id).AsEnumerable();
            var pager = this.pagerFactory.CreatePager(remunerationBills.Count(), page);

            pageViewModel.Items = this.mapService.Map<IEnumerable<BillViewModel>>(remunerationBills)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize);
            pageViewModel.Pager = pager;

            return View("Index", pageViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id, BillViewModel billViewModel)
        {
            var remunerationBill = this.billService.GetById(id);
            if (remunerationBill == null)
            {
                return HttpNotFound();
            }
            billViewModel = this.mapService.Map<BillViewModel>(remunerationBill);

            return View("Edit", billViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BillViewModel billViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var remunerationBill = this.mapService.Map<RemunerationBill>(billViewModel);

                this.billService.UpdateById(remunerationBill.Id, remunerationBill);
                return RedirectToAction("Index", "Bills");
            }
            return View(billViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id, RemunerationBill bill)
        {
            bill = this.billService.GetById(id);
            if (bill == null)
            {
                return HttpNotFound();
            }

            var billViewModel = this.mapService.Map<BillViewModel>(bill);
            return View(billViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, BillViewModel billViewModel)
        {
            this.billService.DeleteById(id);

            return RedirectToAction("Index", "Bills");
        }
    }
}