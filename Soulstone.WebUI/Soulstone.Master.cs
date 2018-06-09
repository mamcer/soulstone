using System;
using System.Web.UI;

namespace Soulstone.WebUI
{
    public partial class Soulstone : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SoulstoneService service = new SoulstoneService();
                FileCountInfo fci = service.GetTotalFileCount();
                lblSearchOver.Text = string.Format("Buscando en {0:n0} archivos diferentes, {1:n0} fuentes", fci.FileCount, fci.FileFontCount);
            }
        }
    }
}
