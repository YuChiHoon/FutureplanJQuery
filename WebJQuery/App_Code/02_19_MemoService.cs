﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class _02_19_MemoService : System.Web.Services.WebService
{
    [WebMethod]
    public void AddMemo(string name, string email, string title)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "Insert Into Memos(Name, Email, Title, PostIP) Values(@Name, @Email, @Title, @PostIP)";
        cmd.CommandType = System.Data.CommandType.Text;

        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Title", title);
        cmd.Parameters.AddWithValue("@PostIP", HttpContext.Current.Request.UserHostAddress);

        cmd.ExecuteNonQuery();

        cmd.Clone();
    }

    [WebMethod]
    //JSON형태로 반환하려면 ResponseFormat 지정해야함
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<_02_19_MemoEntity> GetMemos()
    {
        List<_02_19_MemoEntity> lst = new List<_02_19_MemoEntity>();

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * From Memos Order By Num Desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Memos");

        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            _02_19_MemoEntity objMemo = new _02_19_MemoEntity();
            objMemo.Num      = Convert.ToInt32(dt.Rows[i]["Num"]);
            objMemo.Name     = dt.Rows[i]["Name"].ToString();
            objMemo.Email    = dt.Rows[i]["Email"].ToString();
            objMemo.Title    = dt.Rows[i]["Title"].ToString();
            objMemo.PostDate = Convert.ToDateTime(dt.Rows[i]["PostDate"]);
            objMemo.PostIP   = dt.Rows[i]["PostIP"].ToString();

            lst.Add(objMemo);
        }

        return lst;
    }

    [WebMethod]
    //JSON형태로 반환하려면 ResponseFormat 지정해야함
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<_02_19_MemoEntity> GetMemosByPage(int page, int pageSize)
    {
        List<_02_19_MemoEntity> lst = new List<_02_19_MemoEntity>();

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        string strSql = @"
With MemoLists
As
(
Select
Num, Name, Email, Title, PostDate, PostIP,
ROW_NUMBER() Over (Order By Num Desc) AS 'RowNumber'
From Memos
)
Select * From MemoLists
Where RowNumber
Between " + ((page - 1) * pageSize + 1).ToString() + @" And " + (page * pageSize).ToString();

        SqlCommand cmd = new SqlCommand(strSql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Memos");

        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            _02_19_MemoEntity objMemo = new _02_19_MemoEntity();
            objMemo.Num = Convert.ToInt32(dt.Rows[i]["Num"]);
            objMemo.Name = dt.Rows[i]["Name"].ToString();
            objMemo.Email = dt.Rows[i]["Email"].ToString();
            objMemo.Title = dt.Rows[i]["Title"].ToString();
            objMemo.PostDate = Convert.ToDateTime(dt.Rows[i]["PostDate"]);
            objMemo.PostIP = dt.Rows[i]["PostIP"].ToString();

            lst.Add(objMemo);
        }

        return lst;
    }
}
