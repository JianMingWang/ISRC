using FineUI;
using System;
using System.Data;
using System.Web.UI;

namespace ISRC.Web.SYS.Role
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnAdd.OnClientClick = windowAdd.GetShowReference("Add.aspx", "新增角色");
                btnDelete.OnClientClick = gridRole.GetNoSelectionAlertReference("至少选择一项！");

                BindGrid();
            }
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        protected void BindGrid()
        {
            string sortField = gridRole.SortField;
            string sortDirection = gridRole.SortDirection;

            string strWhere = string.Format(" 1=1 ORDER BY SortNo");

            BLL.T_Sys_Role bllRole = new BLL.T_Sys_Role();

            DataSet ds = bllRole.GetList(strWhere);
            DataTable dt = ds.Tables[0];

            DataView  dv = dt.DefaultView;
            if (!String.IsNullOrEmpty(sortField))
            {
                dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
            }

            gridRole.DataSource = dv;
            gridRole.DataBind();
        }

        /// <summary>
        /// Grid指定列的排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridRole_Sort(object sender, GridSortEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// Grid翻页，内存分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridRole_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridRole.PageIndex = e.NewPageIndex;
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
            int selectIndex = gridRole.SelectedRowIndexArray[0];
            string id = gridRole.DataKeys[selectIndex][0].ToString();

            //检查该菜单是否为其他菜单的父菜单
            BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();
            if (bllAccount.GetRecordCount(" RoleID='" + id + "'") > 0)
            {
                Alert.ShowInTop("不可删除，该角色下存在用户", "错误", MessageBoxIcon.Error);
                return;
            }

            BLL.T_Sys_Role bllRole = new BLL.T_Sys_Role();
            if (bllRole.Delete(id))
            {
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
            }
        }
    }
}