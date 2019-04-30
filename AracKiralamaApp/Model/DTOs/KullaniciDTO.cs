using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class KullaniciDTO
    {
        public int kullaniciID { get; set; }
        public Nullable<int> sirketID { get; set; }
        public string sirketAdi { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public Nullable<int> rolID { get; set; }

        public string rol { get; set;}

    }

}
