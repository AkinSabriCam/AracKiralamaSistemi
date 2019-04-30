using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DTOs;
using System.Web.Services;
using AracKiralamaWebService;

namespace AracKiralamaWebApp.Controllers
{
    public class SirketController : Controller
    {
        // GET: Sirket
        public ActionResult Index()
        {
            using(var sirketWebService = new SirketWebService())
            {
                var model = sirketWebService.Get();
                return View(model);

            }
        }
    }
}