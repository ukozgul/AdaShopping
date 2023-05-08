using AdaShopping.Data;
using AdaShopping.Dtos;
using AdaShopping.IService;
using AdaShopping.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace AdaShopping.Service
{
    public class ShoppingService : IShoppingService
    {
        private readonly AdaDbContext _db;

        public ShoppingService(AdaDbContext db)
        {
            _db = db;
        }

        //Müşteri Ekle
        public void AddMusteri(int musteriAdet, int sepetAdet)
        {

            var musteriListesi = new List<int>();
            for (int i = 0; i < musteriAdet; i++)
            {

                var rnd = new Random();
                string[] sehirler = { "Ankara", "İstanbul", "İzmir", "Bursa",
                "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };

                int sIndex = rnd.Next(sehirler.Length);

                var musteri = new Musteri
                {
                    Ad = RMetot(5),
                    Soyad = RMetot(5),
                    Sehir = sehirler[sIndex]
                };

                _db.Musteriler.Add(musteri);

                _db.SaveChanges();
                musteriListesi.Add(musteri.Id);
            }
            AddSepet(musteriListesi, sepetAdet);


        }

        //Sepet Ekle
        public void AddSepet(List<int> musteriListesi, int sepetAdet)
        {

            Random random = new Random();
            var sepetListesi = new List<int>();

            for (int i = 0; i < sepetAdet; i++)
            {

                int randomIndex = random.Next(musteriListesi.Count);
                int randomElement = musteriListesi[randomIndex];

                var sepet = new Sepet
                {
                    MusteriId = randomElement
                };

                _db.Sepetler.Add(sepet);
                _db.SaveChanges();
                sepetListesi.Add(sepet.Id);
            }

            AddSepetUrun(sepetListesi);
        }


        //SepetUrun Ekle
        public void AddSepetUrun(List<int> sepetListesi)
        {

            Random rnd = new Random();

            for (int j = 0; j < sepetListesi.Count; j++)
            {
                var randomIndex = rnd.Next(1, 6);

                for (int i = 0; i < randomIndex; i++)
                {

                    var sepetUrun = new SepetUrun
                    {
                        SepetId = sepetListesi[j],
                        Tutar = rnd.Next(10, 1000),
                        Aciklama = RMetot(10)

                    };
                    _db.SepetUrunler.Add(sepetUrun);
                    _db.SaveChanges();

                }
            }

        }

        //Müşterileri Getir
        public IEnumerable<Musteri> GetAllMusteri()
        {
            var result = _db.Musteriler;
            return result;
        }

        //Sepetleri Getir
        public IEnumerable<Sepet> GetAllSepet()
        {
            var result = _db.Sepetler;
            return result;
        }

        public List<DtoSehirAnaliz> GetAnaliz()
        {

            var sehirAnalizleri = _db.Musteriler
             .Join(_db.Sepetler,
                    m => m.Id,
                    s => s.MusteriId,
                   (m, s) => new { Musteri = m, Sepet = s })
           .Join(_db.SepetUrunler,
                    ms => ms.Sepet.Id,
                   su => su.SepetId, (ms, su) => new { ms.Musteri.Sehir, su.Tutar })
           .GroupBy(x => x.Sehir)
           .Select(g => new DtoSehirAnaliz
           {
               SehirAdi = g.Key,
               SepetAdet = g.Count(),
               ToplamTutar = g.Sum(x => x.Tutar)
           })
           .OrderByDescending(x => x.SepetAdet)
           .ToList();

            return sehirAnalizleri;


        }

        //Tek Müşteri Getir
        public Musteri GetMusteri(int id)
        {
            var result = _db.Musteriler.Find(id);
            return result;
        }

        //Tek Sepet Getir
        public Sepet GetSepet(int id)
        {
            var result = _db.Sepetler.Find(id);
            return result;
        }

        private string RMetot(int a)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder nameBuilder = new StringBuilder();

            for (int i = 0; i < a; i++)
            {
                nameBuilder.Append(chars[random.Next(chars.Length)]);
            }

            string name = nameBuilder.ToString();
            return name;
        }

    }


}
