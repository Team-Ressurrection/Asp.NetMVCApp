using System.Web.Mvc;

using Bytes2you.Validation;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;

using SalaryCalculatorWeb.Models.ContractViewModels;

namespace SalaryCalculatorWeb.Controllers
{
    public class NonLaborContractController : Controller
    {
        private IMapService mapService;
        private IEmployeeService employeeService;
        private IRemunerationBillService remunerationBillService;
        private Payroll calculate;

        public NonLaborContractController(IMapService mapService, IEmployeeService employeeService, IRemunerationBillService remunerationBillService, Payroll calculate)
        {
            Guard.WhenArgument(mapService, "mapService").IsNull().Throw();
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument(remunerationBillService, "employeePaycheckService").IsNull().Throw();
            Guard.WhenArgument(calculate, "calculate").IsNull().Throw();

            this.mapService = mapService;
            this.employeeService = employeeService;
            this.remunerationBillService = remunerationBillService;
            this.calculate = calculate;
        }

        // GET: NonLaborContract
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: NonLaborContract/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NonLaborContract/Create
        [HttpGet]
        public ActionResult CreateNonLaborContract(int id, RemunerationBill remunerationBill)
        {
            var employee = this.employeeService.GetById(id);
            remunerationBill.EmployeeId = id;
            remunerationBill.Employee = employee;
            var nonLaborContractModel = this.mapService.Map<CreateRemunerationBillViewModel>(remunerationBill);
            return View(nonLaborContractModel);
        }

        // POST: NonLaborContract/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNonLaborContract(int id, PreviewRemunerationBillViewModel nonLaborContractModel)
        {
            var grossSalary = nonLaborContractModel.GrossSalary;
            var isMaxSSI = this.calculate.CheckMaxSocialSecurityIncome(grossSalary);
            nonLaborContractModel.SocialSecurityIncome = isMaxSSI ? ValidationConstants.MaxSocialSecurityIncome : grossSalary;
            nonLaborContractModel.PersonalInsurance = this.calculate.GetPersonalInsurance(grossSalary);
            nonLaborContractModel.IncomeTax = this.calculate.GetIncomeTax(grossSalary, nonLaborContractModel.PersonalInsurance);
            nonLaborContractModel.NetWage = this.calculate.GetNetWage(grossSalary, nonLaborContractModel.PersonalInsurance, nonLaborContractModel.IncomeTax);
            nonLaborContractModel.EmployeeId = id;
            var employee = this.employeeService.GetById(id);
            nonLaborContractModel.EmployeeFullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

            if (this.ModelState.IsValid)
            {
                var bill = this.mapService.Map<RemunerationBill>(nonLaborContractModel);
                this.remunerationBillService.Create(bill);
                return View("Details", nonLaborContractModel);
            }

            return View(nonLaborContractModel);
        }
    }
}
