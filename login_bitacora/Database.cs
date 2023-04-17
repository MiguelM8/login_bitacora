using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace login_bitacora
{
    public class Database
    {

        public static bool doLogin(string username, string password)
        {
            bool login = false;
            // define connection and command, in using blocks to ensure disposal
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=bdUsuarios;User ID=sa;Password=4548"))
            using (SqlCommand cmd = new SqlCommand("dbo.hacer_login", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar);
                cmd.Parameters.Add("@clave", SqlDbType.VarChar);
                cmd.Parameters.Add("@exito", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@usuario"].Value = username;
                cmd.Parameters["@clave"].Value = password;

                // open connection and execute stored procedure
                conn.Open();
                cmd.ExecuteNonQuery();

                // read output value from @NewId
                login  = cmd.Parameters["@exito"].Value.Equals("si");
                conn.Close();
            }
            return login;
        }



        public static List<Historial> ObtenerBitacora()
        {
            List<Historial> historial = new List<Historial>();

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=bdUsuarios;User ID=sa;Password=4548"))
            using (SqlCommand cmd = new SqlCommand("select * from bitacoraacceso", conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
               

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        historial.Add(new Historial(reader.GetString(1), reader.GetDateTime(2)));
                    }
                }


                conn.Close();
            }
            return historial;
        }
      

    }

    

}
