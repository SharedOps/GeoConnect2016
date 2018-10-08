using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GeoConnect.DAL;

namespace GeoConnect.Application.RetroNotes
{
    public static class RetroNotes
    {

        public static int AddItems(string ConnectionString, string SPname, Dictionary<string, SqlParameter> Parameters)
        {
            int execStatus = 0;
            try
            {
                execStatus = GeoConnect.DAL.SQL.SQLUtil.CreateEntry(ConnectionString, SPname, Parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return execStatus;

        }

        public static DataSet GetItems(string ConnectionString, string SPname, Dictionary<string, SqlParameter> Parameters)
        {
            DataSet ds = null;
            try
            {
                ds = GeoConnect.DAL.SQL.SQLUtil.GetItems(ConnectionString, SPname, Parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }


    }
}
