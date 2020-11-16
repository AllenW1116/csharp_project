using community.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace community.DAL
{
    public class FinancialDAL
    {
        public static List<Financial> GetUserlist()
        {
            List<Financial> list = new List<Financial>();
            string sql = "SELECT * FROM dbo.Financial";
            try
            {
                SqlDataReader dr = SqlDbHelper.ExecuteDataReader(CommandType.Text, sql, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Financial obj = new Financial();
                        obj.AutoID = SqlDbHelper.ExecToInt32(dr, "AutoID");
                        obj.Price = SqlDbHelper.ExecToDecimal(dr, "Price");
                        obj.Remark = SqlDbHelper.ExecToString(dr, "Remark");
                        obj.FinType = SqlDbHelper.ExecToInt32(dr, "FinType");
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
        public static int Add(Financial entity)
        {
            string sql = @"INSERT INTO dbo.Financial(Price, Remark, FinType )
                            VALUES  (@Price, @Remark, @FinType)";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@Price",entity.Price),
                        new SqlParameter("@Remark",entity.Remark),
                        new SqlParameter("@FinType",entity.FinType)
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
            string sql = "DELETE FROM dbo.Financial WHERE AutoID=@AutoID";
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