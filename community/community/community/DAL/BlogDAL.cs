﻿using community.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace community.DAL
{
    public class BlogDAL
    {
        public static List<Blog> GetRegionInfo()
        {
            List<Blog> list = new List<Blog>();
            string sql = "SELECT * FROM dbo.Blog";
            try
            {
                SqlDataReader dr = SqlDbHelper.ExecuteDataReader(CommandType.Text, sql, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Blog obj = new Blog();
                        obj.AutoID = SqlDbHelper.ExecToInt32(dr, "AutoID");
                        obj.Title = SqlDbHelper.ExecToString(dr, "Title");
                        obj.Abstract = SqlDbHelper.ExecToString(dr, "Abstract");
                        obj.img = SqlDbHelper.ExecToString(dr, "img");

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
        public static int Add(Blog entity)
        {
            string sql = @"INSERT INTO dbo.Blog(Title,Abstract, Remark,img)
                             VALUES  (@Title, @Abstract, @Remark, @img)";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@Title",entity.Title),
                        new SqlParameter("@Abstract",entity.Abstract),
                        new SqlParameter("@Remark",entity.Remark),
                        new SqlParameter("@img",entity.img)
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
            string sql = "DELETE FROM dbo.Blog WHERE AutoID=@AutoID";
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