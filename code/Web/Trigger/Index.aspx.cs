using FineUI;
using System;

namespace ISRC.Web.Trigger
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }
    }
}