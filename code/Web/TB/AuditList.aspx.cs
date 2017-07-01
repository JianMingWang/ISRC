using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FineUI;
using ISRC.Web.Code;

namespace ISRC.Web.TB
{
    public partial class AuditList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedReportID"] = "-1";
            if (!IsPostBack)
            {
                nbxYear.Text = DateTime.Now.Year.ToString();
                gridAudit.SortField = "ID";
                BindGrid();
                LoadData(Session["selectedReportID"].ToString());
            }
        }

        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(ddlCycle.SelectedIndex);
            int month = Convert.ToInt16(DateTime.Now.Month);
            PublicMethod.cycleList(ddlCycleList, ddlCycle.SelectedValue.ToString().Trim());
            PublicMethod.SetDdlSelected(index, month, ddlCycleList);
            ddlCycleList.Label = "";
        }
        protected void nbxYear_TextChanged(object sender, EventArgs e)
        {
            if (nbxYear.Text == "")
            {
                nbxYear.Text = DateTime.Now.Year.ToString();
            }
        }

        //初始化主表
        protected void BindGrid()
        {
            string strWhere = string.Format(" Status='1' ORDER BY FillDate DESC ");

            BLL.vw_Report_Dept_Account bllReport = new BLL.vw_Report_Dept_Account();
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

            gridAudit.DataSource = dtSource;
            gridAudit.DataBind();
        }
        //初始化子表
        protected void LoadData(string reportID)
        {
            if (reportID != "-1")
            {
                string strWhere = string.Format("ReportID='" + reportID + "'");

                BLL.vw_SubReport_Index bllSubIndex = new BLL.vw_SubReport_Index();
                DataSet dsSubIndex = bllSubIndex.GetList(strWhere);
                DataTable dtSource = dsSubIndex.Tables[0];

                gridAuditIndex.DataSource = dtSource;
                gridAuditIndex.DataBind();
            }
            else
            {
                gridAuditIndex.DataSource = null;
                gridAuditIndex.DataBind();
            }
        }

        //选择主表行
        protected void gridAudit_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            Session["selectedReportID"] = gridAudit.Rows[e.RowIndex].DataKeys[0].ToString();
            LoadData(Session["selectedReportID"].ToString());
        }

        protected void gridAudit_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Return")
            {
                string ID = gridAudit.Rows[e.RowIndex].DataKeys[0].ToString();
                BLL.T_Report bllReport = new BLL.T_Report();
                bool result = bllReport.Update("2", ID);
                if (result)
                {
                    Alert.ShowInTop("退审成功", "信息", MessageBoxIcon.Information);
                    BindGrid();
                    Session["selectedReprotID"] = "-1";
                    LoadData(Session["selectedReportID"].ToString());
                }
                else
                {
                    Alert.ShowInTop("退审失败", "错误", MessageBoxIcon.Error);
                }
            }
        }

        protected void gridAudit_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridAudit.SortDirection = e.SortDirection;
            gridAudit.SortField = e.SortField;
            BindGrid();
        }
        protected void gridAudit_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            gridAudit.PageIndex = e.NewPageIndex;
        }
        protected void gridAuditIndex_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            gridAuditIndex.SortDirection = e.SortDirection;
            gridAuditIndex.SortField = e.SortField;
            LoadData(Session["selectedReportID"].ToString());
        }
        protected void gridAuditIndex_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            gridAuditIndex.PageIndex = e.NewPageIndex;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cycle = ddlCycle.SelectedValue.ToString().Trim();
            string year = nbxYear.Text.Trim();
            string period = "";
            if (cycle != "4" && cycle != "0")
            {
                period = ddlCycleList.SelectedValue.ToString().Trim();
            }

            StringBuilder strWhere = new StringBuilder();
            //未选择全部报表类型时
            if (cycle != "0")
            {
                strWhere.Append(" Cycle='" + cycle + "' and ");
            }
            strWhere.Append(" Year='" + year + "'");
            if (cycle == "1")
            {
                strWhere.Append(" and Month='" + period + "'");
            }
            else if (cycle == "2")
            {
                strWhere.Append(" and Quarter='" + period + "'");
            }
            else if (cycle == "3")
            {
                strWhere.Append(" and SemiYear='" + period + "'");
            }
            strWhere.Append(" and Status='1' ORDER BY FillDate DESC ");

            BLL.vw_Report_Dept_Account bllReport = new BLL.vw_Report_Dept_Account();
            DataSet dsReport = bllReport.GetList(strWhere.ToString());
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

            gridAudit.DataSource = dtSource;
            gridAudit.DataBind();
            Session["selectedReportID"] = "-1";
            LoadData(Session["selectedReportID"].ToString());
            btnReturn.Hidden = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            BindGrid();
            Session["selectedReportID"] = "-1";
            LoadData(Session["selectedReportID"].ToString());
            btnReturn.Hidden = true;
        }
    }
}