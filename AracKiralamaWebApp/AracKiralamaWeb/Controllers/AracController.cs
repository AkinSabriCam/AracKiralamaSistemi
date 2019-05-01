using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{
    public class AracController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCar(DateTime baslangic,DateTime bitis)
        {
            Session["baslangic"] = baslangic;
            Session["bitis"] = bitis;
            AracKiralamaWebService.AracWebService aracWebService = new AracKiralamaWebService.AracWebService();
            var model = aracWebService.GetForCustomers(baslangic,bitis);
            return View(model);
        }
        public ActionResult Istek(int id)
        {
            AracKiralamaWebService.AracWebService aracWebService = new AracKiralamaWebService.AracWebService();

            var model=aracWebService.GetCarById(id);
            return View(model); 
            
        }
        public ActionResult IstekOlustur(MusteriBilgileri model,int aracid)
        {
            IstekWebService istekWebService = new IstekWebService();
            istekWebService.Post(Convert.ToDateTime(Session["baslangic"]), Convert.ToDateTime(Session["bitis"]),
                model, aracid);

            return RedirectToAction("Index");
        }
    }
}