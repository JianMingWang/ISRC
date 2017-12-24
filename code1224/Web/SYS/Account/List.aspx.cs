using FineUI;
using System;
using System.Data;
using System.Web.UI;

namespace ISRC.Web.SYS.Account
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnAdd.OnClientClick = windowAdd.GetShowReference("Add.aspx", "新增用户账号");
                btnDelete.OnClientClick = gridAccount.GetNoSelectionAlertReference("至少选择一项！");

                BindGrid();
            }
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        protected void BindGrid()
        {
            string sortField = gridAccount.SortField;
            string sortDirection = gridAccount.SortDirection;

            string strWhere = string.Format(" 1=1 ORDER BY DeptID , SortNo");

            BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();

            DataSet ds = bllAccount.GetList(strWhere);
            DataTable dt = ds.Tables[0];

            DataView dv = dt.DefaultView;
            if (!String.IsNullOrEmpty(sortField))
            {
                dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
            }

            gridAccount.DataSource = dv;
            gridAccount.DataBind();
        }

        /// <summary>
        /// Grid指定列的排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAccount_Sort(object sender, GridSortEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// Grid翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAccount_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridAccount.PageIndex = e.NewPageIndex;
            //this.BindGrid();
        }

        /// <summary>
        /// 弹出窗口关闭，需重新绑定Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void windowPop_Close(object sender, WindowCloseEventArgs e)
        {
            this.BindGrid();
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();
            int selectIndex = gridAccount.SelectedRowIndexArray[0];
            string id = gridAccount.DataKeys[selectIndex][0].ToString();

            if (bllAccount.Delete(id))
            {
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetDeptName(string deptId)
        {
            if (deptId == "" || deptId == null)
                return "";
            else
            {
                return new BLL.T_Dept().GetModel(deptId).Name;
            }
        }

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetRoleName(string roleId)
        {
            if (roleId == "" || roleId == null)
                return "";
            else
            {
                return new BLL.T_Sys_Role().GetModel(roleId).RoleName;
            }
        }
    }
}