using System;
using FineUI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ISRC.Web.JC.Index
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            if (!IsPostBack)
            {
                InitAddPage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();
            BLL.T_Index bllIndex = new BLL.T_Index();

            #region 检查

            string IndexType = Request.QueryString["IndexType"].ToString();
            string selectedIndexID = Session["selectedIndexID"].ToString();
            if (IndexType == "0")
            {
                DataSet dsIndexCategory = bllIndexCategory.GetList(" ID='" + txbIndexNO.Text.ToString() + "'");
                if (dsIndexCategory.Tables[0].Rows.Count > 0)
                {
                    Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (selectedIndexID != "-1")
                {
                    DataSet dsIndex = bllIndex.GetList(" ID='" + txbIndexNO.Text.ToString() + "'");
                    if (dsIndex.Tables[0].Rows.Count > 0)
                    {
                        Alert.ShowInTop("该项已存在！", "错误", MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Alert.ShowInTop("未选择父类，不能增加子项指标！", "错误", MessageBoxIcon.Error);
                    return;
                }
            }

            #endregion

            #region 保存

            if (IndexType == "0")
            {
                Model.T_IndexCategory modelIndexCategory = new Model.T_IndexCategory();
                modelIndexCategory.ID = "#" + txbIndexNO.Text.ToString();//父类ID前加#，以区分父类
                modelIndexCategory.Name = txbIndexName.Text.ToString();
                modelIndexCategory.FatherID = "-1";//"-1"代表根，指标分类的FatherID为根ID -1
                bool result = bllIndexCategory.Add(modelIndexCategory);
                if (result)
                {
                    Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
                }
                else
                {
                    Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
                }
            }
            else
            {
                string FatherID = Session["selectedIndexID"].ToString();

                Model.T_Index modelIndex = new Model.T_Index();
                modelIndex.ID = txbIndexNO.Text.ToString();
                modelIndex.Name = txbIndexName.Text.ToString();
                modelIndex.FatherID = FatherID;
                modelIndex.Description = txbIndexDescription.Text.ToString();
                modelIndex.OderID = nbxIndexOrderID.Text.ToString();
                modelIndex.Cycle = ddlIndexCycle.SelectedItem.Value.ToString();
                modelIndex.MultiIndex = ddlIndexMultiIndex.SelectedItem.Value.ToString();
                bool result = bllIndex.Add(modelIndex);
                if (result)
                {
                    Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
                }
                else
                {
                    Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
                }
            }

            #endregion
        }

        private void InitAddPage()
        {
            string IndexType = Request.QueryString["IndexType"].ToString();

            if (IndexType == "0")
            {
                //新增父类
                txtFatherName.Hidden = true;
                txbIndexDescription.Hidden = true;
                nbxIndexOrderID.Hidden = true;
                ddlIndexCycle.Hidden = true;
                ddlIndexMultiIndex.Hidden = true;
            }
            else
            {
                //新增子类
                txtFatherName.Text = Session["selectedIndexName"].ToString();
                txtFatherName.Enabled = false;
            }
        }
    }
}