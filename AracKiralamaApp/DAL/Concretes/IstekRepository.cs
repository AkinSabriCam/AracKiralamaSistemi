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
    public class IstekRepository : IRepository<Model.Models.Istek>,IDisposable
    {
        public bool Add(Istek model)
        {
           using(DBContext dbContext = new DBContext())
            {
                try
                {
                    dbContext.Set<Istek>().Add(model);
                    dbContext.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw ;
                }

            }

        }

        public void Delete(int id)
        {
            using(DBContext dbContext = new DBContext())
            {
                try
                {
                    var model = dbContext.Set<Istek>().FirstOrDefault(x => x.istekID==id);
                    dbContext.Set<Istek>().Remove(model);
                    dbContext.SaveChanges();

                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<Istek> Get()
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Istek> Table = dbContext.Set<Istek>();
                    return Table.Include(x => x.Arac).Include(x => x.Musteri).ToList();
                }
                catch(Exception ex)
                {
                    throw ;
                }
            }
        }

        public Istek GetById(int id)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Istek> Table = dbContext.Set<Istek>();
                    return Table.Include(x => x.Arac).Include(x => x.Musteri).FirstOrDefault(x=>x.istekID==id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool Update(Istek model)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Istek> Table = dbContext.Set<Istek>();
                    var istek=Table.Include(x => x.Arac).Include(x => x.Musteri).FirstOrDefault(x => x.istekID == model.istekID);
                    if (istek != null)
                    {
                        istek.durum = false;
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
