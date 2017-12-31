using FineUI;
using System;

namespace ISRC.Web.Trigger
{
    public partial class IndexCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }
        }
    }
}