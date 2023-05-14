using System;
using System.Collections.Generic;

public enum KategoriPengeluaran
{
    Rendah,
    Sedang,
    Tinggi
}

public class Pengeluaran
{
    public string Deskripsi { get; set; }
    public double JumlahUang { get; set; }
    public KategoriPengeluaran Kategori { get; set; }
}

public class KategoriPengeluaranTable
{
    private readonly List<Tuple<double, KategoriPengeluaran>> _table;

    public KategoriPengeluaranTable()
    {
        _table = new List<Tuple<double, KategoriPengeluaran>>()
        {
            new Tuple<double, KategoriPengeluaran>(499000, KategoriPengeluaran.Rendah),
            new Tuple<double, KategoriPengeluaran>(800000, KategoriPengeluaran.Sedang),
            new Tuple<double, KategoriPengeluaran>(500000, KategoriPengeluaran.Tinggi)
        };
    }

    public KategoriPengeluaran GetKategori(double jumlahUang)
    {
        foreach (var item in _table)
        {
            if (jumlahUang < item.Item1)
            {
                return item.Item2;
            }
        }

        return KategoriPengeluaran.Tinggi;
    }
}

public class MoneyManager
{
    private KategoriPengeluaranTable _kategoriPengeluaranTable;

    public MoneyManager()
    {
        _kategoriPengeluaranTable = new KategoriPengeluaranTable();
    }

    public void CetakKategoriPengeluaran(Pengeluaran pengeluaran)
    {
        var kategori = _kategoriPengeluaranTable.GetKategori(pengeluaran.JumlahUang);

        Console.WriteLine($"Deskripsi: {pengeluaran.Deskripsi}");
        Console.WriteLine($"Jumlah Uang: {pengeluaran.JumlahUang}");
        Console.WriteLine($"Kategori Pengeluaran: {kategori}");
    }
}
