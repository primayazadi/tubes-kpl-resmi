using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    [TestClass]
    public class td
    {
        [TestMethod]
        public void CetakKategoriPemasukan_RendahCategory_CorrectOutput()
        {
            // Arrange
            var moneyManager = new MoneyManagerr();
            var pemasukan = new Pemasukan
            {
                Deskripsi = "Pendapatan Rendah",
                JumlahUang = 1500000,
                Kategori = "Rendah"
            };

            var expectedOutput = $"Deskripsi: {pemasukan.Deskripsi}{Environment.NewLine}Harga: {pemasukan.JumlahUang}";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                moneyManager.CetakKategoriPemasukan(pemasukan);
                var output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, output);
            }
        }

        [TestMethod]
        public void CetakKategoriPemasukan_MenengahCategory_CorrectOutput()
        {
            // Arrange
            var moneyManager = new MoneyManagerr();
            var pemasukan = new Pemasukan
            {
                Deskripsi = "Pendapatan Menengah",
                JumlahUang = 4000000,
                Kategori = "Menengah"
            };

            var expectedOutput = $"Deskripsi: {pemasukan.Deskripsi}{Environment.NewLine}Harga: {pemasukan.JumlahUang}";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                moneyManager.CetakKategoriPemasukan(pemasukan);
                var output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, output);
            }
        }

        [TestMethod]
        public void CetakKategoriPemasukan_RataRataCategory_CorrectOutput()
        {
            // Arrange
            var moneyManager = new MoneyManagerr();
            var pemasukan = new Pemasukan
            {
                Deskripsi = "Pendapatan RataRata",
                JumlahUang = 9000000,
                Kategori = "RataRata"
            };

            var expectedOutput = $"Deskripsi: {pemasukan.Deskripsi}{Environment.NewLine}Harga: {pemasukan.JumlahUang}";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                moneyManager.CetakKategoriPemasukan(pemasukan);
                var output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, output);
            }
        }
    }
}

