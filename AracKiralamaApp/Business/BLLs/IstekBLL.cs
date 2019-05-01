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
    public class IstekBLL
    {
        public List<IstekDTO> GetAll()
        {
            using (IstekRepository istekRepository = new IstekRepository())
            {
                List<IstekDTO> Istekler = new List<IstekDTO>();

                var model = istekRepository.Get();
                foreach (var entity in model.ToList())
                {
                    var istekdto = new IstekDTO();
                    istekdto.aracID = entity.aracID;
                    istekdto.baslangicTarihi = entity.baslangicTarihi;
                    istekdto.bitisTarihi = entity.bitisTarihi;
                    istekdto.durum = entity.durum;
                    istekdto.istekID = entity.istekID;
                    istekdto.musteriID = entity.musteriID;
                    istekdto.aracMarka = entity.Arac.marka;
                    istekdto.aracModel = entity.Arac.model;
                    istekdto.musteriAdi = entity.Musteri.MusteriBilgileri.adi;
                    istekdto.musteriSoyadi = entity.Musteri.MusteriBilgileri.soyadi;
                    istekdto.telNo = entity.Musteri.MusteriBilgileri.telNo;
                    Istekler.Add(istekdto);
                }
                return Istekler;
            }
        }


        public bool Update(int aracid, DateTime baslangic, DateTime bitis)
        {
            using (IstekRepository istekRepository = new IstekRepository())
            {
                try
                {
                    var model = istekRepository.Get();

                    var Istekler = model.Where(x => x.aracID == aracid && (x.bitisTarihi >= baslangic && x.baslangicTarihi <= bitis)).ToList();

                    foreach (var ent in Istekler)
                    {
                        istekRepository.Update(ent);
                    }
                    return true;

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public void Add(Istek model)
        {
            using (IstekRepository istekRepo = new IstekRepository())
            {
                istekRepo.Add(model);
            }
        }
    }
}
