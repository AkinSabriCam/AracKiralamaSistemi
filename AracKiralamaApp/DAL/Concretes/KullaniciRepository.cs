using Core.DBHelper;
using DAL.Abstractions;
using Model.DTOs;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concretes
{
    public class KullaniciRepository : IRepository<Kullanici>,IDisposable
    {
        public bool Add(Kullanici model)
        {
            using(DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    Table.Add(model);
                    dbContext.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }

        public void Delete(int id)
        {
            using(DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    var SilinecekModel = Table.FirstOrDefault(x => x.kullaniciID == id);
                    Table.Remove(SilinecekModel);
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

        public List<Kullanici> Get()
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    return Table.Include(x => x.Sirket).Include(x => x.Rol).ToList();
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }

        public Kullanici GetById(int id)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    return Table.Include(x => x.Rol).Include(x => x.Sirket).FirstOrDefault(x=>x.kullaniciID==id);
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
        }

        public Kullanici GetByUsername(string username)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    return Table.Include(x => x.Sirket).Include(x => x.Rol).FirstOrDefault(x => x.username == username);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public Kullanici GetByUsernamePassword(string username,string password)
        {
            using (DBContext dbContext = new DBContext())
            {
                try
                {
                    DbSet<Kullanici> Table = dbContext.Set<Kullanici>();
                    return Table.Include(x => x.Sirket).Include(x => x.Rol)
                        .FirstOrDefault(x => x.username == username && x.password==password);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public bool Update(Kullanici model)
        {
            throw new NotImplementedException();
        }
    }
}
