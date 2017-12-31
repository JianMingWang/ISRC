using FineUI;
using System;
using System.Data;

namespace ISRC.Web.SYS.Menu
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                Bind_ddlMenuName();
                InitData();
            }
        }

        /// <summary>
        /// 初始化父项菜单下拉框
        /// </summary>
        protected void Bind_ddlMenuName()
        {
            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();
            DataSet ds = bllMenu.GetList(" ParentID='0' order by SortNo ASC ");
            DataRow row1 = ds.Tables[0].NewRow();
            row1["ID"] = "-1";
            row1["MenuName"] = "请选择";
            DataRow row2 = ds.Tables[0].NewRow();
            row2["ID"] = "0";
            row2["MenuName"] = "根项";
            ds.Tables[0].Rows.InsertAt(row1, 0);
            ds.Tables[0].Rows.InsertAt(row2, 1);

            ddlFatherMenu.DataSource = ds.Tables[0];
            ddlFatherMenu.DataTextField = "MenuName";
            ddlFatherMenu.DataValueField = "ID";
            ddlFatherMenu.DataBind();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InitData() {
            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();
            Model.T_Sys_Menu modelMenu = bllMenu.GetModel(Request.QueryString["id"]);
            txbMenuName.Text = modelMenu.MenuName;
            txbMenuUrl.Text = modelMenu.MenuUrl;
            txbSortNo.Text = modelMenu.SortNo.ToString();
            ddlFatherMenu.SelectedValue = modelMenu.ParentID;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkForm()) return;

            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();
            Model.T_Sys_Menu modelMenu = new Model.T_Sys_Menu();
            modelMenu.ID = Request.QueryString["id"];
            modelMenu.MenuName = txbMenuName.Text.Trim();
            modelMenu.MenuUrl = txbMenuUrl.Text.Trim();
            modelMenu.ParentID = ddlFatherMenu.SelectedValue;
            if (txbSortNo.Text.Trim() != "")
            {
                modelMenu.SortNo = int.Parse(txbSortNo.Text);
            }
            else
            {
                modelMenu.SortNo = 1;
            }
            modelMenu.State = "0";
            modelMenu.ImageUrl = null;

            if (bllMenu.Update(modelMenu)) 
            {
                Alert.ShowInTop("修改成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else {
                Alert.ShowInTop("修改失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
        }

        /// <summary>
        /// 后台表单校验
        /// </summary>
        /// <returns></returns>
        protected bool checkForm()
        {
            if (ddlFatherMenu.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择上级菜单");
                return false;
            }
            return true;
        }
    }
}