using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IRepository<TEntity> 
        where TEntity:class
        
    {

         bool Add(TEntity model);
         void Delete(int id);

         bool Update(TEntity model);

        List<TEntity> Get();

        TEntity GetById(int id);
        

    }
}
