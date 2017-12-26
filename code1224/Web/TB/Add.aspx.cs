using FineUI;
using ISRC.Web.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ISRC.Web.TB
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                dapFillDate.SelectedDate = DateTime.Now;
                nbxYear.Text = DateTime.Now.Year.ToString();
            }
        }

        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(ddlCycle.SelectedIndex);
            int month = Convert.ToInt16(DateTime.Now.Month);
            PublicMethod.cycleList(ddlCycleList, ddlCycle.SelectedValue.ToString().Trim());
            PublicMethod.SetDdlSelected(index, month, ddlCycleList);
        }

        protected void nbxYear_TextChanged(object sender, EventArgs e)
        {
            if (nbxYear.Text == "")
            {
                nbxYear.Text = DateTime.Now.Year.ToString();
            }
        }

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            if (nbxYear.Text == "" || ddlCycle.SelectedIndex == 0 || dapFillDate.Text == "")
            {
                Alert.ShowInTop("主表信息填写不完整！", "警告", MessageBoxIcon.Warning);
            }
            else
            {
                #region 点击增加指标后 禁用报表类型下拉框
                ddlCycle.Enabled = false;
                #endregion

                BLL.T_Report bllReport = new BLL.T_Report();
                BLL.vw_Dept_Index bllDeptIndex = new BLL.vw_Dept_Index();

                string cycle = ddlCycle.SelectedValue.ToString().Trim();
                string deptID = Session["DeptID"].ToString();
                string year = nbxYear.Text.Trim();
                string period = "";
                if (ddlCycleList.Hidden == false)
                {
                    period = ddlCycleList.SelectedValue.ToString().Trim();
                }

                #region 查找主表ID
                StringBuilder strSql_ID = new StringBuilder();
                strSql_ID.Append(" Year='" + year + "' and ");
                strSql_ID.Append(" Cycle='" + cycle + "' and ");
                strSql_ID.Append(" DeptID='" + Session["DeptID"].ToString() + "' ");
                if (cycle != "4")
                {
                    strSql_ID.Append(" and ");
                    switch (cycle)
                    {
                        case "1":
                            {
                                strSql_ID.Append(" Month");
                            }
                            break;
                        case "2":
                            {
                                strSql_ID.Append(" Quarter");
                            }
                            break;
                        case "3":
                            {
                                strSql_ID.Append(" SemiYear");
                            }
                            break;
                        default:
                            break;
                    }
                    strSql_ID.Append("='" + period + "' ");
                }
                DataSet dsReport = bllReport.GetList(strSql_ID.ToString());
                #endregion

                //是否已存在报表
                if (dsReport.Tables[0].Rows.Count == 1)
                {
                    Session["ReportID"] = dsReport.Tables[0].Rows[0]["ID"].ToString();
                    Model.T_Report model = bllReport.GetModel(Session["ReportID"].ToString());
                    //报表是否提交
                    if (model.Status == "1")
                    {
                        Alert.ShowInTop("报表已存在且已提交！");
                        ActiveWindow.GetHideReference();
                    }
                    else
                    {
                        PageContext.RegisterStartupScript(Confirm.GetShowReference("已存在该报表，是否转到该报表？", "提示",
                        MessageBoxIcon.Question,
                        pageManager_01.GetCustomEventReference("confirm_goto_Y"),
                        pageManager_01.GetCustomEventReference("confirm_goto_N")));
                    }
                }
                else
                {
                    #region 查询报表类型的对应指标
                    StringBuilder strSql_DeptIndex = new StringBuilder();
                    //此处填报指标应包含 不受限 指标
                    strSql_DeptIndex.Append(" Index_Cycle = '" + cycle + "' or Index_Cycle = '0' ");
                    strSql_DeptIndex.Append(" and Dept_ID='" + deptID + "'");
                    DataSet dsDeptIndex = bllDeptIndex.GetList(strSql_DeptIndex.ToString());
                    #endregion

                    //是否存在对应指标
                    if (dsDeptIndex.Tables[0].Rows.Count > 0)
                    {
                        btnIndex.Hidden = true;
                        panelIndex.Hidden = false;
                        #region 保存主子表
                        string userID = Session["AccountID"].ToString();
                        string fillDate = dapFillDate.Text.Trim();
                        string description = txaDescription.Text.Trim();
                        bllReport.SubReport(cycle, year, period, deptID, userID, fillDate, description);
                        #endregion

                        dsReport = null;
                        dsReport = bllReport.GetList(strSql_ID.ToString());
                        Session["ReportID"] = dsReport.Tables[0].Rows[0]["ID"].ToString();

                        #region 显示填报指标列表
                        StringBuilder strSql_Index = new StringBuilder();
                        strSql_Index.Append(" ReportID=(select ID FROM T_Report where ");
                        strSql_Index.Append(" Year='" + year + "' and ");
                        strSql_Index.Append(" Cycle='" + cycle + "' and ");
                        strSql_Index.Append(" DeptID='" + Session["DeptID"].ToString() + "' ");
                        if (cycle != "4")
                        {
                            strSql_Index.Append(" and ");
                            switch (cycle)
                            {
                                case "1":
                                    {
                                        strSql_Index.Append(" Month");
                                    }
                                    break;
                                case "2":
                                    {
                                        strSql_Index.Append(" Quarter");
                                    }
                                    break;
                                case "3":
                                    {
                                        strSql_Index.Append(" SemiYear");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            strSql_Index.Append("='" + period + "' ");
                        }
                        strSql_Index.Append(")");
                        BLL.vw_SubReport_Index bllSubReport = new BLL.vw_SubReport_Index();
                        DataSet dsSubReport = bllSubReport.GetList(strSql_Index.ToString());
                        DataTable dtSubReport = dsSubReport.Tables[0];

                        gridIndex.DataSource = dtSubReport;
                        gridIndex.DataBind();
                        #endregion
                    }
                    else
                    {
                        Alert.ShowInTop("没有要填的指标！", "警告", MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (btnIndex.Hidden == false)
            {
                Alert.ShowInTop("报表信息填写不完整！", "警告", MessageBoxIcon.Error);
            }
            else
            {
                #region 保存指标值
                BLL.T_SubReport bllSubReport = new BLL.T_SubReport();
                Dictionary<int, Dictionary<string, object>> ModifiedDict = gridIndex.GetModifiedDict();
                //是否进行填写指标值
                if (ModifiedDict.Count != 0)
                {
                    foreach (int rowIndex in ModifiedDict.Keys)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update T_SubReport set ");
                        if (ModifiedDict[rowIndex].ContainsKey("IndexValue"))
                        {
                            strSql.Append(" IndexValue='" + ModifiedDict[rowIndex]["IndexValue"].ToString() + "' ");
                        }
                        if (ModifiedDict[rowIndex].ContainsKey("sDescription"))
                        {
                            if (ModifiedDict[rowIndex].ContainsKey("IndexValue"))
                            {
                                strSql.Append(",");
                            }
                            strSql.Append(" Description='" + ModifiedDict[rowIndex]["sDescription"].ToString() + "' ");
                        }
                        strSql.Append(" where ID='" + gridIndex.Rows[rowIndex].DataKeys[0].ToString() + "'");
                        result = bllSubReport.Update(strSql.ToString());
                    }
                    if (result)
                    {
                        Alert.ShowInTop("报表添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
                    }
                    else
                    {
                        Alert.ShowInTop("报表添加失败！", "错误", MessageBoxIcon.Error,
                            ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
                    }
                }
                else
                {
                    Alert.ShowInTop("填报指标值未填写！", "错误", MessageBoxIcon.Error);
                }
                #endregion
            }
        }

        protected void gridIndex_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridIndex.PageIndex = e.NewPageIndex;
        }

        protected void pageManager_01_CustomEvent(object sender, CustomEventArgs e)
        {
            if (e.EventArgument == "confirm_goto_Y")
            {
                Response.Redirect("Modify.aspx?id=" + Session["ReportID"].ToString());
            }
            else if (e.EventArgument == "confirm_goto_N")
            {
                //将禁用的下拉框恢复可用状态
                ddlCycle.Enabled = true;
            }
            else if (e.EventArgument == "confirm_close_Y")
            {
                if (btnIndex.Hidden == true)
                {
                    BLL.T_SubReport bllSubReport = new BLL.T_SubReport();
                    BLL.T_Report bllReport = new BLL.T_Report();
                    bllSubReport.DeleteReportList(Session["ReportID"].ToString());
                    bllReport.Delete(Session["ReportID"].ToString());
                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
            }
        }
    }
}