using FineUI;
using System;
using System.Data;
using System.Web.UI;

namespace ISRC.Web.T_Dept
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                tgbDeptRegionID.OnClientTriggerClick =
                    windowPop.GetSaveStateReference(tgbDeptRegionID.ClientID, hdfDeptNO.ClientID)
                    + windowPop.GetShowReference("~\\Trigger\\Region.aspx?Type=P", "选择地区");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_Dept bllDept = new BLL.T_Dept();
            #region 检查
            DataSet dsDept = bllDept.GetList("T_Dept.ID='" + txbDeptNO.Text + "'");
            if (dsDept.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 保存
            Model.T_Dept modelDept = new Model.T_Dept();
            modelDept.ID = txbDeptNO.Text.Trim();
            modelDept.Name = txbDeptName.Text.Trim();
            modelDept.OderID = nbxOderID.Text.Trim();
            modelDept.Quality = ddlDeptQuality.SelectedValue.ToString().Trim();
            modelDept.RegionID = hdfDeptNO.Text.Trim();
            modelDept.Tel = txtDeptTel.Text.Trim();
            modelDept.Contactor = txbDeptContactor.Text.Trim();
            bool result = bllDept.Add(modelDept);

            if (result)
            {
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            #endregion
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
    }
}
