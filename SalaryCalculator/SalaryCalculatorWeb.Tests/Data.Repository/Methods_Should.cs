using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Repositories;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace SalaryCalculator.Tests.Data.Repository
{
    [TestFixture]
    public class Methods_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenFilterParameterIsNull()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            var fakeData = new List<FakeEmployee>()
            {
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = null;

            // Act & Assert
            Assert.That(
            () => repo.GetAll(filter),
            Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            // Act & Assert
            Assert.That(() => repo.Add(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            // Act & Assert
            Assert.That(() => repo.Delete(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            // Act & Assert
            Assert.That(() => repo.Update(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }
    }
}