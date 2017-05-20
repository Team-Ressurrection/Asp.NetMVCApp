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
    public class SelfEmploymentsController : BaseController
    {
        private readonly ISelfEmploymentService selfService;

        public SelfEmploymentsController(IMapService mapService, IPagerFactory pagerFactory, ISelfEmploymentService selfService) 
            : base(mapService, pagerFactory)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfService, "selfService").IsNull().Throw();

            this.selfService = selfService;
        }

        // GET: Admin/Bills
        public ActionResult Index(int? page, PageViewModel<SelfEmploymentViewModel> pageViewModel)
        {
            var selfEmpl = this.selfService.GetAll().OrderBy(x => x.Id).AsEnumerable();
            var pager = this.pagerFactory.CreatePager(selfEmpl.Count(), page);

            pageViewModel.Items = this.mapService.Map<IEnumerable<SelfEmploymentViewModel>>(selfEmpl)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize);
            pageViewModel.Pager = pager;

            return View("Index", pageViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id, SelfEmploymentViewModel selfEmplViewModel)
        {
            var selfEmpl = this.selfService.GetById(id);
            if (selfEmpl == null)
            {
                return HttpNotFound();
            }
            selfEmplViewModel = this.mapService.Map<SelfEmploymentViewModel>(selfEmpl);

            return View("Edit", selfEmplViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SelfEmploymentViewModel selfEmplViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var selfEmpl = this.mapService.Map<SelfEmployment>(selfEmplViewModel);

                this.selfService.UpdateById(selfEmpl.Id, selfEmpl);
                return RedirectToAction("Index", "SelfEmployments");
            }
            return View(selfEmplViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id, SelfEmploymentViewModel selfEmplViewModel)
        {
            var selfEmpl = this.selfService.GetById(id);
            if (selfEmpl == null)
            {
                return HttpNotFound();
            }

            selfEmplViewModel = this.mapService.Map<SelfEmploymentViewModel>(selfEmpl);
            return View(selfEmplViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, SelfEmploymentViewModel selfEmplViewModel)
        {
            this.selfService.DeleteById(id);

            return RedirectToAction("Index", "SelfEmployments");
        }
    }
}