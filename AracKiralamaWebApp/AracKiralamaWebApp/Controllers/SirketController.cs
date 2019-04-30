using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService;
using Model.DTOs;
namespace AracKiralamaWebApp.Controllers
{
    public class SirketController : Controller
    {
        // GET: Sirket
        public ActionResult Index()
        {
            using(WebService.SirketWebService sirketWebService = new SirketWebService())
            {
                var model = sirketWebService.HelloWorld();
                return View(model);

            }
        }
    }
}