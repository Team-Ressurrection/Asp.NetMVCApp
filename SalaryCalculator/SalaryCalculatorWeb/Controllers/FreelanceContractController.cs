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
    public class FreelanceContractController : Controller
    {
        private IMapService mapService;
        private IEmployeeService employeeService;
        private ISelfEmploymentService selfEmploymentService;
        private Payroll calculate;

        public FreelanceContractController(IMapService mapService, IEmployeeService employeeService, ISelfEmploymentService selfEmploymentService, Payroll calculate)
        {
            Guard.WhenArgument(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument(selfEmploymentService, "selfEmploymentService").IsNull().Throw();
            Guard.WhenArgument(calculate, "calculate").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
            this.selfEmploymentService = selfEmploymentService;
            this.calculate = calculate;
        }
        // GET: LaborContract
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: LaborContract/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaborContract/CreateLaborContract/5
        [HttpGet]
        public ActionResult CreateFreelanceContract(int id, SelfEmployment selfEmployment)
        {
            var employee = this.employeeService.GetById(id);
            selfEmployment.EmployeeId = id;
            selfEmployment.Employee = employee;
            var laborContractModel = this.mapService.Map<CreateSelfEmploymentViewModel>(selfEmployment);
            return View(laborContractModel);
        }

        // POST: LaborContract/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFreelanceContract(int id, PreviewSelfEmploymentViewModel freelanceContractModel)
        {
            var grossSalary = freelanceContractModel.GrossSalary;
            var socialSecurityIncome = freelanceContractModel.SocialSecurityIncome;
            var isMaxSSI = this.calculate.CheckMaxSocialSecurityIncome(grossSalary);
            freelanceContractModel.SocialSecurityIncome = isMaxSSI ? ValidationConstants.MaxSocialSecurityIncome : socialSecurityIncome;
            freelanceContractModel.PersonalInsurance = this.calculate.GetPersonalInsurance(socialSecurityIncome);
            freelanceContractModel.IncomeTax = this.calculate.GetIncomeTax(grossSalary, freelanceContractModel.PersonalInsurance);
            freelanceContractModel.NetWage = this.calculate.GetNetWage(grossSalary, freelanceContractModel.PersonalInsurance, freelanceContractModel.IncomeTax);
            freelanceContractModel.EmployeeId = id;
            var employee = this.employeeService.GetById(id);
            freelanceContractModel.EmployeeFullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

            if (this.ModelState.IsValid)
            {
                var selfEmployment = this.mapService.Map<SelfEmployment>(freelanceContractModel);
                this.selfEmploymentService.Create(selfEmployment);
                return View("Details", freelanceContractModel);
            }

            return View(freelanceContractModel);
        }

        // GET: FreelanceContract/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, SelfEmployment selfEmployment)
        {
            selfEmployment = this.selfEmploymentService.GetById(id);
            if (selfEmployment == null)
            {
                return HttpNotFound();
            }
            var freelanceContractModel = this.mapService.Map<PreviewSelfEmploymentViewModel>(selfEmployment);
            var employee = this.employeeService.GetById(selfEmployment.EmployeeId);
            freelanceContractModel.EmployeeId = employee.Id;
            freelanceContractModel.EmployeeFullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

            return View(freelanceContractModel);
        }

        // POST: FreelanceContract/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PreviewSelfEmploymentViewModel selfEmploymentViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var selfEmployment = this.mapService.Map<SelfEmployment>(selfEmploymentViewModel);
                selfEmployment.EmployeeId = selfEmploymentViewModel.EmployeeId;
                this.selfEmploymentService.UpdateById(selfEmployment.Id, selfEmployment);
                return RedirectToAction("Details", "Employees", new { id = selfEmployment.EmployeeId });
            }
            return View(selfEmploymentViewModel);
        }

        // GET: FreelanceContract/Delete/5
        [HttpGet]
        public ActionResult Delete(int id, SelfEmployment selfEmployment)
        {
            selfEmployment = this.selfEmploymentService.GetById(id);
            if (selfEmployment == null)
            {
                return HttpNotFound();
            }

            var freelanceContractModel = this.mapService.Map<PreviewSelfEmploymentViewModel>(selfEmployment);
            return View(freelanceContractModel);
        }

        // POST: Freelance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, PreviewSelfEmploymentViewModel selfEmploymentViewModel)
        {
            this.selfEmploymentService.DeleteById(id);

            return RedirectToAction("Index", "Employees");
        }
    }
}