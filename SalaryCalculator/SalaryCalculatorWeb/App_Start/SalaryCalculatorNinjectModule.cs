using Ninject.Modules;
using Ninject.Web.Common;
using SalaryCalculator.Configuration.Caching;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculatorWeb.App_Start
{
    public class SalaryCalculatorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISalaryCalculatorDbContext>().To<SalaryCalculatorDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(SalaryCalculatorRepository<>)).InSingletonScope();

            this.Bind<IRemunerationBillService>().To<RemunerationBillService>().InRequestScope();
            this.Bind<IEmployeePaycheckService>().To<EmployeePaycheckService>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<ISelfEmploymentService>().To<SelfEmploymentService>().InRequestScope();
            this.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();

            this.Bind<User>().ToSelf();
            this.Bind<Employee>().ToSelf();
            this.Bind<RemunerationBill>().ToSelf();
            this.Bind<EmployeePaycheck>().ToSelf();
            this.Bind<SelfEmployment>().ToSelf();

            this.Bind<ICacheService>().To<HttpCacheService>();
        }
    }
}