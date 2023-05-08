using Microsoft.AspNetCore.DataProtection;

namespace AdaShopping.Models
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Sehir { get; set; } = string.Empty;
        public List<Sepet> Sepet { get; set; }
    }
}

/*
 Musteri tablosu
--------------
Id (int)
Ad (varchar)
Soyad (varchar)
Sehir (varchar)
 */