using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubesbackuup
{
    public class InformasiTambahan<data>
    {
        public data hobi { get; set; }
        public data passiveIncome { get; set; }
        public data jumlahAnak { get; set; }
        public data pendidikanTerakhir { get; set; }

        public InformasiTambahan(data hobi, data passiveIncome, data jumlahAnak, data pendidikanTerakhir)
        {
            this.hobi = hobi;
            this.passiveIncome = passiveIncome;
            this.jumlahAnak = jumlahAnak;
            this.pendidikanTerakhir = pendidikanTerakhir;
        }

    }
}
