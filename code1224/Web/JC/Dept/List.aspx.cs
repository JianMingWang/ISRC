using FineUI;
using System;
using System.Data;
using System.Web.UI;

namespace ISRC.Web.T_Dept
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增填报单位");
            btnDelete.OnClientClick = gridDept.GetNoSelectionAlertReference("至少选择一项！");
            if (!Page.IsPostBack)
            {
                gridDept.SortField = "ID";
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            string strWhere = string.Format("1=1 ORDER BY T_Dept.OderID,CONVERT(int,T_Dept.ID)");//ORDER BY CONVERT(int,T_Dept.OderID)

            BLL.T_Dept bllDept = new BLL.T_Dept();
            DataSet dsDept = bllDept.GetList(strWhere);
            DataTable dtSource = dsDept.Tables[0];

            gridDept.DataSource = dtSource;
            gridDept.DataBind();
        }

        protected void gridDept_Sort(object sender, GridSortEventArgs e)
        {
            gridDept.SortDirection = e.SortDirection;
            gridDept.SortField = e.SortField;
            BindGrid();
        }

        protected void gridDept_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridDept.PageIndex = e.NewPageIndex;
            //this.BindGrid();
        }

        protected void windowPop_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.T_Dept bllDept = new BLL.T_Dept();

            //注意此处：多也删除时，默认为第一页，需根据页码计算行数
            string id = gridDept.DataKeys[gridDept.PageIndex * gridDept.PageSize + gridDept.SelectedRowIndex][0].ToString();
            bool result = bllDept.Delete(id);
            if (result)
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
