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
    public class AracBLL
    {
        public List<AracDTO> GetAllCars(int sirketId)
        {
            using (AracRepository aracRepository = new AracRepository())
            {
                List<AracDTO> Araclar = new List<AracDTO>();

                var model = aracRepository.Get();
                foreach (var entity in model.ToList())
                {
                    if (entity.sirketID == sirketId)
                    {


                        var aracdto = new AracDTO();
                        aracdto.airbag = entity.airbag;
                        aracdto.aracID = entity.aracID;
                        aracdto.bagajHacmi = entity.bagajHacmi;
                        aracdto.ehliyetYasi = entity.ehliyetYasi;
                        aracdto.gunlukFiyat = entity.gunlukFiyat;
                        aracdto.gunlukKm = entity.gunlukKm;
                        aracdto.KM = entity.KM;
                        aracdto.koltukSayisi = entity.koltukSayisi;
                        aracdto.marka = entity.marka;
                        aracdto.model = entity.model;
                        aracdto.sirketAdi = entity.Sirket.sirketAdi;
                        aracdto.sirketID = entity.sirketID;
                        aracdto.yasSiniri = entity.yasSiniri;
                        Araclar.Add(aracdto);
                    }
                }
                return Araclar;
            }
        }
        public List<AracDTO> GetForUsers(DateTime baslangic, DateTime bitis,int sirketId)
        {

            using (AracRepository aracRepository = new AracRepository())
            {
                List<AracDTO> Araclar = new List<AracDTO>();

                var model = aracRepository.Get().Where(x=>x.sirketID==sirketId);// tüm araçları aldık

                var kiralikaracRepo = new KiralikAracRepository();
                var kiralikmodels = kiralikaracRepo.Get().Where(x=>x.Arac.sirketID==sirketId);
                

                foreach (var entity in model)
                {
                    
                        var test =
                   kiralikmodels.Where
                 (x => x.aracID == entity.aracID && (x.bitisTarihi > baslangic || x.bitisTarihi == baslangic) && x.baslangicTarihi < bitis).ToList();
                        if (test.Count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            var aracdto = new AracDTO();
                            aracdto.airbag = entity.airbag;
                            aracdto.aracID = entity.aracID;
                            aracdto.bagajHacmi = entity.bagajHacmi;
                            aracdto.ehliyetYasi = entity.ehliyetYasi;
                            aracdto.gunlukFiyat = entity.gunlukFiyat;
                            aracdto.gunlukKm = entity.gunlukKm;
                            aracdto.KM = entity.KM;
                            aracdto.koltukSayisi = entity.koltukSayisi;
                            aracdto.marka = entity.marka;
                            aracdto.model = entity.model;
                            aracdto.sirketAdi = entity.Sirket.sirketAdi;
                            aracdto.sirketID = entity.sirketID;
                            aracdto.yasSiniri = entity.yasSiniri;
                            Araclar.Add(aracdto);
                        }
                    
                    
                }
                return Araclar;
            }
        }

        public List<AracDTO> GetCarsForCustomer(DateTime baslangic,DateTime bitis)
        {  
            
            using (AracRepository aracRepository = new AracRepository())
            {
                List<AracDTO> Araclar = new List<AracDTO>();

                var model = aracRepository.Get();// tüm araçları aldık

                var kiralikaracRepo = new KiralikAracRepository();
                var kiralikmodels = kiralikaracRepo.Get();


                foreach (var entity in model.ToList())
                {
                    var test = 
                   kiralikmodels.Where(x => x.aracID == entity.aracID && (x.bitisTarihi>baslangic || x.bitisTarihi==baslangic) && x.baslangicTarihi<bitis).ToList();
                    if (test.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        var aracdto = new AracDTO();
                        aracdto.airbag = entity.airbag;
                        aracdto.aracID = entity.aracID;
                        aracdto.bagajHacmi = entity.bagajHacmi;
                        aracdto.ehliyetYasi = entity.ehliyetYasi;
                        aracdto.gunlukFiyat = entity.gunlukFiyat;
                        aracdto.gunlukKm = entity.gunlukKm;
                        aracdto.KM = entity.KM;
                        aracdto.koltukSayisi = entity.koltukSayisi;
                        aracdto.marka = entity.marka;
                        aracdto.model = entity.model;
                        aracdto.sirketAdi = entity.Sirket.sirketAdi;
                        aracdto.sirketID = entity.sirketID;
                        aracdto.yasSiniri = entity.yasSiniri;
                        Araclar.Add(aracdto);
                    }
                    
                }
                return Araclar;
            }
        }

    


        public AracDTO GetById(int id)
        { 
            using (AracRepository aracRepo = new AracRepository())
            {
                try
                {
                    var entity = aracRepo.GetById(id);
                    var aracdto = new AracDTO();
                    aracdto.airbag = entity.airbag;
                    aracdto.aracID = entity.aracID;
                    aracdto.bagajHacmi = entity.bagajHacmi;
                    aracdto.ehliyetYasi = entity.ehliyetYasi;
                    aracdto.gunlukFiyat = entity.gunlukFiyat;
                    aracdto.gunlukKm = entity.gunlukKm;
                    aracdto.KM = entity.KM;
                    aracdto.koltukSayisi = entity.koltukSayisi;
                    aracdto.marka = entity.marka;
                    aracdto.model = entity.model;
                    aracdto.sirketAdi = entity.Sirket.sirketAdi;
                    aracdto.sirketID = entity.sirketID;
                    aracdto.yasSiniri = entity.yasSiniri;

                    return aracdto;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }


        public bool Add(Arac model)
        {
            using (AracRepository aracRepo = new AracRepository())
            {
                try
                {
                    if (aracRepo.Add(model))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        public void Update(Arac model)
        {
            using(AracRepository aracRepo = new AracRepository())
            {
                try
                {
                    aracRepo.Update(model);
                }
                catch(Exception ex)
                {
                    throw;
                }

            }

        }

        public void Delete(int id)
        {
            using(AracRepository aracRepo= new AracRepository())
            {
                try
                {
                    aracRepo.Delete(id);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
