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

namespace SalaryCalculatorWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = ValidationConstants.AdminRole)]
    public class EmployeeAdminController : Controller
    {
        private readonly IMapService mapService;
        private readonly IEmployeeService employeeService;
        private readonly IPagerFactory pagerFactory;

        public EmployeeAdminController(IMapService mapService, IEmployeeService employeeService, IPagerFactory pagerFactory)
        {
            Guard.WhenArgument<IMapService>(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument<IEmployeeService>(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument<IPagerFactory>(pagerFactory, "pagerFactory").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
            this.pagerFactory = pagerFactory;
        }

        // GET: Admin/Employees
        [HttpGet]
        public ActionResult Index(int? page, PageViewModel<EmployeesViewModel> pageViewModel)
        {

            var employees = this.employeeService.GetAll().OrderBy(x=> x.FirstName).ThenBy(x=>x.MiddleName).ThenBy(x=> x.LastName).AsEnumerable();
            var pager = this.pagerFactory.CreatePager(employees.Count(), page);

            pageViewModel.Items = this.mapService.Map<IEnumerable<EmployeesViewModel>>(employees)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize);
            pageViewModel.Pager = pager;

            return View("Index",pageViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id,EmployeesViewModel employeeModel)
        {
            var user = this.employeeService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            employeeModel = this.mapService.Map<EmployeesViewModel>(user);

            return View("Edit", employeeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesViewModel employeeModel)
        {
            if (this.ModelState.IsValid)
            {
                var employee = this.mapService.Map<Employee>(employeeModel);

                this.employeeService.UpdateById(employee.Id, employee);
                return RedirectToAction("Index", "EmployeeAdmin");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public ActionResult Delete(int id, Employee employee)
        {
            employee = this.employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeViewModel = this.mapService.Map<EmployeesViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, EmployeesViewModel empoyeeViewModel)
        {
            this.employeeService.DeleteById(id);

            return RedirectToAction("Index", "EmployeeAdmin");
        }
    }
}