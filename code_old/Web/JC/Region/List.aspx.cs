using FineUI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using System.Linq;

namespace ISRC.Web.JC.Region
{
    public partial class List : PageBase
    {
        ISRC.BLL.T_Region bll = new ISRC.BLL.T_Region();

        protected void Page_Load(object sender, EventArgs e)
        {
            //无法弹出
            //编辑页面未做
            //btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "增加地区");
            //btnDelete.OnClientClick = gridRegion.GetNoSelectionAlertReference("至少选择一项！");
            if (!Page.IsPostBack)
            {
                gridRegion.SortField = "ID";
                BindGrid();
                btnAdd.OnClientClick += windowPop.GetShowReference("Add.aspx", "增加地区");
                btnDelete.OnClientClick = gridRegion.GetNoSelectionAlertReference("至少选择一项！");
            }
            //btnAdd.OnClientClick += windowPop.GetShowReference("Add.aspx", "增加地区");
            //btnDelete.OnClientClick = gridRegion.GetNoSelectionAlertReference("至少选择一项！");
        }
        protected void BindGrid()
        {
            string strWhere = string.Format("1=1 ORDER BY CONVERT(int,ID)");

            BLL.T_Region bllRegion = new BLL.T_Region();
            DataSet dsRegion = bllRegion.GetList(strWhere);
            DataTable dtSource = dsRegion.Tables[0];

            gridRegion.DataSource = dtSource;
            gridRegion.DataBind();
        }

        protected void gridRegion_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridRegion.SortDirection = e.SortDirection;
            gridRegion.SortField = e.SortField;
            BindGrid();
        }


        //删除操作
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.T_Region bllRegion = new BLL.T_Region();

            //注意此处：多页删除时，默认为第一页，需根据页码计算行数
            string id = gridRegion.DataKeys[gridRegion.SelectedRowIndex][0].ToString();
            bool result = bllRegion.Delete(id);
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

        protected void windowPop_Close(object sender, WindowCloseEventArgs e)
        {
            this.BindGrid();
        }
    }
}