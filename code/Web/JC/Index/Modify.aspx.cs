using FineUI;
using System;
using System.Data;

namespace ISRC.Web.JC.Index
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string IndexType = Request.QueryString["IndexType"].ToString();
            if (IndexType == "1")
            {
                string IndexID = Request.QueryString["IndexID"].ToString();

                BLL.T_Index bllIndex = new BLL.T_Index();
                Model.T_Index modelIndex = new Model.T_Index();
                modelIndex = bllIndex.GetModel(IndexID);

                txbIndexNO.Text = modelIndex.ID;
                txbIndexName.Text = modelIndex.Name;
                txbIndexDescription.Text = modelIndex.Description;
                nbxIndexOrderID.Text = modelIndex.OderID;
                ddlIndexCycle.SelectedValue = modelIndex.Cycle.ToString();

                BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();
                DataSet ds = bllIndexCategory.GetList(" ID != '-1'");
                DataTable dtSource = ds.Tables[0];
                foreach (DataRow row in dtSource.Rows)
                {
                    FineUI.ListItem Items = new FineUI.ListItem();
                    Items.Text = row["Name"].ToString();
                    Items.Value = row["ID"].ToString();
                    if (row["ID"].ToString() == modelIndex.FatherID)
                    {
                        Items.Selected = true;
                    }
                    ddlIndexCategory.Items.Add(Items);
                }
            }
            else if (IndexType == "0")
            {
                ddlIndexCategory.Hidden = true;
                txbIndexDescription.Hidden = true;
                nbxIndexOrderID.Hidden = true;
                ddlIndexCycle.Hidden = true;
                ddlIndexMultiIndex.Hidden = true;

                //父类ID钱加#
                string IndexID = "#" + Request.QueryString["IndexID"].ToString();

                BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();
                Model.T_IndexCategory modelIndexCategory = new Model.T_IndexCategory();
                modelIndexCategory = bllIndexCategory.GetModel(IndexID);

                //截取掉父类ID的首位"#"
                txbIndexNO.Text = modelIndexCategory.ID.Substring(1, modelIndexCategory.ID.Length - 1);
                txbIndexName.Text = modelIndexCategory.Name;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string IndexType = Request.QueryString["IndexType"].ToString();
            if (IndexType == "1")//1代表子指标，0代表父指标
            {
                BLL.T_Index bllIndex = new BLL.T_Index();

                Model.T_Index modelIndex = new Model.T_Index();
                modelIndex.ID = txbIndexNO.Text.ToString();
                modelIndex.Name = txbIndexName.Text.ToString();
                modelIndex.OderID = nbxIndexOrderID.Text.ToString();
                modelIndex.Description = txbIndexDescription.Text.ToString();
                modelIndex.FatherID = ddlIndexCategory.SelectedValue.ToString();
                modelIndex.Cycle = ddlIndexCycle.SelectedItem.Value.ToString();
                modelIndex.MultiIndex = ddlIndexMultiIndex.SelectedItem.Value.ToString();
                bool result = bllIndex.Update(modelIndex);

                if (!result)
                {
                    Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
                }
            }
            else //1代表子指标，0代表父指标
            {
                BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();

                Model.T_IndexCategory modelIndexCategory = new Model.T_IndexCategory();
                modelIndexCategory.ID = "#" + txbIndexNO.Text.ToString();
                modelIndexCategory.Name = txbIndexName.Text.ToString();
                modelIndexCategory.FatherID = "-1";
                bool result = bllIndexCategory.Update(modelIndexCategory);
                if (!result)
                {
                    Alert.ShowInTop("更新失败", "提示信息", MessageBoxIcon.Error, ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    Alert.ShowInTop("更新成功", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideRefreshReference());
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("关闭本窗口,您所做的修改将不被保存", "提示信息", MessageBoxIcon.Information, ActiveWindow.GetHideReference());
        }
    }
}