using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubesbackuup;

namespace test
{
    [TestClass]
    internal class TestRuntimeConfig_prima_
    {
        [TestMethod]
        public void TestReadConfig()
        {
            // Arrange
            RuntimeConfig runtimeConfig = new RuntimeConfig();

            // Act
            Config config = runtimeConfig.ReadConfig();

            // Assert
            Assert.AreEqual("Gaji", config.sumberPendapatan);
            Assert.AreEqual("Primer", config.sumberPengeluaran);
            Assert.AreEqual("harian", config.jangkaAnalisis);
        }

        [TestMethod]
        public void TestWriteConfig()
        {
            // Arrange
            RuntimeConfig runtimeConfig = new RuntimeConfig();
            Config config = new Config("Penghasilan", "Sekunder", "mingguan");
            runtimeConfig.config = config;

            // Act
            runtimeConfig.WriteConfig();

            // Assert
            Config savedConfig = runtimeConfig.ReadConfig();
            Assert.AreEqual("Penghasilan", savedConfig.sumberPendapatan);
            Assert.AreEqual("Sekunder", savedConfig.sumberPengeluaran);
            Assert.AreEqual("mingguan", savedConfig.jangkaAnalisis);
        }

        [TestMethod]
        public void TestSetDefault()
        {
            // Arrange
            RuntimeConfig runtimeConfig = new RuntimeConfig();

            // Act
            runtimeConfig.SetDefault();

            // Assert
            Assert.AreEqual("Gaji", runtimeConfig.config.sumberPendapatan);
            Assert.AreEqual("Primer", runtimeConfig.config.sumberPengeluaran);
            Assert.AreEqual("harian", runtimeConfig.config.jangkaAnalisis);
        }
    }
}

