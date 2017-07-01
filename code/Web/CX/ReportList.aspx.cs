using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ISRC.Web.Code;
using System.Data;
using System.IO;
using System.Text;
using ISRC;
using FineUI;

namespace ISRC.Web.CX
{


    public partial class ReportList : PageBase
    {
        /// <summary>
        /// 供前台使用
        /// </summary>
        protected string htmlString = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nbxYear.Text = DateTime.Now.Year.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //导出报表按钮
            btnExport.Enabled = true;

            string strWhere = GetCxString();
            strWhere += " ORDER BY DeptName";

            BLL.vw_CX_ReportDetails bllReportDetails = new BLL.vw_CX_ReportDetails();
            DataSet ds = bllReportDetails.GetList(strWhere);
            DataTable dtSource = ds.Tables[0];

            foreach (DataRow row in dtSource.Rows)
            {
                //row["IndexValue"] += "万元";
                if (row["Status"].ToString() == "0")
                {
                    row["Status"] = "未提交";
                }
                else if (row["Status"].ToString() == "1")
                {
                    row["Status"] = "已提交";
                }
                else
                {
                    row["Status"] = "退审";
                }
            }

            girdReporDetail.DataSource = dtSource;
            girdReporDetail.DataBind();
            htmlString = GetTable();
        }

        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //禁用导出按钮
            btnExport.Enabled = false;

            int index = Convert.ToInt16(ddlCycle.SelectedIndex);
            int month = Convert.ToInt16(DateTime.Now.Month);
            PublicMethod.cycleList(ddlCycleList, ddlCycle.SelectedValue.ToString().Trim());
            if (index == 0)
            {
                ddlCycleList.Hidden = true;
                btnSearch.Enabled = false;
            }
            else if (index == 4)
            {
                ddlCycleList.Hidden = true;
                btnSearch.Enabled = true;
            }
            else if (index == 1)
            {
                ddlCycleList.SelectedIndex = month - 1;
                btnSearch.Enabled = true;
            }
            else if (index == 2)
            {
                btnSearch.Enabled = true;
                if (month >= 1 && month <= 3)
                {
                    ddlCycleList.SelectedIndex = 0;
                }
                else if (month >= 4 && month <= 6)
                {
                    ddlCycleList.SelectedIndex = 1;
                }
                else if (month >= 7 && month <= 9)
                {
                    ddlCycleList.SelectedIndex = 2;
                }
                else if (month >= 10 && month <= 12)
                {
                    ddlCycleList.SelectedIndex = 3;
                }
            }
            else if (index == 3)
            {
                btnSearch.Enabled = true;
                if (month >= 1 && month <= 6)
                {
                    ddlCycleList.SelectedIndex = 1;
                }
                else if (month >= 7 && month <= 12)
                {
                    ddlCycleList.SelectedIndex = 1;
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string xlsName = "武汉市科技金融主要指标统计表(";
            xlsName += ddlCycle.SelectedText.ToString() + ")";
            xlsName += nbxYear.Text.ToString() + "年" + ddlCycleList.SelectedText.ToString();
            xlsName += ".xls";

            Response.ClearContent();

            //HttpUtility.UrlEncode(文件名, Encoding.UTF8).ToString()   防止文件名乱码
            Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(xlsName, Encoding.UTF8).ToString());

            //防止文件内容乱码
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/octet-stream; charset=utf-8";
            Response.Write(DataTableToExcel(girdReporDetail));
            Response.End();
        }

        /// <summary>
        /// 生成报表，将DataTable转为Table，用Excel导出
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private string DataTableToExcel(Grid grid)
        {
            //导出Excel
            string strWhere = GetCxString();
            strWhere += " ORDER BY FatherIndex_Name";

            BLL.vw_CX_ReportDetails bllReportDetails = new BLL.vw_CX_ReportDetails();
            DataSet ds = bllReportDetails.GetList(strWhere);
            DataTable dtSource = ds.Tables[0];

            foreach (DataRow row in dtSource.Rows)
            {
                row["IndexName"] += "(万元)";
                if (row["Status"].ToString() == "0")
                {
                    row["Status"] = "未提交";
                }
                else if (row["Status"].ToString() == "1")
                {
                    row["Status"] = "已提交";
                }
                else
                {
                    row["Status"] = "退审";
                }
            }

            //生成HTML代码
            //样式只能卸载table后   以及tr后，不可写在其他地方，且部分样式在Excel无法显示
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"1px\" >");
            sb.Append("<tr><th scope=\"col\" colspan=\"5\">武汉市科技金融主要指标统计表</th></tr>");

            sb.AppendFormat("<tr><th>{0}</th>", "类别");
            sb.AppendFormat("<th>{0}</th>", "指标");
            sb.AppendFormat("<th>{0}</th>", "数值");
            sb.AppendFormat("<th>{0}</th>", "填报单位");
            sb.AppendFormat("<th>{0}</th>", "备注");
            sb.Append("</tr>");

            //分析报表数据
            List<String> FatherIndex_Name = new List<string>();
            Dictionary<string, int> FIName_Num = new Dictionary<string, int>();

            foreach (DataRow row in dtSource.Rows)
            {
                string FIName = row["FatherIndex_Name"].ToString();
                if (FatherIndex_Name.Count == 0)
                {
                    FatherIndex_Name.Add(FIName);
                }
                else
                {
                    bool flag = true;
                    foreach (string strName in FatherIndex_Name)
                    {
                        if (FIName == strName)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        FatherIndex_Name.Add(FIName);
                    }
                }
            }
            foreach (string FIName in FatherIndex_Name)
            {
                int i = 0;
                foreach (DataRow row in dtSource.Rows)
                {
                    if (FIName == row["FatherIndex_Name"].ToString())
                    {
                        i++;
                    }
                }
                FIName_Num.Add(FIName, i);
            }

            int dtRow = 0;
            foreach (string FIName in FatherIndex_Name)
            {
                for (int i = 0; i < FIName_Num[FIName]; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<th rowspan=" + FIName_Num[FIName] + ">");
                        sb.Append(FIName);
                        sb.Append("</th>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["IndexName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["IndexValue"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["DeptName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["Expr2"].ToString());
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        dtRow++;
                    }
                    else
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["IndexName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["IndexValue"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["DeptName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(dtSource.Rows[dtRow]["Expr2"].ToString());
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        dtRow++;
                    }
                }
            }
            sb.Append("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 年份改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void nbxYear_TextChanged(object sender, EventArgs e)
        {
            if (nbxYear.Text == "")
            {
                nbxYear.Text = DateTime.Now.Year.ToString();
            }
        }

        /// <summary>
        /// 供前台使用
        /// </summary>
        /// <returns></returns>
        protected string GetTable()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<thead class=\"theadSepcial\"><tr><th class=\"thead-title\" scope=\"col\" colspan=\"7\">武汉市科技金融主要指标统计表</th></tr>");

            sb.Append("<tr>");
            sb.AppendFormat("<th class=\"theadthSepcial\" scope=\"col\">类别</th>");
            sb.AppendFormat("<th class=\"theadthSepcial\" scope=\"col\">指标</th>");
            sb.AppendFormat("<th class=\"theadthSepcial\" scope=\"col\">数值</th>");
            sb.AppendFormat("<th class=\"theadthSepcial\" scope=\"col\">填报单位</th>");
            sb.AppendFormat("<th class=\"theadthSepcial\" scope=\"col\">备注</th>");
            sb.Append("</tr></thead>");

            if (IsPostBack)
            {
                string strWhere = Session["strWhere"].ToString();

                //strWhere += " ORDER BY DeptName";

                BLL.vw_CX_ReportDetails bllReportDetails = new BLL.vw_CX_ReportDetails();
                DataSet ds = bllReportDetails.GetList(strWhere);
                DataTable dtSource = ds.Tables[0];

                foreach (DataRow row in dtSource.Rows)
                {
                    row["IndexName"] += "(万元)";
                    if (row["Status"].ToString() == "0")
                    {
                        row["Status"] = "未提交";
                    }
                    else if (row["Status"].ToString() == "1")
                    {
                        row["Status"] = "已提交";
                    }
                    else
                    {
                        row["Status"] = "退审";
                    }
                }

                //生成HTML代码
                //分析报表数据
                List<String> FatherIndex_Name = new List<string>();
                Dictionary<string, int> FIName_Num = new Dictionary<string, int>();

                foreach (DataRow row in dtSource.Rows)
                {
                    string FIName = row["FatherIndex_Name"].ToString();
                    if (FatherIndex_Name.Count == 0)
                    {
                        FatherIndex_Name.Add(FIName);
                    }
                    else
                    {
                        bool flag = true;
                        foreach (string strName in FatherIndex_Name)
                        {
                            if (FIName == strName)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            FatherIndex_Name.Add(FIName);
                        }
                    }
                }
                foreach (string FIName in FatherIndex_Name)
                {
                    int i = 0;
                    foreach (DataRow row in dtSource.Rows)
                    {
                        if (FIName == row["FatherIndex_Name"].ToString())
                        {
                            i++;
                        }
                    }
                    FIName_Num.Add(FIName, i);
                }

                int dtRow = 0;
                foreach (string FIName in FatherIndex_Name)
                {
                    for (int i = 0; i < FIName_Num[FIName]; i++)
                    {
                        if (i == 0)
                        {
                            sb.Append("<tr class=\"trSepcial\">");
                            sb.Append("<td rowspan=" + FIName_Num[FIName] + ">");
                            sb.Append(FIName);
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["IndexName"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["IndexValue"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["DeptName"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["Expr2"].ToString());
                            sb.Append("</td>");
                            sb.Append("</tr>");
                            dtRow++;
                        }
                        else
                        {
                            sb.Append("<tr class=\"trSepcial\">>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["IndexName"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["IndexValue"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["DeptName"].ToString());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append(dtSource.Rows[dtRow]["Expr2"].ToString());
                            sb.Append("</td>");
                            sb.Append("</tr>");
                            dtRow++;
                        }
                    }
                }
            }

            htmlString = sb.ToString();
            return htmlString;
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <returns></returns>
        private string GetCxString()
        {
            int index = Convert.ToInt16(ddlCycle.SelectedIndex);
            string strWhere = "";

            if (index == 1)
            {
                if (ddlStatus.SelectedValue.ToString() == "-1")
                {
                    strWhere += " Cycle='1' and " + "Year='" + nbxYear.Text.ToString() + "' and Month='" + Convert.ToString(ddlCycleList.SelectedIndex + 1) + "'";
                }
                else
                {
                    strWhere += " Cycle='1' and " + "Year='" + nbxYear.Text.ToString() + "' and Month='" + Convert.ToString(ddlCycleList.SelectedIndex + 1) + "' and Status = '" + ddlStatus.SelectedValue.ToString() + "'";
                }
            }
            else if (index == 2)
            {
                if (ddlStatus.SelectedValue.ToString() == "-1")
                {
                    strWhere += " Cycle='2' and " + "Year='" + nbxYear.Text.ToString() + "' and Quarter='" + Convert.ToString(ddlCycleList.SelectedIndex + 1) + "'";
                }
                else
                {
                    strWhere += " Cycle='2' and " + "Year='" + nbxYear.Text.ToString() + "' and Quarter='" + Convert.ToString(ddlCycleList.SelectedIndex + 1) + "' and Status = '" + ddlStatus.SelectedValue.ToString() + "'";
                }
            }
            else if (index == 3)
            {
                if (ddlStatus.SelectedValue.ToString() == "-1")
                {
                    strWhere += " Cycle='3' and " + "Year='" + nbxYear.Text.ToString() + "' and SemiYear='" + ddlCycleList.SelectedText.ToString() + "'";
                }
                else
                {
                    strWhere += " Cycle='3' and " + "Year='" + nbxYear.Text.ToString() + "' and SemiYear='" + ddlCycleList.SelectedText.ToString() + "' and Status = '" + ddlStatus.SelectedValue.ToString() + "'";
                }
            }
            else if (index == 4)
            {
                if (ddlStatus.SelectedValue.ToString() == "-1")
                {
                    strWhere += " Cycle='4' and " + "Year='" + nbxYear.Text.ToString() + "'";
                }
                else
                {
                    strWhere += " Cycle='4' and " + "Year='" + nbxYear.Text.ToString() + "' and Status = '" + ddlStatus.SelectedValue.ToString() + "'";
                }
            }
            Session["strWhere"] = strWhere;
            return strWhere;
        }

        /// <summary>
        /// 必须包含的方法，否则导出Excel会报错
        /// </summary>
        /// <param name="control"></param>
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}