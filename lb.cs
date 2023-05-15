using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationLibrary;

namespace test2
{
    [TestClass]
    public class lb
    {
        [TestMethod]
        public void IsValidName_NullName_ReturnsFalse()
        {
            // Arrange
            string name = null;

            // Act
            bool result = InputValidator.IsValidName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidName_EmptyName_ReturnsFalse()
        {
            // Arrange
            string name = "";

            // Act
            bool result = InputValidator.IsValidName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidName_ValidName_ReturnsTrue()
        {
            // Arrange
            string name = "John Doe";

            // Act
            bool result = InputValidator.IsValidName(name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmail_NullEmail_ReturnsFalse()
        {
            // Arrange
            string email = null;

            // Act
            bool result = InputValidator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            string email = "";

            // Act
            bool result = InputValidator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string email = "johndoe";

            // Act
            bool result = InputValidator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            // Arrange
            string email = "johndoe@example.com";

            // Act
            bool result = InputValidator.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
