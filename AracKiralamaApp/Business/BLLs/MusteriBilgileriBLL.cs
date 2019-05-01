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
    public class MusteriBilgileriBLL
    {
        public void Add(MusteriBilgileri model)
        {
            using (MusteriRepository musteriRepo = new MusteriRepository())
            {
                try
                {
                    musteriRepo.Add(model);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public List<MusteriBilgileriDTO> Get()
        {
            using(MusteriRepository musteriRepo = new MusteriRepository())
            {
                try
                {
                    var Musteriler = new List<MusteriBilgileriDTO>();
                    var model = musteriRepo.Get();
                    foreach (var ent in model.ToList())
                    {
                        var musteridto = new MusteriBilgileriDTO();
                        musteridto.acikAdres = ent.acikAdres;
                        musteridto.adi = ent.adi;
                        musteridto.cinsiyet = ent.cinsiyet;
                        musteridto.dogumTarihi = ent.dogumTarihi;
                        musteridto.ehliyetTarihi = ent.ehliyetTarihi;
                        musteridto.ilID = ent.ilID;
                        musteridto.musteriID = ent.musteriID;
                        musteridto.Sehir = ent.İl.ilAdi;
                        musteridto.soyadi = ent.soyadi;
                        musteridto.telNo = ent.telNo;

                        Musteriler.Add(musteridto);
                    }
                    return Musteriler;
                }
                catch(Exception ex)
                {
                    throw;
                }
                
            }
        }

        public  MusteriBilgileriDTO GetById(int id)
        {
            using (MusteriRepository musteriRepo = new MusteriRepository())
            {
                try
                {
                    var ent = musteriRepo.GetById(id);
                    
                        var musteridto = new MusteriBilgileriDTO();
                        musteridto.acikAdres = ent.acikAdres;
                        musteridto.adi = ent.adi;
                        musteridto.cinsiyet = ent.cinsiyet;
                        musteridto.dogumTarihi = ent.dogumTarihi;
                        musteridto.ehliyetTarihi = ent.ehliyetTarihi;
                        musteridto.ilID = ent.ilID;
                        musteridto.musteriID = ent.musteriID;
                        musteridto.Sehir = ent.İl.ilAdi;
                        musteridto.soyadi = ent.soyadi;
                        musteridto.telNo = ent.telNo;
                    
                    return musteridto;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }



    }
}
