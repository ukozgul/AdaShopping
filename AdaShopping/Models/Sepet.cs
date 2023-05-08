using System.Text.Json.Serialization;

namespace AdaShopping.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        [JsonIgnore]
        public Musteri Musteri { get; set; }
        public List<SepetUrun> SepetUrun { get; set; }


    }
}

/*
Sepet tablosu
----------
Id (int)
MusteriId(int)
*/