using AracKiralamaWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracKiralamaWeb.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            var model=kullaniciWebService.GetByUsernamePassword(username, password);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.username, false);
                Session["sirketId"] = model.sirketID;
                Session["rolId"] = model.rolID;
                return RedirectToAction("Index", "AracCalisan");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["sirketId"] = null;
            Session["rolId"] = null;


            return View("Login");
        }
    }
}