using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL
{
    public class Mapper
    {
        public static List<T> BindDataList<T>(DataTable dt)
        {
            List<T> lista = new List<T>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(ObtieneDataFila<T>(item, dt.Columns));
            }

            return lista;
        }
        public static T BindData<T>(DataTable dt)
        {
            T objeto;

            if (dt.Rows.Count > 0)
            {
                objeto = ObtieneDataFila<T>(dt.Rows[0], dt.Columns);
            }
            else
            {
                throw new Exception("No tiene filas");
            }

            return objeto;
        }

        private static T ObtieneDataFila<T>(DataRow dr, DataColumnCollection dcCollection)
        {
            // Get all columns' name
            List<string> columns = new List<string>();
            foreach (DataColumn dc in dcCollection)
            {
                columns.Add(dc.ColumnName);
            }

            // Create object
            var ob = Activator.CreateInstance<T>();

            // Get all fields
            var fields = typeof(T).GetFields();
            foreach (var fieldInfo in fields)
            {
                if (columns.Contains(fieldInfo.Name))
                {
                    // Fill the data into the field
                    fieldInfo.SetValue(ob, dr[fieldInfo.Name]);
                }
            }

            // Get all properties
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                if (columns.Select(m => m.ToLower()).Contains(propertyInfo.Name.ToLower()))
                {
                    // Fill the data into the property
                    propertyInfo.SetValue(ob, dr[propertyInfo.Name] is DBNull ? null : dr[propertyInfo.Name]);
                }
            }

            return ob;
        }
    }
}
