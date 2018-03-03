using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _02_02_23_AspNet_ResponseText : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // 단일값 반환 SingleValueReturn.htm에서 테스트
    [WebMethod]
    public static string GetMessage()
    {
        return "닷넷코리아";
    }

    //개체값 반환
    [WebMethod]
    public static Person GetRedPlus()
    {
        // 아래와 같이 했을때
        //{"d":{"__type":"Person", "Name":"박용준","Age":120,"Gender":true}}로 반환됨
        // Ajax쪽에서는 data.d.Name 식으로 가져감
        return new Person() { Name = "박용준", Age = 21, Gender = true };
    }

    //날짜값 반환
    [WebMethod]
    public static DateTime GetTime()
    {
        return DateTime.Now.ToUniversalTime();
    }

    //List 형태를 JSON형태로 출력
    [WebMethod]
    [ScriptMethod(ResponseFormat =ResponseFormat.Json)]
    public static List<Memo> GetMemos()
    {
        List<Memo> lst = new List<Memo>()
        {
            new Memo(){Num=1,Name="홍길동"},
            new Memo(){Num=2,Name="백두산"},
            new Memo(){Num=3,Name="한라산"}
        };
        return lst;
    }
}
public class Memo
{
    public int Num { get; set; }
    public string Name { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Gender { get; set; }
}