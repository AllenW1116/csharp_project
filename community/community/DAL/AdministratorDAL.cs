using community.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace community.DAL
{
    public class AdministratorDAL
    {
        public static List<Administrator> GetUserlist(string UserName, string Pwd,int AdminType)
        {
            List<Administrator> list = new List<Administrator>();
            string sql = "SELECT * FROM dbo.Administrator WHERE Name=@Name AND Pwd=@Pwd AND AdminType=@AdminType";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                new SqlParameter("@Name",UserName),
                new SqlParameter("@Pwd",Pwd),
                new SqlParameter("@AdminType",AdminType),
                    };
                SqlDataReader dr = SqlDbHelper.ExecuteDataReader(CommandType.Text, sql, parm);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Administrator obj = new Administrator();
                        obj.AutoID = SqlDbHelper.ExecToInt32(dr, "AutoID");
                        obj.Name = SqlDbHelper.ExecToString(dr, "Name");
                        obj.Pwd = SqlDbHelper.ExecToString(dr, "Pwd");
                        obj.AdminType = SqlDbHelper.ExecToInt32(dr, "AdminType");
                        list.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}