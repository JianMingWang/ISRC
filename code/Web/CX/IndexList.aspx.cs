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
    public partial class IndexList : PageBase
    {
        /// <summary>
        /// 供前台使用
        /// </summary>
        protected string jsonStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLIndex();
                BindDDLYear();
            }
        }

        /// <summary>
        /// 指标下拉框数据绑定
        /// </summary>
        protected void BindDDLIndex()
        {
            BLL.T_Index bllIndex = new BLL.T_Index();
            DataSet ds = bllIndex.GetList(" 1=1");
            DataTable dtSource = ds.Tables[0];

            //添加首行
            DataRow dr = dtSource.NewRow();
            dr["Name"] = "请选择一项指标";
            dr["ID"] = -1;
            dtSource.Rows.InsertAt(dr, 0);

            ddlIndex.DataSource = dtSource;
            ddlIndex.DataTextField = "Name";
            ddlIndex.DataValueField = "ID";
            ddlIndex.DataBind();
            ddlIndex.SelectedIndex = -1;
        }

        /// <summary>
        /// 起始年份、结束年份下拉框数据绑定
        /// 2012年至当前时间的年份
        /// </summary>
        protected void BindDDLYear()
        {
            nbxStartYear.Text = DateTime.Now.Year.ToString();
            nbxEndYear.Text = DateTime.Now.Year.ToString();
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
            indexList.Add(ddlIndex.SelectedValue.ToString());

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
            //生成json字符串
            jsonStr = JsonConvert.SerializeObject(jsonModel);
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
            if (ddlIndex.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择一项指标");
                return false;
            }
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