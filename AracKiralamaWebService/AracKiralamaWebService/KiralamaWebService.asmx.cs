using Business.BLLs;
using Model.DTOs;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AracKiralamaWebService
{
    /// <summary>
    /// Summary description for KiralamaWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KiralamaWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<KiralikAracDTO> Get(int sirketId)
        {
            KiralamaBLL kiralamaBusiness = new KiralamaBLL();
            var model = kiralamaBusiness.Get(sirketId);
            return model;
        }

        [WebMethod]
        public KiralikAracDTO GetById(int id)
        {
            KiralamaBLL kiralamaBusiness = new KiralamaBLL();
            var model = kiralamaBusiness.GetById(id);
            return model;
        }

        [WebMethod]
        public void Add(DateTime baslangic,DateTime bitis,int aracid,MusteriBilgileri model)
        { 
            // bu ekleme metodu istek olmadan yapılmış eklemeler için kullanılmaktadır.

            MusteriWebService musteriWebService = new MusteriWebService();
            musteriWebService.Add(model); // musteri web servisini kullanarak müşteriyi ekledik

            AracWebService aracWebService = new AracWebService();
            var arac = aracWebService.GetCarById(aracid); // arac web servisini kullanarak aracı aldık

            TimeSpan fark = (bitis - baslangic); // farkı bulduk

            KiralamaBLL kiralamaBusiness = new KiralamaBLL(); // kiralama business layerinı instance ederek işlemi yaptık
            KiralikAraclar kiralamaEntity = new KiralikAraclar(); // ilgili entity'i oluşturduk
            kiralamaEntity.aracID = aracid;
            kiralamaEntity.baslangicTarihi = baslangic;
            kiralamaEntity.bitisTarihi = bitis;
            kiralamaEntity.durum = true;
            kiralamaEntity.musteriID = model.musteriID;
            kiralamaEntity.kiralamaUcreti = arac.gunlukFiyat * ((decimal)fark.TotalDays);

            kiralamaBusiness.Add(kiralamaEntity); // ilgili entity'i ekledik

            IstekWebService istekWebService = new IstekWebService();
            istekWebService.Update(aracid, baslangic, bitis);

        }

        [WebMethod]
        public void Add(int musteriId,int aracid,DateTime baslangic,DateTime bitis)
        {
            KiralamaBLL kiralamaBusiness = new KiralamaBLL();

            AracWebService aracWebService = new AracWebService();
            var arac=aracWebService.GetCarById(aracid);

            KiralikAraclar kiralikentity = new KiralikAraclar();
            kiralikentity.aracID = aracid;
            kiralikentity.musteriID = musteriId;
            kiralikentity.durum = true;
            kiralikentity.baslangicTarihi = baslangic;
            kiralikentity.bitisTarihi = bitis;

            TimeSpan fark = (bitis - baslangic);
            kiralikentity.kiralamaUcreti = arac.gunlukFiyat * ((decimal)fark.TotalDays);

            kiralamaBusiness.Add(kiralikentity);
            IstekWebService istekWebService = new IstekWebService();
            istekWebService.Update(aracid, baslangic, bitis);

        }
    }
}
