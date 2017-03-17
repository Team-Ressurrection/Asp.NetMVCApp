using Bytes2you.Validation;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Controllers
{
    public class LaborContractController : Controller
    {
        private IMapService mapService;
        private IEmployeeService employeeService;
        private IEmployeePaycheckService employeePaycheckService;

        public LaborContractController(IMapService mapService, IEmployeeService employeeService, IEmployeePaycheckService employeePaycheckService)
        {
            Guard.WhenArgument(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument(employeePaycheckService, "employeePaycheckService").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
            this.employeePaycheckService = employeePaycheckService;
        }
        // GET: LaborContract
        public ActionResult Index()
        {
            return View();
        }

        // GET: LaborContract/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaborContract/CreateLaborContract/5
        [HttpGet]
        public ActionResult CreateLaborContract(int id, EmployeePaycheck employeePaycheck)
        {
            var employee = this.employeeService.GetById(id);
            employeePaycheck.EmployeeId = id;
            employeePaycheck.Employee = employee;
            var laborContractModel = this.mapService.Map<EmployeePaycheck>(employeePaycheck);
            return View(laborContractModel);
        }

        // POST: LaborContract/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaborContract/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaborContract/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaborContract/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaborContract/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
