using FineUI;
using ISRC.Web.CX.jsonModel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ISRC.Web.CX
{
    public partial class MultiIndexList : PageBase
    {
        protected string jsonStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreatCheckBoxList();
                BindTime();
            }
        }

        /// <summary>
        /// 创建指标复选框列表（指标数据导出成树装table）
        /// </summary>
        /// <returns></returns>
        protected void CreatCheckBoxList()
        {
            DataSet dsTree = new DataSet();
            BLL.T_Index bllIndex = new BLL.T_Index();
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 and MultiIndex = '1'");
            dsTree = bllIndex.GetList(strWhere.ToString());

            foreach (DataRow row in dsTree.Tables[0].Rows)
            {
                if (row["FatherID"].ToString().Contains("#"))
                {
                    FineUI.CheckItem checkItem = new FineUI.CheckItem();
                    checkItem.Text = row["Name"].ToString();
                    checkItem.Value = row["ID"].ToString();
                    IndexList.Items.Add(checkItem);
                }
            }
        }
        
        /// <summary>
        /// 复选框更改事件,不能运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxListChanged(object sender, System.EventArgs e)
        {
            List<string> listIndexID = new List<string>();
            foreach (FineUI.CheckItem li in ((FineUI.CheckBoxList)sender).Items)
            {
                if (li.Selected)
                {
                    listIndexID.Add(li.Value.ToString());
                }
            }
        }

        /// <summary>
        /// 时间绑定
        /// 起始年份、月份和结束年份、月份下拉框数据绑定
        /// 默认年份为当前年份、初始月份为一月、结束月份为当前月份
        /// </summary>
        protected void BindTime()
        {
            nbxStartYear.Text = DateTime.Now.Year.ToString();
            nbxEndYear.Text = DateTime.Now.Year.ToString();
            endMonth.SelectedValue = "1";
            endMonth.SelectedValue = DateTime.Now.Month.ToString();
        }

        /// <summary>
        /// 指标类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void reportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择的是月报表
            if (ddlReportType.SelectedValue == "1")
            {
                nbxStartYear.Hidden = false;
                startMonth.Hidden = false;
                startQuarter.Hidden = true;
                startHalfYear.Hidden = true;

                nbxEndYear.Hidden = false;
                endMonth.Hidden = false;
                endQuarter.Hidden = true;
                endHalfYear.Hidden = true;
            }

            //选择的是季度报表
            if (ddlReportType.SelectedValue == "2")
            {
                nbxStartYear.Hidden = false;
                startMonth.Hidden = true;
                startQuarter.Hidden = false;
                startHalfYear.Hidden = true;

                nbxEndYear.Hidden = false;
                endMonth.Hidden = true;
                endQuarter.Hidden = false;
                endHalfYear.Hidden = true;
            }

            //选择的是半年度报表
            if (ddlReportType.SelectedValue == "3")
            {
                nbxStartYear.Hidden = false;
                startMonth.Hidden = true;
                startQuarter.Hidden = true;
                startHalfYear.Hidden = false;

                nbxEndYear.Hidden = false;
                endMonth.Hidden = true;
                endQuarter.Hidden = true;
                endHalfYear.Hidden = false;
            }

            //选择的是年报表
            if (ddlReportType.SelectedValue == "4")
            {
                nbxStartYear.Hidden = false;
                startMonth.Hidden = true;
                startQuarter.Hidden = true;
                startHalfYear.Hidden = true;

                nbxEndYear.Hidden = false;
                endMonth.Hidden = true;
                endQuarter.Hidden = true;
                endHalfYear.Hidden = true;
            }


            //无选择
            if (ddlReportType.SelectedValue == "-1")
            {
                nbxStartYear.Hidden = true;
                startMonth.Hidden = true;
                startQuarter.Hidden = true;
                startHalfYear.Hidden = true;

                nbxEndYear.Hidden = true;
                endMonth.Hidden = true;
                endQuarter.Hidden = true;
                endHalfYear.Hidden = true;
            }

        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void queryBtn_Click(object sender, EventArgs e)
        {
            if (!checkForm()) return;

            DataSet IndexCategory = new DataSet();
            BLL.T_Index bllIndex = new BLL.T_Index();
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" 1=1");
            IndexCategory = bllIndex.GetTreeList(sqlStr.ToString());

            List<string> indexList = new List<string>();

            //获取前台得值
            foreach (string IndexID in IndexList.SelectedValueArray)
            {
                indexList.Add(IndexID);
            }

            //获取数据
            DataSet ds = GetDataSet(indexList);
            //将数据转为json字符串
            IndexJson jsonModel = new IndexJson();
            ArrayList indexNameArr = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                indexNameArr.Add(dr["IndexName"].ToString());
            }
            jsonModel.IndexNameArr = indexNameArr;

            Dictionary<string, ArrayList> data = new Dictionary<string, ArrayList>();

            foreach (DataTable dt in ds.Tables)
            {
                ArrayList multiIndexValueArr = new ArrayList();
                foreach (DataRow dr in dt.Rows)
                {
                    multiIndexValueArr.Add(dr["IndexValue"].ToString());
                }
                data.Add(dt.Rows[0]["Time"].ToString(), multiIndexValueArr);
            }

            jsonModel.Data = data;
            jsonStr = JsonConvert.SerializeObject(jsonModel);

            #region echart数据格式

            /*
            DataTable dt1 = new DataTable();
            DataColumn dtc1 = new DataColumn("Time", typeof(string));
            dt1.Columns.Add(dtc1);
            dtc1 = new DataColumn("IndexName", typeof(string));
            dt1.Columns.Add(dtc1);
            dtc1 = new DataColumn("IndexValue", typeof(string));
            dt1.Columns.Add(dtc1);
            DataRow row1 = dt1.NewRow();
            row1["Time"] = "2013年";
            row1["IndexName"] = "引导基金（万元）";
            row1["IndexValue"] = 2000;
            DataRow row2 = dt1.NewRow();
            row2["Time"] = "2013年";
            row2["IndexName"] = "贷款贴息（万元）";
            row2["IndexValue"] = 1200;
            DataRow row3 = dt1.NewRow();
            row3["Time"] = "2013年";
            row3["IndexName"] = "科技保险（万元）";
            row3["IndexValue"] = 500;
            dt1.Rows.InsertAt(row1, 0);
            dt1.Rows.InsertAt(row2, 1);
            dt1.Rows.InsertAt(row3, 2);

            DataTable dt2 = new DataTable();
            DataColumn dtc2 = new DataColumn("Time", typeof(string));
            dt2.Columns.Add(dtc2);
            dtc2 = new DataColumn("IndexName", typeof(string));
            dt2.Columns.Add(dtc2);
            dtc2 = new DataColumn("IndexValue", typeof(string));
            dt2.Columns.Add(dtc2);
            DataRow row4 = dt2.NewRow();
            row4["Time"] = "2014年";
            row4["IndexName"] = "引导基金（万元）";
            row4["IndexValue"] = 5000;
            DataRow row5 = dt2.NewRow();
            row5["Time"] = "2014年";
            row5["IndexName"] = "贷款贴息（万元）";
            row5["IndexValue"] = 2066;
            DataRow row6 = dt2.NewRow();
            row6["Time"] = "2014年";
            row6["IndexName"] = "科技保险（万元）";
            row6["IndexValue"] = 487;
            dt2.Rows.InsertAt(row4, 0);
            dt2.Rows.InsertAt(row5, 1);
            dt2.Rows.InsertAt(row6, 2);

            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
             * */

            #endregion
        }

        /// <summary>
        /// 获取数据，并转置
        /// </summary>
        /// <param name="indexList"></param>
        /// <returns></returns>
        protected DataSet GetDataSet(List<string> indexList)
        {
            //用于获取初始数据
            DataSet ds = new DataSet();

            //用户创建时间字符串数组
            List<string> stringList = new List<string>();

            //用于将初始数据转换为前台需要的数据格式，未知数据赋值为0
            DataSet jsonDataSet = new DataSet();

            #region 获取原始报表数据

            string Cycle = ddlReportType.SelectedValue.ToString();
            string Star_Period = "";
            string End_Period = "";
            if (Cycle == "1")
            {
                Star_Period = startMonth.SelectedValue.ToString();
                End_Period = endMonth.SelectedValue.ToString();
            }
            else if (Cycle == "2")
            {
                Star_Period = startQuarter.SelectedValue.ToString();
                End_Period = endQuarter.SelectedValue.ToString();
            }
            else if (Cycle == "3")
            {
                Star_Period = startHalfYear.SelectedValue.ToString();
                End_Period = endHalfYear.SelectedValue.ToString();
            }
            else if (Cycle == "4")
            {
                Star_Period = "";
                End_Period = "";
            }

            BLL.T_Report bllReport = new BLL.T_Report();
            foreach (string IndexID in indexList)
            {
                DataTable dtSource = bllReport.SearchReport(Cycle, nbxStartYear.Text.ToString(), Star_Period, nbxEndYear.Text.ToString(), End_Period, IndexID).Tables[0].Copy();
                dtSource.TableName = IndexID;
                ds.Tables.Add(dtSource);
            }

            #endregion

            #region 创建时间字符串数组

            if (Cycle == "1")//月报表
            {
                int start = Convert.ToInt32(startMonth.SelectedValue);
                int end = Convert.ToInt32(endMonth.SelectedValue);
                if (nbxStartYear.Text.ToString() == nbxEndYear.Text.ToString())
                {
                    for (int i = start; i <= end; i++)
                    {
                        stringList.Add(nbxStartYear.Text.ToString() + "年" + i + "月");
                    }
                }
                else if (nbxStartYear.Text.ToString() != nbxEndYear.Text.ToString())
                {
                    int yearPeriod = Convert.ToInt32(nbxEndYear.Text) - Convert.ToInt32(nbxStartYear.Text);
                    int starYear = Convert.ToInt32(nbxStartYear.Text);
                    for (int i = 0; i <= yearPeriod; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = start; j <= 12; j++)
                            {
                                stringList.Add(starYear + "年" + j + "月");
                            }
                        }
                        else if (i != 0 && i != yearPeriod)
                        {
                            for (int j = 1; j <= 12; j++)
                            {
                                stringList.Add((starYear + i) + "年" + j + "月");
                            }
                        }
                        else if (i == yearPeriod)
                        {
                            for (int j = 1; j <= end; j++)
                            {
                                stringList.Add((starYear + i) + "年" + j + "月");
                            }
                        }
                    }
                }
            }
            else if (Cycle == "2")//季报表
            {
                int start = Convert.ToInt32(startQuarter.SelectedValue);
                int end = Convert.ToInt32(endQuarter.SelectedValue);
                if (nbxStartYear.Text.ToString() == nbxEndYear.Text.ToString())
                {
                    for (int i = start; i <= end; i++)
                    {
                        stringList.Add(nbxStartYear.Text.ToString() + "年" + i + "季");
                    }
                }
                else if (nbxStartYear.Text.ToString() != nbxEndYear.Text.ToString())
                {
                    int yearPeriod = Convert.ToInt32(nbxEndYear.Text) - Convert.ToInt32(nbxStartYear.Text);
                    int starYear = Convert.ToInt32(nbxStartYear.Text);
                    for (int i = 0; i <= yearPeriod; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = start; j <= 4; j++)
                            {
                                stringList.Add(starYear + "年" + j + "季");
                            }
                        }
                        else if (i != 0 && i != yearPeriod)
                        {
                            for (int j = 1; j <= 4; j++)
                            {
                                stringList.Add((starYear + i) + "年" + j + "季");
                            }
                        }
                        else if (i == yearPeriod)
                        {
                            for (int j = 1; j <= end; j++)
                            {
                                stringList.Add((starYear + i) + "年" + j + "季");
                            }
                        }
                    }
                }
            }
            else if (Cycle == "3")//半年报表
            {
                int start = Convert.ToInt32(startHalfYear.SelectedValue);
                int end = Convert.ToInt32(endHalfYear.SelectedValue);
                if (nbxStartYear.Text.ToString() == nbxEndYear.Text.ToString())
                {
                    stringList.Add(nbxStartYear.Text.ToString() + "年上半年");
                    stringList.Add(nbxStartYear.Text.ToString() + "年下半年");
                }
                else if (nbxStartYear.Text.ToString() != nbxEndYear.Text.ToString())
                {
                    int yearPeriod = Convert.ToInt32(nbxEndYear.Text) - Convert.ToInt32(nbxStartYear.Text);
                    int starYear = Convert.ToInt32(nbxStartYear.Text);
                    for (int i = 0; i <= yearPeriod; i++)
                    {
                        if (i == 0)
                        {
                            if (start == 1)
                            {
                                stringList.Add(nbxStartYear.Text.ToString() + "年上半年");
                                stringList.Add(nbxStartYear.Text.ToString() + "年下半年");
                            }
                            else
                            {
                                stringList.Add(nbxStartYear.Text.ToString() + "年下半年");
                            }
                        }
                        else if (i != 0 && i != yearPeriod)
                        {
                            stringList.Add((starYear + i) + "年上半年");
                            stringList.Add((starYear + i) + "年下半年");
                        }
                        else if (i == yearPeriod)
                        {
                            if (end == 1)
                            {
                                stringList.Add((starYear + i) + "年上半年");
                            }
                            else
                            {
                                stringList.Add((starYear + i) + "年上半年");
                                stringList.Add((starYear + i) + "年下半年");
                            }
                        }
                    }
                }
            }
            else if (Cycle == "4")//年报表
            {
                int start = Convert.ToInt32(nbxStartYear.Text);
                int end = Convert.ToInt32(nbxEndYear.Text);
                int startYear = Convert.ToInt32(nbxStartYear.Text);
                for (int i = start; i <= end; i++)
                {
                    stringList.Add(i + "年");
                }
            }

            #endregion

            #region 数组转置

            foreach (string timeString in stringList)
            {
                DataTable periodDt = new DataTable();
                periodDt.TableName = timeString;
                DataColumn dtcTime = new DataColumn("Time", typeof(string));
                periodDt.Columns.Add(dtcTime);
                DataColumn dtcIndexName = new DataColumn("IndexName", typeof(string));
                periodDt.Columns.Add(dtcIndexName);
                DataColumn dtcIndexValue = new DataColumn("IndexValue", typeof(string));
                periodDt.Columns.Add(dtcIndexValue);
                foreach (DataTable dt in ds.Tables)
                {
                    bool flag = false;

                    if (dt.Rows.Count > 0)
                    {
                        decimal sumIndexValue = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Period"].ToString() == timeString)
                            {
                                if (row["IndexValue"].ToString() == "")
                                {
                                    sumIndexValue += 0;
                                }
                                else
                                {
                                    sumIndexValue += decimal.Parse(row["IndexValue"].ToString());
                                }
                            }
                        }
                        //获取指标名
                        BLL.T_Index bllIndex = new BLL.T_Index();
                        Model.T_Index modelIndex = bllIndex.GetModel(dt.TableName.ToString());
                        //创建DataRow
                        DataRow periodDtRow = periodDt.NewRow();
                        periodDtRow["Time"] = timeString;
                        periodDtRow["IndexName"] = modelIndex.Name.ToString();
                        periodDtRow["IndexValue"] = decimal.Round(sumIndexValue, 2).ToString();
                        //添加行
                        periodDt.Rows.Add(periodDtRow);

                        flag = true;
                    }

                    if (!flag)
                    {
                        DataRow periodDtRow = periodDt.NewRow();
                        periodDtRow["Time"] = timeString;

                        BLL.T_Index bllIndex = new BLL.T_Index();
                        Model.T_Index modelIndex = bllIndex.GetModel(dt.TableName.ToString());
                        periodDtRow["IndexName"] = modelIndex.Name;

                        //若不存在记录，则记为0
                        periodDtRow["IndexValue"] = "0";

                        periodDt.Rows.Add(periodDtRow);
                    }

                }
                jsonDataSet.Tables.Add(periodDt);
            }

            //保留两位小数
            foreach (DataTable dt in jsonDataSet.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToDecimal(row["IndexValue"]) > 0)
                    {
                        row["IndexValue"] = decimal.Round(decimal.Parse(row["IndexValue"].ToString()), 2).ToString();
                    }
                }
            }

            #endregion

            return jsonDataSet;
        }

        /// <summary>
        /// 表单校验
        /// </summary>
        /// <returns></returns>
        protected bool checkForm()
        {
            if (ddlReportType.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择报表类型");
                return false;
            }

            if (int.Parse(nbxStartYear.Text.ToString()) > int.Parse(nbxEndYear.Text.ToString()))
            {
                Alert.ShowInTop("起始时间不能大于结束时间");
                return false;
            }


            if (int.Parse(nbxStartYear.Text.ToString()) == int.Parse(nbxEndYear.Text.ToString()))
            {
                if (ddlReportType.SelectedValue == "1" &&
                    int.Parse(startMonth.SelectedValue) > int.Parse(endMonth.SelectedValue))
                {
                    Alert.ShowInTop("起始时间不能大于结束时间");
                    return false;
                }
                if (ddlReportType.SelectedValue == "2" &&
                     int.Parse(startQuarter.SelectedValue) > int.Parse(endQuarter.SelectedValue))
                {
                    Alert.ShowInTop("起始时间不能大于结束时间");
                    return false;
                }
                if (ddlReportType.SelectedValue == "3" &&
                    int.Parse(startHalfYear.SelectedValue) > int.Parse(endHalfYear.SelectedValue))
                {
                    Alert.ShowInTop("起始时间不能大于结束时间");
                    return false;
                }
            }

            return true;
        }

    }
}