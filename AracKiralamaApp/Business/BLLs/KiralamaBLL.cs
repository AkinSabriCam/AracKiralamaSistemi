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
    public class KiralamaBLL
    {
        public List<KiralikAracDTO> Get(int sirketId)
        {
            using (KiralikAracRepository kiralikAracRepo = new KiralikAracRepository())
            {
                try
                {
                    var KiralikAraclar = new List<KiralikAracDTO>();
                    var model = kiralikAracRepo.Get().Where(x=>x.Arac.sirketID==sirketId);
                    foreach (var ent in model.ToList())
                    {
                        var kiralikdto = new KiralikAracDTO();
                        kiralikdto.aracID = ent.aracID;
                        kiralikdto.baslangicTarihi = ent.baslangicTarihi;
                        kiralikdto.bitisTarihi = ent.bitisTarihi;
                        kiralikdto.durum = ent.durum;
                        kiralikdto.kiralamaUcreti = ent.kiralamaUcreti;
                        kiralikdto.kiralikaraclarID = ent.kiralikaraclarID;
                        kiralikdto.Marka = ent.Arac.marka;
                        kiralikdto.Model = ent.Arac.model;
                        kiralikdto.musteriAdi = ent.Musteri.MusteriBilgileri.adi;
                        kiralikdto.musteriID = ent.musteriID;
                        kiralikdto.musteriSoyad = ent.Musteri.MusteriBilgileri.soyadi;
                        kiralikdto.telNo = ent.Musteri.MusteriBilgileri.telNo;
                        kiralikdto.SirketAdi = ent.Arac.Sirket.sirketAdi;
                        KiralikAraclar.Add(kiralikdto);
                    }
                    return KiralikAraclar;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public KiralikAracDTO GetById(int id)
        {

            using (KiralikAracRepository kiralikRepo = new KiralikAracRepository())
            {
                try
                {
                    var ent = kiralikRepo.GetById(id);
                    var kiralikdto = new KiralikAracDTO();
                        kiralikdto.aracID = ent.aracID;
                        kiralikdto.baslangicTarihi = ent.baslangicTarihi;
                        kiralikdto.bitisTarihi = ent.bitisTarihi;
                        kiralikdto.durum = ent.durum;
                        kiralikdto.kiralamaUcreti = ent.kiralamaUcreti;
                        kiralikdto.kiralikaraclarID = ent.kiralikaraclarID;
                        kiralikdto.Marka = ent.Arac.marka;
                        kiralikdto.Model = ent.Arac.model;
                        kiralikdto.musteriAdi = ent.Musteri.MusteriBilgileri.adi;
                        kiralikdto.musteriID = ent.musteriID;
                        kiralikdto.musteriSoyad = ent.Musteri.MusteriBilgileri.soyadi;
                        kiralikdto.telNo = ent.Musteri.MusteriBilgileri.telNo;
                        return kiralikdto;
                    
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        
        }


        public bool Add(KiralikAraclar model)
        {
            using(KiralikAracRepository kiralikRepo = new KiralikAracRepository())
            {
                try
                {
                    kiralikRepo.Add(model);
                    return  true;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public void Update()
        {
            using (KiralikAracRepository kiralikRepo = new KiralikAracRepository())
            {
                var model = kiralikRepo.Get();
                var tarih = DateTime.Now;

                var GuncellenecekModeller = model.Where(x => x.bitisTarihi < tarih && x.durum==true).ToList();
                foreach(var ent in GuncellenecekModeller)
                {
                    kiralikRepo.Update(ent);
                }

            }
        }

    }
}
