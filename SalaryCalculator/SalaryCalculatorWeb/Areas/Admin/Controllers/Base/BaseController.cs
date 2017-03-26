using Bytes2you.Validation;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Utilities.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Areas.Admin.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapService mapService;
        protected readonly IPagerFactory pagerFactory;

        public BaseController(IMapService mapService, IPagerFactory pagerFactory)
        {
            Guard.WhenArgument<IMapService>(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument<IPagerFactory>(pagerFactory, "pagerFactory").IsNull().Throw();

            this.mapService = mapService;
            this.pagerFactory = pagerFactory;
        }
    }
}