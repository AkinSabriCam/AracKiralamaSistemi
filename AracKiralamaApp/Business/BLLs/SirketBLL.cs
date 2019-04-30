using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concretes;
using Model.DTOs;
using Model.Models;
namespace BusinessLayerLogic.BLLs
{
    public class SirketBLL
    {
        SirketRepository sirketRepo = new SirketRepository();

        public List<SirketDTO> Get()
        {
            var models = sirketRepo.Get();
            
            List<SirketDTO> Sirketler = new List<SirketDTO>();
            foreach (var entity in models.ToList())
            {
                SirketDTO sirketdto = new SirketDTO();
                sirketdto.sirketAdi = entity.sirketAdi;
                sirketdto.sirketID = entity.sirketID;
                sirketdto.sirketPuani = entity.sirketPuani;
                sirketdto.Sehir = entity.İl.ilAdi;
                sirketdto.acikAdres = entity.acikAdres;
                sirketdto.aracSayisi = entity.aracSayisi;
                foreach (var aracmodel in entity.Arac.ToList())
                {
                    var model = new Model.DTOs.AracDTO();
                    model.aracID = aracmodel.aracID;
                    model.bagajHacmi = aracmodel.bagajHacmi;
                    model.marka = aracmodel.marka;
                    model.model = aracmodel.model;
                    model.sirketAdi = aracmodel.Sirket.sirketAdi;
                    model.sirketID = aracmodel.sirketID;
                    model.yasSiniri = aracmodel.yasSiniri;
                    model.airbag = aracmodel.airbag;
                    model.ehliyetYasi = aracmodel.ehliyetYasi;
                    model.KM = aracmodel.KM;
                    model.gunlukKm = aracmodel.gunlukKm;
                    model.koltukSayisi = aracmodel.koltukSayisi;
                    model.gunlukFiyat = aracmodel.gunlukFiyat;
                    sirketdto.Araclar.Add(model);
                }
                foreach (var kullanicimodel in entity.Kullanici.ToList())
                {
                    var model = new Model.DTOs.KullaniciDTO();
                    model.adi = kullanicimodel.adi;
                    model.kullaniciID = kullanicimodel.kullaniciID;
                    model.password = kullanicimodel.password;
                    model.rolID = kullanicimodel.rolID;
                    model.rol = kullanicimodel.Rol.rol1;
                    model.sirketAdi = kullanicimodel.Sirket.sirketAdi;
                    model.sirketID = kullanicimodel.sirketID;
                    model.soyadi = kullanicimodel.soyadi;
                    model.username = kullanicimodel.username;

                    sirketdto.Kullanicilar.Add(model);
                }
                Sirketler.Add(sirketdto);


            }
            return Sirketler;
        }
        public Model.DTOs.SirketDTO GetById(int id)
        {
            var model =sirketRepo.GetById(id);
           
            var Sirket = new Model.DTOs.SirketDTO();
            Sirket.acikAdres = model.acikAdres;
            Sirket.aracSayisi = model.aracSayisi;
            Sirket.Sehir = model.İl.ilAdi;
            Sirket.sirketAdi = model.sirketAdi;
            Sirket.sirketID = model.sirketID;
            Sirket.sirketPuani = model.sirketPuani;
            foreach (var arac in model.Arac.ToList())
            {
                var aracmodel = new Model.DTOs.AracDTO();
                aracmodel.aracID = arac.aracID;
                aracmodel.bagajHacmi = arac.bagajHacmi;
                aracmodel.marka = arac.marka;
                aracmodel.model = arac.model;
                aracmodel.sirketAdi = arac.Sirket.sirketAdi;
                aracmodel.sirketID = arac.sirketID;
                aracmodel.yasSiniri = arac.yasSiniri;
                aracmodel.ehliyetYasi = arac.ehliyetYasi;
                aracmodel.KM = arac.KM;
                aracmodel.airbag = arac.airbag;
                aracmodel.gunlukKm = arac.gunlukKm;
                aracmodel.koltukSayisi = arac.koltukSayisi;
                aracmodel.gunlukFiyat = arac.gunlukFiyat;
                Sirket.Araclar.Add(aracmodel);
            }
            foreach (var kullanicimodel in model.Kullanici.ToList())
            {
                var kullanici = new Model.DTOs.KullaniciDTO();
                kullanici.adi = kullanicimodel.adi;
                kullanici.kullaniciID = kullanicimodel.kullaniciID;
                kullanici.password = kullanicimodel.password;
                kullanici.rolID = kullanicimodel.rolID;
                kullanici.rol = kullanicimodel.Rol.rol1;
                kullanici.sirketAdi = kullanicimodel.Sirket.sirketAdi;
                kullanici.sirketID = kullanicimodel.sirketID;
                kullanici.soyadi = kullanicimodel.soyadi;
                kullanici.username = kullanicimodel.username;

                Sirket.Kullanicilar.Add(kullanici);
            }
            return Sirket;
        }
    }
}
