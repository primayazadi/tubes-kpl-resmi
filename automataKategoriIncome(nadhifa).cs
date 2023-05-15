using System;
using System.Collections.Generic;

public class Pemasukan
{
    public string Deskripsi { get; set; }
    public double JumlahUang { get; set; }
    public string Kategori { get; set; }
}

public class KategoriPemasukanTable
{
    private readonly List<Tuple<double, string>> _table;

    public KategoriPemasukanTable()
    {
        _table = new List<Tuple<double, string>>()
        {
            new Tuple<double, string>(2000000, "Rendah"),
            new Tuple<double, string>(5000000, "Menengah"),
            new Tuple<double, string>(10000000, "RataRata")
        };
    }

    public string GetKategori(double jumlahUang)
    {
        string kategori = "RataRata";

        foreach (var item in _table)
        {
            if (jumlahUang < item.Item1)
            {
                kategori = item.Item2;
                break;
            }
        }

        return kategori;
    }
}

public class MoneyManagerr
{
    private readonly KategoriPemasukanTable _kategoriPemasukanTable;

    private readonly Dictionary<string, Action<Pemasukan>> _stateTransitions;

    private readonly Action<Pemasukan> _defaultStateTransition;

    public MoneyManagerr()
    {
        _kategoriPemasukanTable = new KategoriPemasukanTable();

        _stateTransitions = new Dictionary<string, Action<Pemasukan>>()
        {
            { "Rendah", PrintRendah },
            { "Menengah", PrintMenengah },
            { "RataRata", PrintRataRata }
        };

        _defaultStateTransition = PrintRataRata;
    }

    public void CetakKategoriPemasukan(Pemasukan pemasukan)
    {
        string kategori = _kategoriPemasukanTable.GetKategori(pemasukan.JumlahUang);

        _stateTransitions.TryGetValue(kategori, out Action<Pemasukan> transition);

        transition?.Invoke(pemasukan);
    }

    private void PrintRendah(Pemasukan pemasukan)
    {
        Console.WriteLine($"Deskripsi: {pemasukan.Deskripsi}");
        Console.WriteLine($"Harga: {pemasukan.JumlahUang}");
    }

    private void PrintMenengah(Pemasukan pemasukan)
    {
        Console.WriteLine($"Deskripsi: {pemasukan.Deskripsi}");
        Console.WriteLine($"Harga: {pemasukan.JumlahUang}");
        
    }

    private void PrintRataRata(Pemasukan pemasukan)
    {
        Console.WriteLine($"Deskripsi: {pemasukan.Deskripsi}");
        Console.WriteLine($"Harga: {pemasukan.JumlahUang}");
        
    }
}
