using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            var sifre = Encrypt(kullanici.password);
            kullanici.password = sifre;
            kullaniciWebService.Add(kullanici);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            kullaniciWebService.Delete(id);
            return RedirectToAction("Index");

        }

        private string Encrypt(string clearText)
        {  //Gönderilen şifrenin kodlanması yani şifrelenmesi için bu metod kullanılır
            //Kodlanan şifre geri döndürülür
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