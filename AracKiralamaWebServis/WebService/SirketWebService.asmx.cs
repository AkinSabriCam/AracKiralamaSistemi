using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using BusinessLayerLogic.BLLs;
using Model.DTOs;
namespace WebService
{
    /// <summary>
    /// Summary description for SirketWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SirketWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<SirketDTO>  HelloWorld()
        {
            //BusinessLayerLogic.BLLs.SirketBLL sirketbll = new BusinessLayerLogic.BLLs.SirketBLL();
            SirketBLL sirket = new SirketBLL(); 
            return sirket.Get();
        }
    }
}
