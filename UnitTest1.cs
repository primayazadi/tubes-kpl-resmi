using tubesbackuup;

namespace test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WriteConfig_ValidConfig_WritesConfig()
        {
            // Arrange
            var runtimeConfig = new RuntimeConfig();
            var config = new Config("TestPendapatan", "TestPengeluaran", "TestJangkaAnalisis");

            // Act
            runtimeConfig.config = config;
            runtimeConfig.WriteConfig();

            // Assert
            var result = runtimeConfig.ReadConfig();
            Assert.AreEqual(config.sumberPendapatan, result.sumberPendapatan);
            Assert.AreEqual(config.sumberPengeluaran, result.sumberPengeluaran);
            Assert.AreEqual(config.jangkaAnalisis, result.jangkaAnalisis);
        }

        [TestMethod]
        public void SetDefault_UpdatesConfigWithDefaultValues()
        {
            // Arrange
            var runtimeConfig = new RuntimeConfig();

            // Act
            runtimeConfig.SetDefault();

            // Assert
            Assert.AreEqual("Gaji", runtimeConfig.config.sumberPendapatan);
            Assert.AreEqual("Primer", runtimeConfig.config.sumberPengeluaran);
            Assert.AreEqual("harian", runtimeConfig.config.jangkaAnalisis);
        }
    }
}