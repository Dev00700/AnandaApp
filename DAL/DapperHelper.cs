using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MyApp.Models
{
    public class DBHelperDapper
    {
        private static string connectionString = string.Empty;
        public static string connection()
        {
            try
            {
                //return connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //return connectionString = "Server=localhost;Database=AnandaDairy;User Id=sa;Password=123456;TrustServerCertificate=true;";
                return connectionString = "Server=182.71.118.74;Database=Ananda_WebPortal;User Id=web;Password=An@nda@123$;TrustServerCertificate=true;";
            }
            catch (Exception)
            {
                //todo error handling  mechanism
                throw;
            }
        }

        /*getting details fro datatbase list*/
        public static List<TClass> DAGetDetailsInList<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    IList<TClass> myList = SqlMapper.Query<TClass>(con, _qry).ToList();
                    return myList.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static TClass DAGetDetails<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    TClass myList = SqlMapper.Query<TClass>(con, _qry).FirstOrDefault();
                    return myList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static int DAAdd<T>(string Procname, T param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    return _iresult;
                }
            }
        }

        public static int DAAdd(string Procname, DynamicParameters param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    return _iresult;
                }
            }
        }

        public static TClass GetAllModel<TClass>(string _procame, DynamicParameters param)
        {
            TClass _objMOdel;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    using (SqlConnection objConnection = new SqlConnection(connection()))
                    {
                        _objMOdel = SqlMapper.Query<TClass>(objConnection, _procame, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    }
                    return _objMOdel;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static List<T> GetAllModelList<T>(string spName, DynamicParameters p)
        {
            List<T> recordList = new List<T>();
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                recordList = SqlMapper.Query<T>(objConnection, spName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                objConnection.Close();
            }
            return recordList;
        }
        public static T? GetSingleValue<T>(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public static T? GetColumnValueById<T>(string tableName, string columnName, string whereColumn, object whereValue)
        {
            try
            {
                string proc = "Proc_GetColumnValue";
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@TableName", tableName);
                queryParameter.Add("@ColumnName", columnName);
                queryParameter.Add("@WhereColumn", whereColumn);
                queryParameter.Add("@WhereValue", whereValue);

                return DBHelperDapper.GetSingleValue<T>(proc, queryParameter);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        
    }
}