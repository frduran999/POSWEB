using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataSource
    {
        public static string coneccionPrimaria = (ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public static bool cache;

        public static void SetParametros(string conn1)
        {
            coneccionPrimaria = conn1;
        }

        public static void SetCache(bool hasCache)
        {
            cache = hasCache;
        }

        public string ConeccionPrimaria { get { return coneccionPrimaria; } }
    }
}
