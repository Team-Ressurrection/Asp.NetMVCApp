﻿using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;

using SalaryCalculatorWeb.Models.ContractViewModels;
using System;

namespace SalaryCalculatorWeb.Controllers
{
    [Authorize]
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

        // GET: LaborContract/CreateLaborContract/5
        [HttpGet]
        public ActionResult CreateLaborContract(int id, EmployeePaycheck employeePaycheck)
        {
            var employee = this.employeeService.GetById(id);
            employeePaycheck.EmployeeId = id;
            employeePaycheck.Employee = employee;
            var laborContractModel = this.mapService.Map<CreateEmployeePaycheckViewModel>(employeePaycheck);
            laborContractModel.CreatedDate = DateTime.Today;
            return View(laborContractModel);
        }

        // POST: LaborContract/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLaborContract(int id, PreviewEmployeePaycheckViewModel laborContractModel)
        {
            var grossSalary = laborContractModel.GrossSalary + laborContractModel.GrossFixedBonus + laborContractModel.GrossNonFixedBonus;
            var isMaxSSI = this.calculate.CheckMaxSocialSecurityIncome(grossSalary);
            laborContractModel.SocialSecurityIncome = isMaxSSI ? ValidationConstants.MaxSocialSecurityIncome : grossSalary;
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
        [HttpGet]
        public ActionResult Edit(int id, EmployeePaycheck paycheck)
        {
            paycheck = this.employeePaycheckService.GetById(id);
            if (paycheck == null)
            {
                return HttpNotFound();
            }
            var laborContractModel = this.mapService.Map<PreviewEmployeePaycheckViewModel>(paycheck);
            var employee = this.employeeService.GetById(paycheck.EmployeeId);
            laborContractModel.EmployeeId = employee.Id;
            laborContractModel.EmployeeFullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

            return View(laborContractModel);
        }

        // POST: LaborContract/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PreviewEmployeePaycheckViewModel paycheckViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var employeePaycheck = this.mapService.Map<EmployeePaycheck>(paycheckViewModel);
                employeePaycheck.EmployeeId = paycheckViewModel.EmployeeId;
                this.employeePaycheckService.UpdateById(employeePaycheck.Id, employeePaycheck);
                return RedirectToAction("Details","Employees",new { id=employeePaycheck.EmployeeId});
            }
            return View(paycheckViewModel);
        }

        // GET: LaborContract/Delete/5
        [HttpGet]
        public ActionResult Delete(int id, EmployeePaycheck paycheck)
        {
            paycheck = this.employeePaycheckService.GetById(id);
            if (paycheck == null)
            {
                return HttpNotFound();
            }

            var employeeViewModel = this.mapService.Map<PreviewEmployeePaycheckViewModel>(paycheck);
            return View(employeeViewModel);
        }

        // POST: LaborContract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, PreviewEmployeePaycheckViewModel paycheckViewModel)
        {
            this.employeePaycheckService.DeleteById(id);

            return RedirectToAction("Index","Employees");
        }
    }
}
