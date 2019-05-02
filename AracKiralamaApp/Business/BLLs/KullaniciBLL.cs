using DAL.Concretes;
using Model.DTOs;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLLs
{
    public class KullaniciBLL
    {
        public List<KullaniciDTO> Get(int sirketId)
        {
            using (KullaniciRepository kullaniciRepo = new KullaniciRepository())
            {
                try
                {
                    var model = kullaniciRepo.Get();
                    var Kullanicilar = new List<KullaniciDTO>();
                    foreach(var ent in model.ToList())
                    {
                        if (ent.rolID == 1 && ent.sirketID==sirketId)
                        {
                            var kullanicidto = new KullaniciDTO();
                            kullanicidto.adi = ent.adi;
                            kullanicidto.kullaniciID = ent.kullaniciID;
                            kullanicidto.password = ent.password;
                            kullanicidto.rol = ent.Rol.rol1;
                            kullanicidto.rolID = ent.rolID;
                            kullanicidto.sirketAdi = ent.Sirket.sirketAdi;
                            kullanicidto.sirketID = ent.sirketID;
                            kullanicidto.soyadi = ent.soyadi;
                            kullanicidto.username = ent.username;

                            Kullanicilar.Add(kullanicidto);
                        }
                    }
                    return Kullanicilar;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
        public KullaniciDTO GetById(int id)
        {
            using(KullaniciRepository kullaniciRepo = new KullaniciRepository())
            {
                try
                {
                    var ent=kullaniciRepo.GetById(id);
                    var kullanicidto = new KullaniciDTO();

                    kullanicidto.adi = ent.adi;
                    kullanicidto.kullaniciID = ent.kullaniciID;
                    kullanicidto.password = ent.password;
                    kullanicidto.rol = ent.Rol.rol1;
                    kullanicidto.rolID = ent.rolID;
                    kullanicidto.sirketAdi = ent.Sirket.sirketAdi;
                    kullanicidto.sirketID = ent.sirketID;
                    kullanicidto.soyadi = ent.soyadi;
                    kullanicidto.username = ent.username;

                    return kullanicidto;
                }
                catch (Exception ex)
                {
                    throw;
                } 
            }
        }
        public void Add(Kullanici model)
        {
            using (KullaniciRepository kullaniciRepo= new KullaniciRepository())
            {
                try
                {  
                    kullaniciRepo.Add(model);
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }

        public void Delete (int id)
        {
            using (KullaniciRepository kullaniciRepo = new KullaniciRepository())
            {
                try
                {
                    kullaniciRepo.Delete(id);
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
        public KullaniciDTO GetByUsername(string username)
        {
            using(KullaniciRepository kullaniciRepo= new KullaniciRepository())
            {
                try
                {
                    var ent = kullaniciRepo.GetByUsername(username);
                    var kullanicidto = new KullaniciDTO();
                    kullanicidto.adi = ent.adi;
                    kullanicidto.kullaniciID = ent.kullaniciID;
                    kullanicidto.password = ent.password;
                    kullanicidto.rol = ent.Rol.rol1;
                    kullanicidto.rolID = ent.rolID;
                    kullanicidto.sirketAdi = ent.Sirket.sirketAdi;
                    kullanicidto.sirketID = ent.sirketID;
                    kullanicidto.soyadi = ent.soyadi;
                    kullanicidto.username = ent.username;
                    return kullanicidto;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public KullaniciDTO GetByUsernamePassword(string username,string password)
        {
            using (KullaniciRepository kullaniciRepo = new KullaniciRepository())
            {
                try
                {
                    var ent = kullaniciRepo.GetByUsernamePassword(username,password);
                    var kullanicidto = new KullaniciDTO();
                    kullanicidto.adi = ent.adi;
                    kullanicidto.kullaniciID = ent.kullaniciID;
                    kullanicidto.password = ent.password;
                    kullanicidto.rol = ent.Rol.rol1;
                    kullanicidto.rolID = ent.rolID;
                    kullanicidto.sirketAdi = ent.Sirket.sirketAdi;
                    kullanicidto.sirketID = ent.sirketID;
                    kullanicidto.soyadi = ent.soyadi;
                    kullanicidto.username = ent.username;
                    return kullanicidto;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
