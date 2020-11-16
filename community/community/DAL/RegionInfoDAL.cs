using community.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace community.DAL
{
    public class RegionInfoDAL
    {
        public static List<RegionInfo> GetRegionInfo()
        {
            List<RegionInfo> list = new List<RegionInfo>();
            string sql = "SELECT * FROM dbo.RegionInfo";
            try
            {
                SqlDataReader dr = SqlDbHelper.ExecuteDataReader(CommandType.Text, sql, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RegionInfo obj = new RegionInfo();
                        obj.AutoID = SqlDbHelper.ExecToInt32(dr, "AutoID");
                        obj.Name = SqlDbHelper.ExecToString(dr, "Name");
                        obj.Remark = SqlDbHelper.ExecToString(dr, "Remark");
                        
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
        public static int Add(RegionInfo entity)
        {
            string sql = @"INSERT INTO dbo.RegionInfo(Name, Remark )
                             VALUES  (@Name, @Remark)";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@Name",entity.Name),
                        new SqlParameter("@Remark",entity.Remark)
                    };
                int count = SqlDbHelper.ExecuteNonQuery(CommandType.Text, sql, parm);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public static int Del(string id)
        {
            string sql = "DELETE FROM dbo.RegionInfo WHERE AutoID=@AutoID";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@AutoID",Convert.ToInt32(id))
                    };
                int count = SqlDbHelper.ExecuteNonQuery(CommandType.Text, sql, parm);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

    }
}