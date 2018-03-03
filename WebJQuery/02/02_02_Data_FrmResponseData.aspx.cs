using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _02_02_02_Data_FrmResponseData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/html";
        string html = "<div>안녕<div style=''>" + Request["Msg"] + "," + DateTime.Now.ToShortTimeString() + "</div></div>";

        Response.Clear();
        Response.Write(html);
        Response.End();
    }
}