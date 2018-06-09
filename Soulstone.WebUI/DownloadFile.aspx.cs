using System;
using System.Text;

public partial class DownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string data = Request.Form["ctl00$BodyPlaceHolder$downloadData"];
        string fileName = Request.Form["ctl00$BodyPlaceHolder$fileName"];

        Response.Clear();
        Response.ContentEncoding = Encoding.Default;
        Response.ContentType = "text/html";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.Write(data);
        Response.Flush();
        Response.Close();
    }
}
