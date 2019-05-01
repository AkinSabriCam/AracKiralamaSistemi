using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DBHelper;
using DAL.Abstractions;
using Model.DTOs;
using Model.Models;
namespace DAL.Concretes
{
    public class SirketRepository : IRepository<Sirket>,IDisposable
    {
        public SirketRepository()
        {
            
        }
        public bool Add(Sirket model)
        {
            using (Core.DBHelper.DBContext dbContext = new Core.DBHelper.DBContext())
            {
                try
                {
                    dbContext.Set<Sirket>().Add(model);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public void Delete(int id)
        {
            using(Core.DBHelper.DBContext dbContext = new Core.DBHelper.DBContext())
            {
                try
                {
                    var SilinecekModel = dbContext.Set<Sirket>().FirstOrDefault(x => x.sirketID == id);
                    dbContext.Set<Sirket>().Remove(SilinecekModel);
                    dbContext.SaveChanges();
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<Sirket> Get()
        {
            using(Core.DBHelper.DBContext dbContext= new Core.DBHelper.DBContext())
            {
                DbSet<Sirket> table = dbContext.Set<Sirket>();
                return table.Include(x => x.Kullanici).Include(x=>x.Arac).Include(x=>x.İl).ToList();
               
            }
        }

        public Sirket GetById(int id)
        {
            using (DBContext dbContext = new DBContext())
            {
                var table = dbContext.Set<Sirket>();
                return table.Include(x => x.Kullanici).Include(x => x.Arac).Include(x => x.İl)
                    .FirstOrDefault(x => x.sirketID == id);


            }
        }

        public bool Update(Sirket model)
        {
            throw new NotImplementedException();
        }
    }
}
