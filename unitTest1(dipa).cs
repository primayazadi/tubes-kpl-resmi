using tubesbackuup;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChangeConfiguration_ShouldUpdateName()
        {

            // Arrange
           RuntimeConfigu runtimeConfig = new RuntimeConfigu();
                string expectedName = "John";

                // Act
                runtimeConfig.changeConfiguration();
                runtimeConfig.config.Name = expectedName;

                // Assert
                Assert.AreEqual(expectedName, runtimeConfig.config.Name);
            }
    
    }
}