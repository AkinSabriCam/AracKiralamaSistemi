using Core.DBHelper;
using DAL.Abstractions;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concretes
{
    public class MusteriRepository : IRepository<MusteriBilgileri>,IDisposable
    {
        public bool Add(MusteriBilgileri model)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    Musteri musterimodel = new Musteri();
                    musterimodel.username = "musteri";
                    musterimodel.password = "123";
                    dbContext.Set<Musteri>().Add(musterimodel);
                    dbContext.SaveChanges();

                    model.musteriID = musterimodel.musteriID;
                    dbContext.Set<MusteriBilgileri>().Add(model);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<MusteriBilgileri> Get()
        {
            using (DBContext  dbContext= new DBContext())
            {
                try
                {
                    DbSet<MusteriBilgileri> Table = dbContext.Set<MusteriBilgileri>();
                    return Table.Include(x=>x.İl).Include(x=>x.Musteri).ToList();
                }
                catch(Exception ex)
                {
                    throw;
                }

            }


        }

        public MusteriBilgileri GetById(int id)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<MusteriBilgileri> Table = dbContext.Set<MusteriBilgileri>();
                    return Table.Include(x => x.İl).Include(x => x.Musteri).FirstOrDefault(x => x.musteriID == id);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            
        }

        public bool Update(MusteriBilgileri model)
        {
            throw new NotImplementedException();
        }
    }
}
