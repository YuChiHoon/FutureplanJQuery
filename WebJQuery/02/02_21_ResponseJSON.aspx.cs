using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _02_02_21_ResponseJSON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";
        Response.Write("[{\"Num\":\"1\",\"Name\":\"홍길동\"},{\"Num\":\"2\",\"Name\":\"백두산\"}]");
        Response.End();
    }
}