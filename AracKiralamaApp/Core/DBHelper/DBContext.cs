using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBHelper
{
    public class DBContext:DbContext
    {
        public DBContext()
            :base(@"metadata=res://*/Models.AracKiralama.csdl|res://*/Models.AracKiralama.ssdl|res://*/Models.AracKiralama.msl;provider=System.Data.SqlClient;provider connection string=';data source=.;initial catalog=AracKiralamaDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot';")
        {
            
        }
    }
}
