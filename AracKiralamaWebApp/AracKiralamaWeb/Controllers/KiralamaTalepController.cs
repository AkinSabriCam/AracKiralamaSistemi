using AracKiralamaWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{  [Authorize(Roles ="Yonetici,Calisan")]
    public class KiralamaTalepController : Controller
    {
        // GET: KiralamaTalep
        public ActionResult Index()
        {
            IstekWebService istekWebService = new IstekWebService();
            var model=istekWebService.GetAll(Convert.ToInt16(Session["sirketId"]));
            return View(model);
        }

        public ActionResult KiralamaOnay(int id)
        {
            IstekWebService istekWebService = new IstekWebService();
            istekWebService.Accepted(id);
            return RedirectToAction("Index");
        }
    }
}