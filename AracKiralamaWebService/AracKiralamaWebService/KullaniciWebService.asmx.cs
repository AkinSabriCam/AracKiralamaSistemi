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
    /// Summary description for KullaniciWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KullaniciWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<KullaniciDTO> Get(int sirketId)
        {
            KullaniciBLL kullaniciBusiness = new KullaniciBLL();
            var model=kullaniciBusiness.Get(sirketId);

            return model;
        }

        public void Add(Kullanici model)
        {
            KullaniciBLL kullaniciBusiness = new KullaniciBLL();
            kullaniciBusiness.Add(model);
        }
        public void Delete (int id)
        {
            KullaniciBLL kullaniciBusiness = new KullaniciBLL();
            kullaniciBusiness.Delete(id);

        }
        public KullaniciDTO GetByUsername(string username)
        {
            KullaniciBLL kullaniciBusiness = new KullaniciBLL();
            var model=kullaniciBusiness.GetByUsername(username);
            return model;
        }

        public KullaniciDTO GetByUsernamePassword(string username, string password)
        {
            KullaniciBLL kullaniciBusiness = new KullaniciBLL();
            var model = kullaniciBusiness.GetByUsernamePassword(username,password);
            return model;
        }
    }
}
