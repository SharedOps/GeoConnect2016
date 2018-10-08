using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoConnect.DAL.SQL
{
    public static class SQLUtil
    {

        public static SqlConnection GetConnection(string ConnectionString)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static int CreateEntry(string ConnectionString, string StoredProcName, Dictionary<string, SqlParameter> ProcParameters)
        {
            int ExecStatus = 0;
            using (SqlConnection cn = GetConnection(ConnectionString))
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in ProcParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }

                    ExecStatus = cmd.ExecuteNonQuery();
                }
            }
            return ExecStatus;
        }


        public static DataSet GetItems(string ConnectionString, string StoredProcName, Dictionary<string, SqlParameter> ProcParameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = GetConnection(ConnectionString))
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in ProcParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }

}
