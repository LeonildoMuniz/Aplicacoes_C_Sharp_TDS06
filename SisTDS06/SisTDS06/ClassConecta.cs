using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SisTDS06
{
    class ClassConecta
    {
        private static string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SisTDS06\SisTDS06\DbSis.mdf;Integrated Security=True";
        private static SqlConnection con = null;

        public static SqlConnection ObterConexao()
        {
            con = new SqlConnection(str);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            try
            {
               con.Open();
            }
            catch (SqlException sqle)
            {
                con = null;
                
            }

            return con;

        }


        public static void FecharConexao()
        {

            if (con != null || con.State == ConnectionState.Open)
            {
                con.Close();
          
            }
        }
    }
}
