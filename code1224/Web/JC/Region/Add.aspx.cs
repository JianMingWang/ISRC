using FineUI;
using System;
using System.Data;



namespace ISRC.Web.JC.Region
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }
        }

        //保存操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_Region bllRegion = new BLL.T_Region();
            #region 检查
            DataSet dsRegion = bllRegion.GetList("T_Region.ID='" + txbRegionNO.Text + "'");
            if (dsRegion.Tables[0].Rows.Count > 0)
            {
                Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 保存
            Model.T_Region modelRegion = new Model.T_Region();
            modelRegion.ID = txbRegionNO.Text.ToString().Trim();
            modelRegion.Name = txbRegionName.Text.ToString().Trim();

            bool result = bllRegion.Add(modelRegion);

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
    }
}