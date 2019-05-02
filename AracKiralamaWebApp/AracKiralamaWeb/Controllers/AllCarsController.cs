using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{ [Authorize(Roles ="Yonetici")]
    public class AllCarsController : Controller
    {
        // GET: AllCars
        public ActionResult Index()
        {
            AracKiralamaWebService.AracWebService aracWebService = new AracKiralamaWebService.AracWebService();
            var model = aracWebService.GetAllCars(Convert.ToInt16(Session["sirketId"]));
            return View(model);
        }
        public ActionResult NewCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCar(Arac arac)
        {
            
            arac.sirketID = Convert.ToInt16(Session["sirketId"].ToString());
            AracWebService aracWebService = new AracWebService();
            aracWebService.Add(arac);
            return RedirectToAction("Index");
        }


        public ActionResult Update(int id)
        {
            AracWebService aracWebService = new AracWebService();
            var model=aracWebService.GetCarById(id);

            return View(model);
        }

        public ActionResult UpdateCar(Arac arac)
        {
            AracWebService aracWebService = new AracWebService();
            aracWebService.Update(arac);
            return RedirectToAction("Index");
        }
            
    }
}