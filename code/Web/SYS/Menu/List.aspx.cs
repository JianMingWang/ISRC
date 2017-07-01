using FineUI;
using System;
using System.Data;
using System.Web.UI;

namespace ISRC.Web.SYS.Menu
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnAdd.OnClientClick = windowAdd.GetShowReference("Add.aspx", "新增系统菜单");
                btnDelete.OnClientClick = gridMenu.GetNoSelectionAlertReference("至少选择一项！");

                BindGrid();
            }
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        protected void BindGrid()
        {
            string sortField = gridMenu.SortField;
            string sortDirection = gridMenu.SortDirection;

            string strWhere = string.Format(" ID <> '0' ORDER BY ParentID , SortNo");

            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();

            DataSet ds = bllMenu.GetList(strWhere);
            DataTable dt = ds.Tables[0];

            DataView dv = dt.DefaultView;
            if (!String.IsNullOrEmpty(sortField))
            {
                dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
            }

            gridMenu.DataSource = dv;
            gridMenu.DataBind();
        }

        /// <summary>
        /// Grid指定列的排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMenu_Sort(object sender, GridSortEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// Grid翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMenu_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridMenu.PageIndex = e.NewPageIndex;
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
            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();
            int selectIndex = gridMenu.SelectedRowIndexArray[0];
            string id = gridMenu.DataKeys[selectIndex][0].ToString();

            //检查该菜单是否为其他菜单的父菜单
            if (bllMenu.GetRecordCount(" ParentID='"+id+"'")>0)
            {
                Alert.ShowInTop("不可删除，该菜单下存在子菜单", "错误", MessageBoxIcon.Error);
                return;
            }

            if (bllMenu.Delete(id))
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
        /// 获取上级菜单名称
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetFatherMenuName(string parentId) {
            if (parentId == "" || parentId == null)
                return "";
            if (parentId == "0")
            {
                return "根项";
            }
            else {
                return new BLL.T_Sys_Menu().GetModel(parentId).MenuName;
            }        
        }
    }
}