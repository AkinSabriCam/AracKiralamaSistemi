using Business.BLLs;
using BusinessLayerLogic.BLLs;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AracKiralamaWebService
{
    /// <summary>
    /// Summary description for AracWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AracWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<AracDTO> GetForCustomers(DateTime baslangic,DateTime bitis)
        {
            AracBLL aracbll = new AracBLL();
            
            return aracbll.GetCarsForCustomer(baslangic,bitis);
        }

        public AracDTO GetCarById(int id)
        {
            AracBLL aracbll = new AracBLL();

            return aracbll.GetById(id);
        }


    }
}
