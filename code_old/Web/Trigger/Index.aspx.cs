using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

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