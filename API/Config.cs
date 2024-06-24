using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEKELT_TERA1.API
{
    internal class Config
    {
        static readonly string connectionString = "Data Source=PANDA-PC;Initial Catalog=atekelt_tera;Integrated Security=True;";
        
        public static String getConnectionString()
        {
            return connectionString;
        }

    }
}
