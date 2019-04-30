using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace Model.DTOs
{
    public class SirketDTO
    {
        public int sirketID { get; set; }
        public string sirketAdi { get; set; }
        public Nullable<int> aracSayisi { get; set; }
        public Nullable<int> sirketPuani { get; set; }
        public string Sehir { get; set; }
        public string acikAdres { get; set; }

        public List<Model.DTOs.AracDTO> Araclar { get; set; }
        public List<Model.DTOs.KullaniciDTO> Kullanicilar { get; set; }

        public SirketDTO()
        {
            this.Araclar = new List<AracDTO>();
            this.Kullanicilar = new List<KullaniciDTO>();
        }
    }
}
