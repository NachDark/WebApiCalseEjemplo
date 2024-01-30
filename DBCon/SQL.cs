using DatabaseConnectionCustom.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBCon
{
    public class SQLconn
    {

        public static SqlConnection? connec { get; set; }

        public void connect()
        {
           
            connec = new SqlConnection();
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=TEST;Initial Catalog=Reservas;Data Source=NACHOPC";
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=sqltest;Initial Catalog=testdb;Data Source=NACHOPC";
            //Integrated Security = SSPI usa authenticacion de windows
            //connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=sqltest;Password=sqltest;Data Source=NACHOPC";
            connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=CEStest;Password=CEStest;Data Source=NACHOPC";
            connec.Open();
            
            
        }

        public void connect(bool appconfig)
        {
            //ExeConfigurationFileMap t = new ExeConfigurationFileMap("");
            //var conf = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration("", ConfigurationUserLevel.None);

            
            
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=TEST;Initial Catalog=Reservas;Data Source=NACHOPC";
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=sqltest;Initial Catalog=testdb;Data Source=NACHOPC";
            //Integrated Security = SSPI usa authenticacion de windows
            //connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=sqltest;Password=sqltest;Data Source=NACHOPC";
            connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=CEStest;Password=CEStest;Data Source=NACHOPC";
            connec.Open();


        }

     

        public List<T> ConsultaTest<T>(string sql, T DatosFiltro) where T : new() 
        {
            throw new Exception("Aqui debes incluir la función que retorne la lista de clase T, podeis realizarla a traves de Serializado o recorriendo el dataset a traves de AsEnumerable");

        }

        public DataSet TestDB()
        {
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select * from testtable", connec);
           
            adapter.Fill(dt);
            return dt;
        }

        public IList<Users> GetUsers(Users user_to_search)
        {

            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@Name", user_to_search.Usuario));
            userparam.Add(new KeyValuePair<string, dynamic>("@Password", user_to_search.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@admin", user_to_search.Administrator));
            userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_search.Manager));
            userparam.Add(new KeyValuePair<string, dynamic>("@mail", user_to_search.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@idnegocio", user_to_search.idnegocio));
            DataSet ds = queryGenericStored("svp_users_get", userparam);
            IList<Users> items = ds.Tables[0].AsEnumerable().Select(row =>
       new Users
       {
           Usuario = row.Field<string>("Usuario"),
           email = row.Field<string>("email"),
           Administrator = row.Field<int?>("Administrator"),
           Manager = row.Field<int?>("Manager"),
           pass = row.Field<string>("pass"),
           idnegocio = row.Field<int?>("idnegocio")

       }).ToList();

            return items;


        }

        public DataSet queryGenericStored(string query, List<KeyValuePair<string, dynamic>> parameters = null)
        {

            
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connec);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Clear();
            foreach (KeyValuePair<string, dynamic> param in parameters)
            {
                AddParameter(ref adapter, param);

            }
            adapter.Fill(dt);
            return dt;
        }
        public void AddParameter(ref SqlDataAdapter sel, KeyValuePair<string, dynamic> val)
        {
            if (val.Value != null)
            {
                sel.SelectCommand.Parameters.AddWithValue(val.Key, val.Value);
            }
        }

        public IList<Users> queryUserinfo(string query)
        {
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connec);
            adapter.SelectCommand.Parameters.Clear();
            adapter.Fill(dt);
            IList<Users> items = dt.Tables[0].AsEnumerable().Select(row =>
           new Users
           {
               Usuario = row.Field<string>("Usuario"),
               email = row.Field<string>("email")
           }).ToList();

            return items;

        }
    }
}