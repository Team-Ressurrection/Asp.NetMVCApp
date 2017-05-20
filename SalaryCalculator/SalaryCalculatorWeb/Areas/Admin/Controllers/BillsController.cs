using SalaryCalculatorWeb.Areas.Admin.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculator.Data.Services.Contracts;
using Bytes2you.Validation;
using SalaryCalculatorWeb.Areas.Admin.Models;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
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
    }
}