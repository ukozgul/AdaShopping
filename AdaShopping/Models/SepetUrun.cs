using System.Text.Json.Serialization;

namespace AdaShopping.Models
{
    public class SepetUrun
    {
        public int Id { get; set; }
        public int SepetId { get; set; }
        public int Tutar { get; set; }
        public string Aciklama { get; set; }=string.Empty;
        [JsonIgnore]
        public Sepet Sepet { get; set; }

    }
}

//SepetUrun tablosu
//--------------
//Id(int)
//SepetId(int)
//Tutar(numeric)
//Aciklama(varchar)