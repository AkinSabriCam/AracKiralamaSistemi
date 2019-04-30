using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class AracDTO
    {
        public int aracID { get; set; }
        public Nullable<int> sirketID { get; set; }
        public string sirketAdi { get; set;}
        public string marka { get; set; }
        public string model { get; set; }
        public Nullable<int> yasSiniri { get; set; }
        public Nullable<int> ehliyetYasi { get; set; }
        public Nullable<int> gunlukKm { get; set; }
        public Nullable<long> KM { get; set; }
        public Nullable<bool> airbag { get; set; }
        public Nullable<int> bagajHacmi { get; set; }
        public Nullable<int> koltukSayisi { get; set; }
        public Nullable<decimal> gunlukFiyat { get; set; }
    }
}
