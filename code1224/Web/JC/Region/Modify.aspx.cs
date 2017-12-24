using FineUI;
using System;
using System.Data;
using System.Text;
using System.Web.UI;

namespace ISRC.Web.JC.Region
{
    public partial class Modify : System.Web.UI.Page
    {

        private StringBuilder condition = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            condition.Append("T_Region.ID='").Append(Request.QueryString["id"].ToString()).Append("'");

            BLL.T_Region bllRegion = new BLL.T_Region();
            DataSet dsRegion = bllRegion.GetList(condition.ToString());
            DataTable dtSource = dsRegion.Tables[0];
            txtRegionID.Text = dtSource.Rows[0]["ID"].ToString();
            txbRegionName.Text = dtSource.Rows[0]["Name"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_Region bllRegion = new BLL.T_Region();

            Model.T_Region modelRegion = new Model.T_Region();
            modelRegion.ID = Request.QueryString["id"].ToString();
            modelRegion.Name = txbRegionName.Text.Trim();
            bool result = bllRegion.Update(modelRegion);

            if (!result)
            {
                Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("关闭本窗口,您所做的修改将不被保存", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
        }

        protected void windowPop_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            Alert.ShowInTop("弹出窗口关闭了！");
        }
    }
}