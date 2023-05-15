using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubesbackuup;

namespace test2
{
    [TestClass]
    public class g
    {
        [TestMethod]
        public void InformasiTambahan_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string hobi = "Membaca";
            string passiveIncome = "Investasi saham";
            string pendidikanTerakhir = "S2";

            // Act
            var informasiTambahan = new InformasiTambahan<string>(hobi, passiveIncome, null, pendidikanTerakhir);

            // Assert
            Assert.AreEqual(hobi, informasiTambahan.hobi);
            Assert.AreEqual(passiveIncome, informasiTambahan.passiveIncome);
            Assert.IsNull(informasiTambahan.jumlahAnak);
            Assert.AreEqual(pendidikanTerakhir, informasiTambahan.pendidikanTerakhir);
        }
    }
}
