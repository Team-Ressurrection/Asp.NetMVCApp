using Bytes2you.Validation;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculatorWeb.Models.ContractViewModels;
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
        private Payroll calculate;

        public LaborContractController(IMapService mapService, IEmployeeService employeeService, IEmployeePaycheckService employeePaycheckService, Payroll calculate)
        {
            Guard.WhenArgument(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument(employeePaycheckService, "employeePaycheckService").IsNull().Throw();
            Guard.WhenArgument(calculate, "calculate").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
            this.employeePaycheckService = employeePaycheckService;
            this.calculate = calculate;
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
        public ActionResult CreateLaborContract(int id)
        {
            var employee = this.employeeService.GetById(id);
            EmployeePaycheck employeePaycheck = new EmployeePaycheck();
            employeePaycheck.EmployeeId = id;
            employeePaycheck.Employee = employee;
            var laborContractModel = this.mapService.Map<CreateEmployeePaycheckViewModel>(employeePaycheck);
            return View(laborContractModel);
        }

        // POST: LaborContract/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLaborContract(int id,PreviewEmployeePaycheckViewModel laborContractModel)
        {
            var grossSalary = laborContractModel.GrossSalary + laborContractModel.GrossFixedBonus + laborContractModel.GrossNonFixedBonus;
            var isMaxSSI = this.calculate.CheckMaxSocialSecurityIncome(grossSalary);
            laborContractModel.SocialSecurityIncome = isMaxSSI ? ValidationConstants.MaxSocialSecurityIncome:grossSalary ;
            laborContractModel.PersonalInsurance = this.calculate.GetPersonalInsurance(grossSalary);
            laborContractModel.IncomeTax = this.calculate.GetIncomeTax(grossSalary, laborContractModel.PersonalInsurance);
            laborContractModel.NetWage = this.calculate.GetNetWage(grossSalary, laborContractModel.PersonalInsurance, laborContractModel.IncomeTax);
            laborContractModel.EmployeeId = id;
            var employee = this.employeeService.GetById(id);
            laborContractModel.EmployeeFullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

            if (this.ModelState.IsValid)
            {
                var paycheck = this.mapService.Map<EmployeePaycheck>(laborContractModel);
                this.employeePaycheckService.Create(paycheck);
                return View("Details", laborContractModel);
            }

            return View(laborContractModel);
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
