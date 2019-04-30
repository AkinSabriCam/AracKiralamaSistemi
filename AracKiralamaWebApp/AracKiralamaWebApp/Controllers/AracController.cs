using AracKiralamaWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWebApp.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {
            using (AracWebService aracwebService = new AracWebService())
            {
               var model= aracwebService.Get();
                return View(model);

            }

        }
    }
}