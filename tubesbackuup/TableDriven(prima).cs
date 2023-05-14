using System;
using System.Collections.Generic;

public enum KategoriPembayaran
{
    Wifi,
    Listrik,
    GajiKaryawan
}

public class PaymentReminder
{
    public string Name { get; set; }
    public string Amount { get; set; }

    public PaymentReminder(string name, string amount)
    {
        Name = name;
        Amount = amount;
    }
}