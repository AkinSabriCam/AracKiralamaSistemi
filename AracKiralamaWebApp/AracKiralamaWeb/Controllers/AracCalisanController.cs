using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{
    public class AracCalisanController : Controller
    {
        // GET: AracCalisan
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult GetCar(DateTime baslangic,DateTime bitis)
        {

            using (AracKiralamaWebService.AracWebService aracWebService = new AracKiralamaWebService.AracWebService())
            {
                Session["baslangic"] = baslangic;
                Session["bitis"] = bitis;
                var model = aracWebService.GetForCustomers(baslangic,bitis);
                return View(model);
            }

        }

        public ActionResult Kirala(int id)
        {
            using (AracKiralamaWebService.AracWebService aracWebService = new AracKiralamaWebService.AracWebService())
            {

                var model = aracWebService.GetCarById(id);
                return View(model);
            }
            
        }
        [HttpPost]
        public ActionResult KiralamaIslemi(int aracid,MusteriBilgileri model)
        {
            KiralamaWebService kiralamaWebService = new KiralamaWebService();
            kiralamaWebService.Add(Convert.ToDateTime(Session["baslangic"]), Convert.ToDateTime(Session["baslangic"]),
                aracid, model);

            return RedirectToAction("Index");
        }
    }
}