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
    public class AracRepository : IRepository<Model.Models.Arac>,IDisposable
    {
        public bool Add(Arac model)
        { 
            using(DBContext dbContext= new DBContext())
            {
                try
                {
                    var table = dbContext.Set<Arac>();
                    table.Add(model);
                    dbContext.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
          
        }

        public void Delete(int id)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    var table = dbContext.Set<Arac>();
                    var model = table.FirstOrDefault(x => x.aracID == id);
                    table.Remove(model);
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

        public List<Arac> Get()
        {
           using(Core.DBHelper.DBContext dbContext = new Core.DBHelper.DBContext())
            {
                try
                {
                    DbSet<Arac> table = dbContext.Set<Arac>();
                    return table.Include(x => x.Sirket).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public Arac GetById(int id)
        {
            using (DBContext dbContext =new DBContext())
            {
                try
                {
                    var table = dbContext.Set<Arac>();
                    return table.Include(x => x.Sirket).FirstOrDefault(x => x.aracID == id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }

        }
        public bool Update(Arac model)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    var table = dbContext.Set<Arac>();
                    var oldModel = table.FirstOrDefault(x => x.aracID == model.aracID);
                    if (oldModel != null)
                    {
                        oldModel = model;
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
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
