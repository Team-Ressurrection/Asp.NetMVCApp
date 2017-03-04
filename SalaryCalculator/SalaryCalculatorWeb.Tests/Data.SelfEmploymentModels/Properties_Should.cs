using NUnit.Framework;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.SelfEmploymentModels
{
    [TestFixture]
    public class Properties_Should
    {
        private const string CreatedDateProperty = "CreatedDate";
        private const string GrossSalaryProperty = "GrossSalary";
        private const string SocialSecurityIncomeProperty = "SocialSecurityIncome";
        private const string PersonalInsuranceProperty = "PersonalInsurance";
        private const string IncomeTaxProperty = "IncomeTax";
        private const string NetWageProperty = "NetWage";
        private const string EmployeeIdProperty = "EmployeeId";

        [TestCase(1000)]
        [TestCase(500)]
        [TestCase(0)]
        public void WhenParameterGrossSalary_IsSetWithValidValue_ShouldSetUpCorrectly(decimal num)
        {
            // Arrange
            var selfEmpl = new SelfEmployment();

            // Act
            selfEmpl.GrossSalary = num;

            // Assert
            Assert.AreEqual(num, selfEmpl.GrossSalary);
        }

        [TestCase(CreatedDateProperty)]
        [TestCase(SocialSecurityIncomeProperty)]
        [TestCase(PersonalInsuranceProperty)]
        [TestCase(EmployeeIdProperty)]
        public void PropertiesWithRequiredAttribute_ShouldReturnTrue(string propertyName)
        {
            // Arrange
            var selfEmpl = new SelfEmployment();

            // Act
            var result = selfEmpl.GetType()
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();
            // Assert
            Assert.IsTrue(result);
        }
    }
}
