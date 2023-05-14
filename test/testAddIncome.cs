using Microsoft.VisualStudio.TestTools.UnitTesting;
using tubesbackuup;

namespace TubesBackupTest
{
    [TestClass]
    public class GenericAddIncomeTests
    {
        [TestMethod]
        public void TestAddIncomeWithInteger()
        {
            // Arrange
            var user = new User("John Doe", "johndoe@example.com", "password", new List<Expense>(), 5000m);

            // Act
            genericAddIncome_Rafkha_.AddIncome<int>(user);

            // Assert
            Assert.AreEqual(5500m, user.TotalIncome);
        }

        [TestMethod]
        public void TestAddIncomeWithDecimal()
        {
            // Arrange
            var user = new User("John Doe", "johndoe@example.com", "password", new List<Expense>(), 5000m);

            // Act
            genericAddIncome_Rafkha_.AddIncome<decimal>(user);

            // Assert
            Assert.AreEqual(5500m, user.TotalIncome);
        }

        [TestMethod]
        public void TestAddIncomeWithDouble()
        {
            // Arrange
            var user = new User("John Doe", "johndoe@example.com", "password", new List<Expense>(), 5000m);

            // Act
            genericAddIncome_Rafkha_.AddIncome<double>(user);

            // Assert
            Assert.AreEqual(5500m, user.TotalIncome);
        }

        [TestMethod]
        public void TestAddIncomeWithInvalidInput()
        {
            // Arrange
            var user = new User("John Doe", "johndoe@example.com", "password", new List<Expense>(), 5000m);

            // Act
            genericAddIncome_Rafkha_.AddIncome<string>(user);

            // Assert
            Assert.AreEqual(5000m, user.TotalIncome);
        }
    }
}
