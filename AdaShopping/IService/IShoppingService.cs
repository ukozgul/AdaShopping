using AdaShopping.Dtos;
using AdaShopping.Models;

namespace AdaShopping.IService
{
    public interface IShoppingService
    {
        //Müşteri Ekle
        void AddMusteri(int musteriAdet, int sepetAdet);

        //Sepet Ekle
        void AddSepet(List<int> musteriListesi, int sepetAdet);

        //SepetUrun Ekle
        void AddSepetUrun(List<int> sepetListesi);

        //MüşteriLeri Getir
        IEnumerable<Musteri> GetAllMusteri();

        //Tek Müsteri Getir
        Musteri GetMusteri(int id);

        //Sepetleri Getir
        IEnumerable<Sepet> GetAllSepet();

        //Tek Sepet Getir
        Sepet GetSepet(int id);

        //Sehir Bazlı Analiz
        List<DtoSehirAnaliz> GetAnaliz();

        


    }
}
