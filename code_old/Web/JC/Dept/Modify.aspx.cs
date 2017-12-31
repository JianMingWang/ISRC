using System;
using FineUI;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;

namespace ISRC.Web.T_Dept
{
    public partial class Modify : PageBase
    {

        private StringBuilder condition = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbDeptRegionID.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbDeptRegionID.ClientID, hdfDeptNO.ClientID)
                    + windowPop.GetShowReference("~\\Trigger\\Region.aspx?Type=P", "选择地区");
                LoadData();
			}
		}

        private void LoadData()
        {
            condition.Append("T_Dept.ID='").Append(Request.QueryString["id"].ToString()).Append("'");

            BLL.T_Dept bllDept = new BLL.T_Dept();
            DataSet dsDept = bllDept.GetList(condition.ToString());
            DataTable dtSource = dsDept.Tables[0];


            txtDeptID.Text = dtSource.Rows[0]["ID"].ToString();
            txbDeptName.Text = dtSource.Rows[0]["Name"].ToString();
            ddlDeptQuality.SelectedValue = dtSource.Rows[0]["Quality"].ToString();
            tgbDeptRegionID.Text = dtSource.Rows[0]["RegionName"].ToString();
            txbDeptContactor.Text = dtSource.Rows[0]["Contactor"].ToString();
            txtDeptTel.Text = dtSource.Rows[0]["Tel"].ToString();
            nbxOderID.Text = dtSource.Rows[0]["OderID"].ToString();
            hdfDeptNO.Text = dtSource.Rows[0]["RegionID"].ToString();
            if(dtSource.Rows[0]["Quality"].ToString()=="1")
            {
                tgbDeptRegionID.Hidden = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_Dept bllDept = new BLL.T_Dept();

            Model.T_Dept modelDept = new Model.T_Dept();
            modelDept.ID = Request.QueryString["id"].ToString();
            modelDept.Name = txbDeptName.Text.Trim();
            modelDept.OderID = nbxOderID.Text.Trim();
            modelDept.Quality = ddlDeptQuality.SelectedValue.ToString().Trim();
            if (ddlDeptQuality.SelectedValue == "0")
            {
                modelDept.RegionID = "";
            }
            else
            {
                modelDept.RegionID = hdfDeptNO.Text.Trim();
            }            
            modelDept.Tel = txtDeptTel.Text.Trim();
            modelDept.Contactor = txbDeptContactor.Text.Trim();
            bool result = bllDept.Update(modelDept);

            if (!result)
            {
                Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
            }
        }
        protected void ddlDeptQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDeptQuality.SelectedValue == "1")
            {
                tgbDeptRegionID.Hidden = false;
            }
            else
            {
                tgbDeptRegionID.Hidden = true;
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
