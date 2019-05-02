using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class KiralikAracDTO
    {
        public int kiralikaraclarID { get; set; }
        public int musteriID { get; set; }

        public string musteriAdi   { get; set; }
        public string musteriSoyad { get; set; }
        public string telNo { get; set; }

        public string Marka { get; set; }
        public string Model { get; set; }
        public string  SirketAdi { get; set; }
        public int aracID { get; set; }
        public Nullable<System.DateTime> baslangicTarihi { get; set; }
        public Nullable<System.DateTime> bitisTarihi { get; set; }
        public Nullable<decimal> kiralamaUcreti { get; set; }
        public Nullable<bool> durum { get; set; }

    }
}
