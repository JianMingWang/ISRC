using FineUI;
using ISRC.Web.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;

namespace ISRC.Web.TB
{
    public partial class List : PageBase
    {
        //检查报表状态，记录已提交报表的Index，将对应的按钮功能禁用
        private List<int> statusIndex = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedReportID"] = "-1";
            btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增报表");
            if (!Page.IsPostBack)
            {
                nbxStartYear.Text = DateTime.Now.Year.ToString();
                nbxEndYear.Text = DateTime.Now.Year.ToString();
                gridTBFather.SortField = "ID";
                BindGrid();
                LoadData(Session["selectedReportID"].ToString());
            }
        }

        protected void nbxStartYear_TextChanged(object sender, EventArgs e)
        {
            if (nbxStartYear.Text == "")
            {
                nbxStartYear.Text = DateTime.Now.Year.ToString();
            }
        }
        protected void nbxEndYear_TextChanged(object sender, EventArgs e)
        {
            if (nbxEndYear.Text == "")
            {
                nbxEndYear.Text = DateTime.Now.Year.ToString();
            }
        }

        //初始化主表
        protected void BindGrid()
        {
            //未加时间条件、
            string strWhere = string.Format("(Status='0' or Status='2') and DeptID='" + Session["DeptID"].ToString() + "' ORDER BY FillDate DESC");

            BLL.T_Report bllReport = new BLL.T_Report();
            DataSet dsReport = bllReport.GetList(strWhere);
            DataTable dtSource = dsReport.Tables[0];
            foreach (DataRow row in dtSource.Rows)
            {
                row["Cycle"] = PublicMethod.getKey("Cycle", row["Cycle"].ToString().Trim());
                row["Year"] = row["Year"].ToString().Trim() + "年";
                row["Month"] = PublicMethod.getKey("Month", row["Month"].ToString().Trim());
                row["Quarter"] = PublicMethod.getKey("Quarter", row["Quarter"].ToString().Trim());
                row["SemiYear"] = PublicMethod.getKey("SemiYear", row["SemiYear"].ToString().Trim());
                row["Status"] = PublicMethod.getKey("TB_Status", row["Status"].ToString().Trim());
            }

            gridTBFather.DataSource = dtSource;
            gridTBFather.DataBind();
        }
        //初始化子表
        protected void LoadData(string reportID)
        {
            if (reportID != "-1")
            {
                string strWhere = " ReportID='" + reportID + "' ";
                
                BLL.vw_SubReport_Index bllSubIndex = new BLL.vw_SubReport_Index();
                DataSet dsSubIndex = bllSubIndex.GetList(strWhere);
                DataTable dtSource = dsSubIndex.Tables[0];

                gridTBIndex.DataSource = dtSource;
                gridTBIndex.DataBind();

            }
            else
            {
                gridTBIndex.DataSource = null;
                gridTBIndex.DataBind();
            }
        }

        protected void gridTBFather_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridTBFather.SortDirection = e.SortDirection;
            gridTBFather.SortField = e.SortField;
            BindGrid();
        }
        protected void gridTBFather_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            gridTBFather.PageIndex = e.NewPageIndex;
        }

        protected void gridTBIndex_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridTBIndex.SortDirection = e.SortDirection;
            gridTBIndex.SortField = e.SortField;
            LoadData(Session["selectedReportID"].ToString());
        }
        protected void gridTBIndex_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            gridTBIndex.PageIndex = e.NewPageIndex;
        }

        //选择主表行
        protected void gridTBFather_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            Session["selectedReportID"] = gridTBFather.Rows[e.RowIndex].DataKeys[0].ToString();
            LoadData(Session["selectedReportID"].ToString());
        }

        protected void gridTBFather_RowCommand(object sender, GridCommandEventArgs e)
        {
            //选择提交
            if (e.CommandName == "Submit")
            {
                string ID = gridTBFather.Rows[e.RowIndex].DataKeys[0].ToString();
                BLL.T_Report bllReport = new BLL.T_Report();
                ISRC.Model.T_Report model = bllReport.GetModel(ID);
                if (model.Status == "1")
                {
                    Alert.ShowInTop("该报表已提交", "提示", MessageBoxIcon.Information);
                }
                else
                {
                    bool result = bllReport.Update("1", ID);
                    if (result)
                    {
                        Alert.ShowInTop("提交成功", "信息", MessageBoxIcon.Information);
                        BindGrid();
                        LoadData(Session["selectedReportID"].ToString());
                    }
                    else
                    {
                        Alert.ShowInTop("提交失败", "错误", MessageBoxIcon.Error);
                    }
                }
                
            }
            //选择删除
            else if (e.CommandName == "Delete")
            {
                BLL.T_Report bllReport = new BLL.T_Report();
                BLL.T_SubReport bllSubReport = new BLL.T_SubReport();

                string id = gridTBFather.DataKeys[gridTBFather.PageIndex * gridTBFather.PageSize + gridTBFather.SelectedRowIndex][0].ToString();
                //查看是否被提交，已提交则不能删除
                ISRC.Model.T_Report model = bllReport.GetModel(id);
                if (model.Status == "1")
                {
                    Alert.ShowInTop("该报表已提交，不能删除！", "错误", MessageBoxIcon.Error);
                }
                else
                {
                    bool result2 = bllSubReport.DeleteReportList(id);
                    bool result1 = bllReport.Delete(id);

                    if (result1 && result2)
                    {
                        Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                        Session["selectedReportID"] = "-1";
                        BindGrid();
                        LoadData(Session["selectedReportID"].ToString());
                    }
                    else
                    {
                        Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //如果查询报表状态为已提交、则不能进行编辑、删除、提交等操作
            GridColumn lbDelete = gridTBFather.FindColumn("lbDelete");
            GridColumn lbSubmit = gridTBFather.FindColumn("lbSubmit");
            if (ddlStatus.SelectedValue.ToString() == "1")
            {
                //在gridview中寻找目标列，设置目标列为不可用
                windowEdit.Enabled = false;
                lbDelete.Enabled = false;
                lbSubmit.Enabled = false;
            }
            else
            {
                //在gridview中寻找目标列，设置目标列为可用
                windowEdit.Enabled = true;
                lbDelete.Enabled = true;
                lbSubmit.Enabled = true;
            }

            //查询操作
            string start = nbxStartYear.Text.Trim();
            string end = nbxEndYear.Text.Trim();
            string status = ddlStatus.SelectedValue.ToString().Trim();
            StringBuilder strWhere = new StringBuilder();
            if (status != "all")
            {
                strWhere.Append(" Status='" + status + "' and ");
            }
            strWhere.Append(" Year between '" + start + "' and '" + end + "'");
            strWhere.Append(" ORDER BY Status DESC");//根据报表状态排序

            BLL.T_Report bllReport = new BLL.T_Report();
            DataSet dsReport = bllReport.GetList(strWhere.ToString());
            DataTable dtSource = dsReport.Tables[0];

            //记录当前循环的是第几行
            int i = 0;
            //遍历数据表，将部分数据的格式规范化展示
            foreach (DataRow row in dtSource.Rows)
            {
                if (row["Status"].ToString() == "1")
                {
                    statusIndex.Add(i);
                }
                row["Cycle"] = PublicMethod.getKey("Cycle", row["Cycle"].ToString().Trim());
                row["Year"] = row["Year"].ToString().Trim() + "年";
                row["Month"] = PublicMethod.getKey("Month", row["Month"].ToString().Trim());
                row["Quarter"] = PublicMethod.getKey("Quarter", row["Quarter"].ToString().Trim());
                row["SemiYear"] = PublicMethod.getKey("SemiYear", row["SemiYear"].ToString().Trim());
                row["Status"] = PublicMethod.getKey("TB_Status", row["Status"].ToString().Trim());
                //行加1
                i++;
            }
            gridTBFather.DataSource = dtSource;
            gridTBFather.DataBind();
            btnReturn.Hidden = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            BindGrid();
            ddlStatus.SelectedIndex = 0;
            Session["selectedReportID"] = "-1";
            LoadData(Session["selectedReportID"].ToString());
            btnReturn.Hidden = true;
        }

        //窗口关闭
        protected void windowPop_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindGrid();
            LoadData(Session["selectedReportID"].ToString());
        }

        /// <summary>
        /// 禁用提交按钮、删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridTBFather_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            LinkButtonField lbDelete = gridTBFather.FindColumn("lbDelete") as LinkButtonField;
            LinkButtonField lbSubmit = gridTBFather.FindColumn("lbSubmit") as LinkButtonField;
            foreach (int i in statusIndex)
            {
                if (i == e.RowIndex)
                {
                    //禁用按钮
                    lbDelete.Enabled = false;
                    lbSubmit.Enabled = false;
                    windowEdit.Enabled = false;
                    return;
                }
            }
            //启用按钮
            lbDelete.Enabled = true;
            lbSubmit.Enabled = true;
            windowEdit.Enabled = true;
        }
    }
}