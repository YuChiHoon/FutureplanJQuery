using System;

public class _02_19_MemoEntity
{
    #region Num :번호
    private int _Num;
    //번호
    public int Num
    {
        get { return _Num; }
        set { _Num = value; }
    }
    #endregion

    #region Name :작성자
    private string _Name;
    //작성자
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    #endregion

    #region Email : 이메일
    private string _Email;
    //이메일
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    #endregion

    #region Title : 메모(150자 이내)
    private string _Title;
    //메모
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    #endregion

    #region PostDate : 작성일
    private DateTime _PostDate;
    //작성일
    public DateTime PostDate
    {
        
        get { return _PostDate; }
        set { _PostDate = value; }
    }
    #endregion

    #region PostIP : IP주소
    private string _PostIP;
    //IP주소
    public string PostIP
    {
        get { return _PostIP; }
        set { _PostIP = value; }
    }
    #endregion
}