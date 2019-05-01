using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class MusteriBilgileriDTO
    {
        public int musteriID { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public Nullable<bool> cinsiyet { get; set; }
        public string telNo { get; set; }
        public Nullable<int> ilID { get; set; }
        public string Sehir { get; set; }
        public string acikAdres { get; set; }
        public Nullable<System.DateTime> dogumTarihi { get; set; }
        public Nullable<System.DateTime> ehliyetTarihi { get; set; }
    }
}
