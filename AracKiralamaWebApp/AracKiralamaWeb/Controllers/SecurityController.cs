using AracKiralamaWebService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            password = Encrypt(password);
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

        private string Encrypt(string clearText)
        {  // kullanıcı şifresinin kodlanarak şifrelendiği metotdur.
            // şifreyi kodlanmış  şekilde geri döndürür.
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}