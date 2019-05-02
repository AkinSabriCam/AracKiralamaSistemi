using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{ [Authorize (Roles ="Yonetici")]
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        public ActionResult Index()
        {
            KullaniciWebService kulaniciWebService = new KullaniciWebService();
            var model = kulaniciWebService.Get(Convert.ToInt16(Session["sirketId"]));
            return View(model);
        }

        public ActionResult YeniCalisan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalisanEkle(Kullanici kullanici)
        {
            
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            kullanici.rolID = 1;
            kullanici.sirketID = Convert.ToInt16(Session["sirketId"].ToString());
            kullaniciWebService.Add(kullanici);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            kullaniciWebService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}