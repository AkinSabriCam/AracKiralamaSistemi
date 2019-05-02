using AracKiralamaWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{ [Authorize (Roles ="Yonetici,Calisan")]
    public class KiralanmisAraclarController : Controller
    {
        // GET: KiralanmisAraclar
        public ActionResult Index()
        {
            KiralamaWebService kiralamaWebService = new KiralamaWebService();
            var model = kiralamaWebService.Get(Convert.ToInt16(Session["sirketId"]));
            return View(model);
        }
    }
}