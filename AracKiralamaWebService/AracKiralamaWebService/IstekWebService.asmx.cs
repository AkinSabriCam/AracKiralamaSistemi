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
    /// Summary description for IstekWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IstekWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<IstekDTO> GetAll(int sirketId)
        { IstekBLL istekBusiness = new IstekBLL();
            return istekBusiness.GetAll(sirketId);

        }
        public IstekDTO GetById(int id)
        {
            IstekBLL istekBusiness = new IstekBLL();
                return istekBusiness.GetById(id);
        }

        public void Post(DateTime baslangic,DateTime bitis,MusteriBilgileri model,int aracid)
        {
            MusteriWebService musteriWebService = new MusteriWebService();
            musteriWebService.Add(model);

            Istek istek = new Istek();
            istek.baslangicTarihi = baslangic;
            istek.bitisTarihi = bitis;
            istek.aracID = aracid;
            istek.musteriID = model.musteriID;
            istek.durum = true;

            IstekBLL istekBusiness = new IstekBLL();
            istekBusiness.Add(istek);

        }

        public void Update(int aracid,DateTime baslangic,DateTime bitis)
        {
            IstekBLL istekBusiness = new IstekBLL();
            istekBusiness.Update(aracid,baslangic,bitis);
        }

        public void Accepted(int istekid)
        {
            var model = GetById(istekid);

            KiralamaWebService kiralamaWebService = new KiralamaWebService();

            kiralamaWebService.Add(model.musteriID, model.aracID, Convert.ToDateTime(model.baslangicTarihi), Convert.ToDateTime(model.bitisTarihi));

            Update(model.aracID, Convert.ToDateTime(model.baslangicTarihi), Convert.ToDateTime(model.bitisTarihi));
        }
    }
}
