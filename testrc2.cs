using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubesbackuup;

namespace test2
{
    [TestClass]
    public class testrc2
    {
        [TestMethod]
        public void ChangeConfiguration_ValidInput_SetsConfigName()
        {
            // Arrange
            var runtimeConfigu = new RuntimeConfigu();
            var expectedName = "John";

            // Act
            using (StringReader sr = new StringReader(expectedName))
            {
                Console.SetIn(sr);
                runtimeConfigu.changeConfiguration();
            }

            // Assert
            Assert.AreEqual(expectedName, runtimeConfigu.config.Name);
        }

        [TestMethod]
        public void ChangeConfiguration_DisplayWelcomeMessage()
        {
            // Arrange
            var runtimeConfigu = new RuntimeConfigu();
            var expectedName = "John";
            var expectedWelcomeMessage = $"Welcome {expectedName}";

            // Act
            using (StringReader sr = new StringReader(expectedName))
            {
                Console.SetIn(sr);
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    runtimeConfigu.changeConfiguration();
                    var output = sw.ToString().Trim();
                    var lines = output.Split(Environment.NewLine).Select(x => x.Trim());

                    // Assert
                    Assert.AreEqual(expectedWelcomeMessage, lines.Last());
                }
            }
        }
    }
}
   
