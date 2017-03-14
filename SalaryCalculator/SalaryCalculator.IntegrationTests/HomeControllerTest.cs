using NUnit.Framework;
using SalaryCalculator.Configuration.Caching;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Controllers;
using System;

namespace SalaryCalculator.IntegrationTests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            ISalaryCalculatorDbContext dbContext = new SalaryCalculatorDbContext();

            IRepository<User> userRepo = new SalaryCalculatorRepository<User>(dbContext);
            IRepository<EmployeePaycheck> paycheckRepo = new SalaryCalculatorRepository<EmployeePaycheck>(dbContext);
            IRepository<RemunerationBill> billRepo = new SalaryCalculatorRepository<RemunerationBill>(dbContext);
            IRepository<SelfEmployment> selfRepo = new SalaryCalculatorRepository<SelfEmployment>(dbContext);

            ICacheService cacheService = new HttpCacheService();
            IUserService userService = new UserService(userRepo);
            IEmployeePaycheckService paycheckService = new EmployeePaycheckService(paycheckRepo);
            IRemunerationBillService billService = new RemunerationBillService(billRepo);
            ISelfEmploymentService selfEmploymentService = new SelfEmploymentService(selfRepo);

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(new HomeController(cacheService, userService, paycheckService, billService, selfEmploymentService));
        }
    }
}
