using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public static class SqlDbHelper
{
    /// <summary>
    /// 获取连接字符串
    /// </summary>
    public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;
    /// <summary>
    /// 图片路径
    /// </summary>
    //public static string imageUrl = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();

    /// <summary>
    /// 关闭数据库
    /// </summary>
    /// <param name="conn">连接</param>
    public static void CloseConnection(SqlConnection conn)
    {
        if (null != conn && conn.State != ConnectionState.Closed)
        {
            conn.Close();
        }
    }
    /// <summary>
    /// 关闭读取器
    /// </summary>
    /// <param name="sr">读取器</param>
    public static void CloseReader(SqlDataReader sr)
    {
        if (null != sr && sr.IsClosed != true)
        {
            sr.Close();
        }
    }
    /// <summary>
    /// 执行增删改的sql语句
    /// </summary>
    /// <param name="commandType">执行的类型</param>
    /// <param name="commandText">执行的语句</param>
    /// <param name="prms">所需的参数</param>
    /// <returns>影响的行数</returns>
    public static int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] prms)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = new SqlConnection(connectionString);
        cmd.CommandText = commandText;
        cmd.CommandType = commandType;
        if (null != prms && prms.Length > 0)
        {
            foreach (SqlParameter sp in prms)
            {
                cmd.Parameters.Add(sp);
            }
        }
        try
        {
            cmd.Connection.Open();
            return cmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
        finally
        {
            CloseConnection(cmd.Connection);
        }
    }


    /// <summary>
    /// 执行查询的Sql语句
    /// </summary>
    /// <param name="commandType">执行的类型</param>
    /// <param name="commandText">执行的语句</param>
    /// <param name="prms">所需的参数</param>
    /// <returns>DataSet</returns>
    public static DataSet ExecuteDataSet(string commandText)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter da = new SqlDataAdapter(commandText, con);

        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
            return ds;
        }
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
        finally
        {
            CloseConnection(da.SelectCommand.Connection);
        }
    }
    /// <summary>
    /// 执行查询的Sql语句
    /// </summary>
    /// <param name="commandType">执行的类型</param>
    /// <param name="commandText">执行的语句</param>
    /// <param name="prms">所需的参数</param>
    /// <returns>读取器</returns>
    public static SqlDataReader ExecuteDataReader(CommandType commandType, string commandText, params SqlParameter[] prms)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = new SqlConnection(connectionString);
        cmd.CommandText = commandText;
        cmd.CommandType = commandType;
        cmd.Parameters.Clear();
        if (null != prms && prms.Length > 0)
        {
            foreach (SqlParameter sp in prms)
            {
                cmd.Parameters.Add(sp);
            }
        }
        try
        {
            cmd.Connection.Open();
            SqlDataReader sr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sr;
        }
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
    }
    /// <summary>
    /// 返回单行单列的Sql语句
    /// </summary>
    /// <param name="commandType">执行的类型</param>
    /// <param name="commandText">执行的语句</param>
    /// <param name="prms">所需的参数</param>
    /// <returns>影响的行数</returns>
    public static string ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] prms)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = new SqlConnection(connectionString);
        cmd.CommandText = commandText;
        cmd.CommandType = commandType;
        cmd.Parameters.Clear();
        if (null != prms && prms.Length > 0)
        {
            foreach (SqlParameter sp in prms)
            {
                cmd.Parameters.Add(sp);
            }
        }
        try
        {
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            cmd.Connection.Open();
            object obj = cmd.ExecuteScalar();
            return obj == null ? "" : obj.ToString();
        }
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
        finally
        {
            CloseConnection(cmd.Connection);
        }
    }
    /// <summary>
    /// 返回单行单列的Sql语句
    /// </summary>
    /// <param name="commandType">执行的类型</param>
    /// <param name="commandText">执行的语句</param>
    /// <param name="prms">所需的参数</param>
    /// <returns>影响的行数</returns>
    public static string ExecuteXMLScalar(CommandType commandType, string commandText, params SqlParameter[] prms)
    {
        string str = "";
        SqlCommand comm = new SqlCommand();

        comm.Connection = new SqlConnection(connectionString);

        comm.CommandText = commandText;
        comm.CommandType = commandType;
        if (null != prms && prms.Length > 0)
        {
            foreach (SqlParameter sp in prms)
            {
                comm.Parameters.Add(sp);
            }
        }
        comm.Connection.Open();
        if (comm != null)
        {
            XmlReader xr = comm.ExecuteXmlReader();

            xr.Read();
            while (!xr.EOF)
            {
                str += xr.ReadOuterXml();
            }
            xr.Close();
            CloseConnection(comm.Connection);
            return str;
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 返回cmd的参数
    /// </summary>
    /// <returns></returns>
    public static SqlParameter GetCmdParameter(string name, SqlDbType dt, object value)
    {
        SqlParameter sp = new SqlParameter(name, dt);
        sp.Value = value;
        return sp;
    }
    /// <summary>
    /// 转换成Int32类型
    /// </summary>
    public static int ExecToInt32(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? 0 : Convert.ToInt32(reader[dataName]);
    }
    /// <summary>
    /// 转换成String类型
    /// </summary>
    public static string ExecToString(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? "" : reader[dataName].ToString();
    }
    /// <summary>
    /// 转换成DateTime类型
    /// </summary>
    public static DateTime ExecToDateTime(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader[dataName]);
    }
    /// <summary>
    /// 转换成Double类型
    /// </summary>
    public static Double ExecToDouble(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? 0 : Convert.ToDouble(reader[dataName]);
    }
    /// <summary>
    /// 转换成Decimal类型
    /// </summary>
    public static decimal ExecToDecimal(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? 0 : Convert.ToDecimal(reader[dataName]);
    }

    /// <summary>
    /// 转化XML为字符串公共类
    /// </summary>
    /// <param name="xmlList">转化的类</param>
    /// <param name="xmlUrl">XML路径</param>
    /// <returns></returns>
    public static string getString(Object xmlList, string xmlUrl)
    {
        Type type = xmlList.GetType();
        XmlSerializer serializer = new XmlSerializer(type);
        Stream fs = new FileStream(xmlUrl, FileMode.Create);
        XmlWriter write = new XmlTextWriter(fs, new UTF8Encoding());
        serializer.Serialize(write, xmlList);
        write.Close();

        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        doc.Load(xmlUrl);
        return doc.OuterXml;
    }

    /// <summary>
    /// 转换成Int32类型(自定义)
    /// </summary>
    public static int CustomToInt32(SqlDataReader reader, string dataName)
    {
        return reader[dataName] == DBNull.Value ? -1 : Convert.ToInt32(reader[dataName]);
    }
}
