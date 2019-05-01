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
    public class KiralikAracRepository : IRepository<Model.Models.KiralikAraclar>,IDisposable
    {
        public bool Add(KiralikAraclar model)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    dbContext.Set<KiralikAraclar>().Add(model);
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

        public List<KiralikAraclar> Get()
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<KiralikAraclar> Table = dbContext.Set<KiralikAraclar>();
                    return Table.Include(x=>x.Musteri).Include(x=>x.Arac).ToList();
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }

        public KiralikAraclar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(KiralikAraclar model)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<KiralikAraclar> Table = dbContext.Set<KiralikAraclar>();
                    var ent = Table.FirstOrDefault(x => x.kiralikaraclarID == model.kiralikaraclarID);
                    ent.durum = false;
                    dbContext.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }
    }
}
