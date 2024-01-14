using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DBCon.PostgreDataStruct;
using Npgsql;

namespace DBCon
{
    public class PostgreeCon
    {
        public static NpgsqlDataSource? dataSource;
        public void IniciarCon()
        {
            var connectionString = "Host=localhost;Port=5433;Username=postgres;Password=admin;Database=postgres;Pooling=true;";
            dataSource = NpgsqlDataSource.Create(connectionString);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dataSourceBuilder.MapComposite<imagen>();
             dataSource = dataSourceBuilder.Build();
        }
        public List<T> ConsultaTest<T>(string consulta) where T : new()
        {
            using var command = dataSource.CreateCommand(consulta);
            using var reader = command.ExecuteReader();
            List<T> result = new List<T>();
            
            while (reader.Read())
            {
                T DatoInterno = new T();
                Type t = DatoInterno.GetType();
                PropertyInfo[] prop = t.GetProperties();
                int count = 0;
                foreach (var itemprop in prop)
                {
                    var tipon = reader.GetPostgresType(count);
                    Type o = itemprop.PropertyType;
                    MethodInfo method = reader.GetType().GetMethod("GetFieldValue")
                             .MakeGenericMethod(new Type[] { o });
                    var r = method.Invoke(reader, new object[] { count });
                    itemprop.SetValue(DatoInterno, r);

                    count++;
                }
                result.Add(DatoInterno);
            }
            return result;
        }



    }
}
