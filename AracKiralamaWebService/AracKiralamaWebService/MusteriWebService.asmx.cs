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
    /// Summary description for MusteriWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MusteriWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<MusteriBilgileriDTO> Get()
        {
            MusteriBilgileriBLL musteriBLL = new MusteriBilgileriBLL();
            var model=musteriBLL.Get();
            return model;
        }

        [WebMethod]
        public MusteriBilgileriDTO GetById(int id)
        {
            MusteriBilgileriBLL musteriBLL = new MusteriBilgileriBLL();
            var model = musteriBLL.GetById(id);
            return model;
        }

        public void Add(MusteriBilgileri model)
        {
            MusteriBilgileriBLL musteriBLL = new MusteriBilgileriBLL();
            musteriBLL.Add(model);
        }

    }
}
