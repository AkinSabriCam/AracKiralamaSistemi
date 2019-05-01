using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{
    public class SirketController : Controller
    {
        // GET: Sirket
        public ActionResult Index()
        {
            AracKiralamaWebService.SirketWebService sirketWebService = new AracKiralamaWebService.SirketWebService();
            var model=sirketWebService.Get();
            return View(model);
        }
    }
}