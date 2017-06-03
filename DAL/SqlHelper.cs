using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlHelper
    {
        private readonly static string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteTable(string sql, params SqlParameter[] ps)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, str))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

    }
}
