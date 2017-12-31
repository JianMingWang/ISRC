using FineUI;
using ISRC.Web.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ISRC.Web.TB
{
    public partial class Modefy : System.Web.UI.Page
    {
        private StringBuilder reportID = new StringBuilder();
        private StringBuilder conditionIndex = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LodaData();
            }
        }
        private void LodaData()
        {
            reportID.Append("T_Report.ID='").Append(Request.QueryString["id"].ToString()).Append("'");


            #region 父表
            BLL.T_Report bllReport = new BLL.T_Report();
            DataSet dsReport = bllReport.GetList(reportID.ToString());
            DataTable dtReport = dsReport.Tables[0];
            
            string cycle = dtReport.Rows[0]["Cycle"].ToString();
            string year = dtReport.Rows[0]["Year"].ToString();
            string period = "";

            txbID.Text = dtReport.Rows[0]["ID"].ToString();
            nbxYear.Text = year;
            ddlCycle.SelectedValue = cycle;
            if (cycle != "4")
            {
                ddlCycleList.Hidden = false;
                PublicMethod.cycleList(ddlCycleList, cycle);
                string type = PublicMethod.getKey("CycleType", cycle);
                period = dtReport.Rows[0][type].ToString();
                ddlCycleList.SelectedIndex = Convert.ToInt16(period) - 1;
                

            }
            dapFillDate.Text = dtReport.Rows[0]["FillDate"].ToString();
            ddlStatus.SelectedValue = dtReport.Rows[0]["Status"].ToString();
            txaDescription.Text = dtReport.Rows[0]["Description"].ToString();
            #endregion

            bllReport.SubReport(cycle, year, period, Session["DeptID"].ToString(), "", "", "");

            #region 子表
            string strWhere = "ReportID='" + Request.QueryString["id"].ToString() + "'";
            BLL.vw_SubReport_Index bllSubReport = new BLL.vw_SubReport_Index();
            DataSet dsSubReport = bllSubReport.GetList(strWhere);
            DataTable dtSubReport = dsSubReport.Tables[0];
            gridIndex.DataSource = dtSubReport;
            gridIndex.DataBind();
            #endregion
        }

        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlCycle.SelectedValue;
            PublicMethod.cycleList(ddlCycleList, selected.ToString().Trim());
            if (selected == "4")
            {
                ddlCycleList.Hidden = true;
            }
        }

        protected void gridIndex_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridIndex.PageIndex = e.NewPageIndex;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 更新主表
            BLL.T_Report bllReport = new BLL.T_Report();
            bool result1 = false;
            result1 = bllReport.Update(dapFillDate.Text.Trim(), ddlStatus.SelectedValue.ToString().Trim(), txaDescription.Text.Trim(), Request.QueryString["id"].ToString());
            #endregion

            #region 更新子表
            BLL.T_SubReport bllSubReport = new BLL.T_SubReport();
            Dictionary<int, Dictionary<string, object>> ModifiedDict = gridIndex.GetModifiedDict();
            bool result2 = true;
            if (ModifiedDict.Count !=0)
            {
                result2 = false;
                foreach (int rowIndex in ModifiedDict.Keys)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update T_SubReport set ");
                    if (ModifiedDict[rowIndex].ContainsKey("IndexValue"))
                    {
                        strSql.Append(" IndexValue='" + ModifiedDict[rowIndex]["IndexValue"].ToString() + "' ");
                    }
                    if (ModifiedDict[rowIndex].ContainsKey("Description"))
                    {
                        if (ModifiedDict[rowIndex].ContainsKey("IndexValue"))
                        {
                            strSql.Append(",");
                        }
                        strSql.Append(" Description='" + ModifiedDict[rowIndex]["Description"].ToString() + "' ");
                    }
                    strSql.Append(" where ID='" + gridIndex.Rows[rowIndex].DataKeys[0].ToString() + "'");
                    result2 = bllSubReport.Update(strSql.ToString());
                }
            }
            #endregion
            if (result1&&result2)
            {
                Alert.ShowInTop("更新成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("更新失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }

        }
    }
}