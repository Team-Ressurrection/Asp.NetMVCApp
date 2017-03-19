using System.Linq;
using System.Net;
using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using AutoMapper;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculatorWeb.Models.EmployeeViewModels;

namespace SalaryCalculatorWeb.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IMapService mapService;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IMapService mapService, IEmployeeService employeeService)
        {
            Guard.WhenArgument(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(this.employeeService.GetAll().ToList());
        }

        // GET: Employees/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeViewModel = this.mapService.Map<EmployeeViewModel>(employee);

            return View(employeeViewModel);
        }

        // GET: Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var employee = this.mapService.Map<Employee>(employeeViewModel);
                this.employeeService.Create(employee);
                return RedirectToAction("Index");
            }

            return View(employeeViewModel);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = this.employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeViewModel = this.mapService.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var employee = this.mapService.Map<Employee>(employeeViewModel);
                this.employeeService.UpdateById(employee.Id, employee);
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = this.employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeViewModel = this.mapService.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.employeeService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
