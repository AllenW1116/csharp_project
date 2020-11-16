using community.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace community.DAL
{
    public class UserInfoDAL
    {
        public static List<UserInfo> GetUserlist()
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "SELECT * FROM dbo.UserInfo";
            try
            {
                SqlDataReader dr = SqlDbHelper.ExecuteDataReader(CommandType.Text, sql, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserInfo obj = new UserInfo();
                        obj.AutoID = SqlDbHelper.ExecToInt32(dr, "AutoID");
                        obj.UserName = SqlDbHelper.ExecToString(dr, "UserName");
                        obj.UserSex = SqlDbHelper.ExecToInt32(dr, "UserSex");
                        obj.IdentityNumber = SqlDbHelper.ExecToString(dr, "IdentityNumber");
                        obj.ContactAddress = SqlDbHelper.ExecToString(dr, "ContactAddress");
                        obj.ContactPhone = SqlDbHelper.ExecToString(dr, "ContactPhone");
                        obj.Email = SqlDbHelper.ExecToString(dr, "Email");
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

        public static int Add(UserInfo entity)
        {
            string sql = @"INSERT INTO dbo.UserInfo(UserName ,UserSex ,IdentityNumber ,ContactAddress ,ContactPhone ,Email)
                                           VALUES  (@UserName ,@UserSex ,@IdentityNumber ,@ContactAddress ,@ContactPhone ,@Email)";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@UserName",entity.UserName),
                        new SqlParameter("@UserSex",entity.UserSex),
                        new SqlParameter("@IdentityNumber",entity.IdentityNumber),
                        new SqlParameter("@ContactAddress",entity.ContactAddress),
                        new SqlParameter("@ContactPhone",entity.ContactPhone),
                        new SqlParameter("@Email",entity.Email)
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
        public static int Edit(UserInfo entity)
        {
            string sql = @"UPDATE dbo.UserInfo SET UserName=@UserName,UserSex=@UserSex,IdentityNumber=@IdentityNumber ,
                                    ContactAddress=@ContactAddress ,ContactPhone=@ContactPhone,Email=@Email WHERE AutoID=@AutoID";
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                    {
                        new SqlParameter("@AutoID",entity.AutoID),
                        new SqlParameter("@UserName",entity.UserName),
                        new SqlParameter("@UserSex",entity.UserSex),
                        new SqlParameter("@IdentityNumber",entity.IdentityNumber),
                        new SqlParameter("@ContactAddress",entity.ContactAddress),
                        new SqlParameter("@ContactPhone",entity.ContactPhone),
                        new SqlParameter("@Email",entity.Email)
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
            string sql = "DELETE FROM dbo.UserInfo WHERE AutoID=@AutoID";
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