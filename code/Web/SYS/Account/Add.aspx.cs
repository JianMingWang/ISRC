using FineUI;
using System;
using System.Data;

namespace ISRC.Web.SYS.Account
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                Bind_ddlDept();
                Bind_ddlRole();
            }
        }

        /// <summary>
        /// 初始化所属单位下拉框
        /// </summary>
        protected void Bind_ddlDept()
        {
            BLL.T_Dept bllDept = new BLL.T_Dept();
            DataSet ds = bllDept.GetList(" 1=1 order by OderID ASC ");
            DataRow row = ds.Tables[0].NewRow();
            row["ID"] = "-1";
            row["Name"] = "请选择";
            ds.Tables[0].Rows.InsertAt(row, 0);
            ddlDept.DataSource = ds.Tables[0];
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "ID";
            ddlDept.DataBind();
        }

        /// <summary>
        /// 初始化角色下拉框
        /// </summary>
        protected void Bind_ddlRole()
        {
            BLL.T_Sys_Role bllRole = new BLL.T_Sys_Role();
            DataSet ds = bllRole.GetList(" 1=1 order by SortNo ASC ");
            DataRow row = ds.Tables[0].NewRow();
            row["ID"] = "-1";
            row["RoleName"] = "请选择";
            ds.Tables[0].Rows.InsertAt(row, 0);
            ddlRole.DataSource = ds.Tables[0];
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "ID";
            ddlRole.DataBind();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkForm()) return;

            BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();
            Model.T_Sys_Account modelAccount = new Model.T_Sys_Account();

            modelAccount.ID = System.Guid.NewGuid().ToString();
            modelAccount.Account = txbAccount.Text.Trim();
            modelAccount.AccountPsw = txbPsw.Text.Trim();
            modelAccount.TrueName = txbTrueName.Text.Trim();

            modelAccount.DeptID = ddlDept.SelectedValue;
            modelAccount.RoleID = ddlRole.SelectedValue;

            if (txbSortNo.Text.Trim() != "")
            {
                modelAccount.SortNo = int.Parse(txbSortNo.Text);
            }
            else
            {
                modelAccount.SortNo = 1;
            }
            modelAccount.State = "0";

            if (bllAccount.Add(modelAccount))
            {
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
        }

        /// <summary>
        /// 后台表单校验
        /// </summary>
        /// <returns></returns>
        protected bool checkForm()
        {
            if (ddlDept.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择所属单位");
                return false;
            }
            if (ddlRole.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择角色");
                return false;
            }
            return true;
        }
    }
}