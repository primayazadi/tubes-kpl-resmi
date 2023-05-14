using static PaymentReport.PaymentReportLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAddIncome
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            User user = new User("Prima", "yzd", "primayzd@contoh.com");
            decimal amount = 1000;

            // Act
            AddIncome(user, amount);

            // Assert
            Assert.AreEqual(amount, user.TotalIncome);
        }

        public void AddIncome(User user, decimal amount)
        {
            user.TotalIncome += amount;
        }
    }
}