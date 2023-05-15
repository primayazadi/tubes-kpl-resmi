using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentReport;
using System;
using System.Collections.Generic;
using static PaymentReport.PaymentReportLibrary;

namespace PaymentReportLibraryTests
{
    [TestClass]
    public class PaymentReportLibraryTests
    {
        [TestMethod]
        public void TestCalculateTotalIncome()
        {
            // Arrange
            var user = new PaymentReportLibrary.User(
                name: "John Doe",
                email: "johndoe@example.com",
                password: "password",
                expense: new List<PaymentReportLibrary.Expense>(),
                TotalIncome: 5000
            );
            var report = new PaymentRepost();

            // Act
            var totalIncome = report.CalculateTotalIncome(user);

            // Assert
            Assert.AreEqual(5000, totalIncome);
        }

        [TestMethod]
        public void TestCalculateTotalExpenses()
        {
            // Arrange
            var user = new PaymentReportLibrary.User(
                name: "John Doe",
                email: "johndoe@example.com",
                password: "password",
                expense: new List<PaymentReportLibrary.Expense>
                {
                    new PaymentReportLibrary.Expense
                    {
                        UserId = 1,
                        Name = "Rent",
                        Amount = 1000,
                        Date = new DateTime(2023, 5, 1)
                    },
                    new PaymentReportLibrary.Expense
                    {
                        UserId = 1,
                        Name = "Groceries",
                        Amount = 500,
                        Date = new DateTime(2023, 5, 15)
                    }
                },
                TotalIncome: 5000
            );
            var report = new PaymentRepost();

            // Act
            var totalExpenses = report.CalculateTotalExpenses(user, month: 5, year: 2023);

            // Assert
            Assert.AreEqual(1500, totalExpenses);
        }

        [TestMethod]
        public void TestCalculateNetIncome()
        {
            // Arrange
            var user = new PaymentReportLibrary.User(
                name: "John Doe",
                email: "johndoe@example.com",
                password: "password",
                expense: new List<PaymentReportLibrary.Expense>
                {
                    new PaymentReportLibrary.Expense
                    {
                        UserId = 1,
                        Name = "Rent",
                        Amount = 1000,
                        Date = new DateTime(2023, 5, 1)
                    },
                    new PaymentReportLibrary.Expense
                    {
                        UserId = 1,
                        Name = "Groceries",
                        Amount = 500,
                        Date = new DateTime(2023, 5, 15)
                    }
                },
                TotalIncome: 5000
            );
            var report = new PaymentRepost();

            // Act
            var netIncome = report.CalculateNetIncome(user, month: 5, year: 2023);

            // Assert
            Assert.AreEqual(3500, netIncome);
        }
    }
}
