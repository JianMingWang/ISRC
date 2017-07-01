using FineUI;
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRC.Web.Trigger
{
    public partial class Region : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.OnClientClick = gridRegion.GetNoSelectionAlertReference("至少选择一项!");
                BindGrid();
            }
        }


        private void BindGrid()
        {
            StringBuilder strWhere = new StringBuilder("1=1 ORDER BY CONVERT(int,ID)");
            BLL.T_Region bllRegion = new BLL.T_Region();
            DataSet dsRegion = bllRegion.GetList(strWhere.ToString());
            DataTable dtSource = dsRegion.Tables[0];
            gridRegion.DataSource = dtSource;
            gridRegion.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            object[] rowValue = gridRegion.Rows[gridRegion.SelectedRowIndex].Values;
            //关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(
                ActiveWindow.GetWriteBackValueReference(rowValue[1].ToString(), rowValue[0].ToString())
                + ActiveWindow.GetHidePostBackReference());
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (gridRegion.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("未选择数据", "信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
            }
            else
            {
                Alert.ShowInTop("您已选择了一条数据，是否确认关闭本窗口？", "询问", MessageBoxIcon.Question, ActiveWindow.GetHideReference());
            }
        }
    }
}