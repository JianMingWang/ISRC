using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using FineUI;

namespace ISRC.Web.Code
{
    public class PublicMethod
    {
        /// <summary>
        /// 将DataTable中某一列转换为List
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public List<string> columnToList(DataTable dt,string columnName)
        {
            List<string> list = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr[columnName].ToString());
            }
            return list;
        }

        /// <summary>
        /// 将DataTable中多列转换为List
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <param name="columnName">列名数组</param>
        /// <returns></returns>
        public List<List<string>> columnToList(DataTable dt,string[] columnName)
        {
            List<List<string>> listColumn = new List<List<string>>();
            List<string> listRow = new List<string>();

            foreach(DataRow dr in dt.Rows)
            {
                for(int i=0; i<columnName.Length; i++)
                {
                    listRow.Add(dr[columnName[i]].ToString());
                }
                listColumn.Add(listRow);
                listRow.RemoveRange(0, columnName.Length);
            }

            return listColumn;
        }

        /// <summary>
        /// 对DataTable对象排序，以匹配DataSimulateTreeLevelField的数据要求
        /// </summary>
        /// <param name="dtSource">待排序的DataTable对象</param>
        /// <param name="sortColumn">DataSimulateTreeLevelField的值</param>
        /// <param name="keyColumn">主键名称</param>
        /// <param name="refColumn">外键名称</param>
        /// <returns></returns>
        public static DataTable sortToTree(DataTable dtSource,string sortColumn,string keyColumn,string refColumn)
        {
            DataTable dtDestination = dtSource.Clone();
            DataColumn[] primaryKey = new DataColumn[] { dtDestination.Columns[keyColumn] };
            dtDestination.PrimaryKey = primaryKey;

            int insertPos = -1;
            foreach (DataRow drSource in dtSource.Rows)
            {
                if (drSource[sortColumn].ToString() != "0")
                {
                    DataRow dr = dtDestination.NewRow();
                    dr.ItemArray = drSource.ItemArray;
                    insertPos = dtDestination.Rows.IndexOf(dtDestination.Rows.Find(drSource[refColumn])) + 1;
                    dtDestination.Rows.InsertAt(dr, insertPos);
                }
                else
                {
                    dtDestination.ImportRow(drSource);
                }
            }
            return dtDestination;
        }

        /// <summary>
        /// 获取子节点个数
        /// </summary>
        /// <param name="dtSource">数据源DataTable对象</param>
        /// <param name="keyColumn">主键名</param>
        /// <param name="refColumn">外建名</param>
        /// <param name="nodeKey">节点主键值</param>
        /// <returns></returns>
        public static int getChildNumber(DataTable dtSource,string keyColumn,string refColumn,string nodeKey)
        {
            int childNumber = 0;
            bool nodeIsExit = false;
            foreach(DataRow dr in dtSource.Rows)
            {
                if(dr[refColumn].ToString() == nodeKey)
                {
                    childNumber++;
                }
                if(dr[keyColumn].ToString() == nodeKey)
                {
                    nodeIsExit = true;
                }
            }
            if(childNumber == 0)
            {
                return (nodeIsExit ? childNumber : -1);
            }
            else
            {
                return childNumber;
            }           
        }

        /// <summary>
        /// 获取当前分页的DataTable对象
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public static DataTable getPageTable(DataTable dtSource,int pageIndex, int pageSize)
        {
            DataTable pageTable = dtSource.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > dtSource.Rows.Count)
            {
                rowend = dtSource.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                pageTable.ImportRow(dtSource.Rows[i]);
            }

            return pageTable;
        }

        /// <summary>
        /// 将XmlDocument对象转化为string字符串
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static string convertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);

            StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string returnValue = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();

            return returnValue;
        }

        /// <summary>
        /// 返回一棵空树
        /// </summary>
        /// <returns></returns>
        public static XmlDocument getEmptyTree()
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(xmlDeclaration);
            XmlElement element = xml.CreateElement("Tree");
            xml.AppendChild(element);
            element = xml.CreateElement("TreeNode");
            element.SetAttribute("Text", "No Data");
            element.SetAttribute("SingleClickExpand", "true");
            xml.SelectSingleNode("Tree").AppendChild(element);

            return xml;
        }


        /// <summary>
        /// 执行键值转换
        /// </summary>
        /// <param name="type">转换类型</param>
        /// <param name="value">数据库中存储的值</param>
        /// <returns></returns>
        public static string getKey(string type, string value)
        {
            string key = "Error";
            if (type == "IF")
            {
                key = (value == "Y" ? "是" : "否");
            }
            if (type == "USE")
            {
                key = (value == "Y" ? "启用" : "未启用");
            }
            if (type == "CHECK")
            {
                if (value == "C") key = "未审核";
                if (value == "Y") key = "审核通过";
                if (value == "N") key = "审核未通过";
            }
            if (type == "SOURCE_JH")
            {
                if (value == "S") key = "销售订单";
                if (value == "F") key = "预测单";
            }
            if (type == "FINISH")
            {
                if (value == "Y") key = "结束";
                if (value == "N") key = "未结束";
            }
            if (type == "REQUIREMENT_JH")
            {
                if (value == "I") key = "录入";
                if (value == "C") key = "审批";
                if (value == "B") key = "拆分";
                if (value == "R") key = "分解";
                if (value == "A") key = "下达";
                if (value == "P") key = "部分执行";
                if (value == "F") key = "完工";
                if (value == "S") key = "中止";
            }
            if (type == "BILL")
            {
                if (value == "O") key = "委外单";
                if (value == "A") key = "生产单";
                if (value == "P") key = "采购单";
            }
            if (type == "TASK_JH")
            {
                if (value == "Y") key = "已执行";
                if (value == "N") key = "未执行";
            }
            if (type == "MRP_JH")
            {
                if (value == "Y") key = "已下达";
                if (value == "N") key = "未下达";
            }
            if (type == "MPS_JH")
            {
                if (value == "Y") key = "已分解";
                if (value == "N") key = "未分解";
            }
            if (type == "Quality")
            {
                if (value == "0") key = "省市单位";
                if (value == "1") key = "区单位";
            }
            if (type == "TB_Status")
            {
                if (value == "0") key = "未提交";
                if (value == "1") key = "已提交";
                if (value == "2") key = "退审";
            }
            if (type == "Cycle")
            {
                if (value == "") key = "未定义";
                if (value == "0") key = "不受限";
                if (value == "1") key = "月报表";
                if (value == "2") key = "季报表";
                if (value == "3") key = "半年报表";
                if (value == "4") key = "年报表";
            }
            if (type == "CycleType")
            {
                if (value == "1") key = "Month";
                if (value == "2") key = "Quarter";
                if (value == "3") key = "SemiYear";
                if (value == "4") key = "Year";
            }
            if (type == "Month")
            {
                if (value == "1") key = "一月份";
                if (value == "2") key = "二月份";
                if (value == "3") key = "三月份";
                if (value == "4") key = "四月份";
                if (value == "5") key = "五月份";
                if (value == "6") key = "六月份";
                if (value == "7") key = "七月份";
                if (value == "8") key = "八月份";
                if (value == "9") key = "九月份";
                if (value == "10") key = "十月份";
                if (value == "11") key = "十一月份";
                if (value == "12") key = "十二月份";
                if (value == "") key = "";
            }
            if (type == "Quarter")
            {
                if (value == "1") key = "第一季度";
                if (value == "2") key = "第二季度";
                if (value == "3") key = "第三季度";
                if (value == "4") key = "第四季度";
                if (value == "") key = "";
            }
            if (type == "SemiYear")
            {
                if (value == "1") key = "上半年度";
                if (value == "2") key = "下半年度";
                if (value == "") key = "";
            }
            if (type == "MultiIndex")
            {
                if (value == "0") key = "不参与";
                if (value == "1") key = "参与";
                if (value == "") key = "未设定";
            }
            return key;
        }

        /// <summary>
        /// 执行值键转换
        /// </summary>
        /// <param name="type">转换类型</param>
        /// <param name="key">页面中显示的值</param>
        /// <returns></returns>
        public static string getValue(string type, string key)
        {
            string value = "";
            if (type == "TB_Status")
            {
                if (key == "未提交") value = "0";
                if (key == "已提交") value = "1";
                if (key == "退审") value = "2";
            }
            if (type == "Month")
            {
                if (key == "一月份") value = "1";
                if (key == "二月份") value = "2";
                if (key == "三月份") value = "3";
                if (key == "四月份") value = "4";
                if (key == "五月份") value = "5";
                if (key == "六月份") value = "6";
                if (key == "七月份") value = "7";
                if (key == "八月份") value = "8";
                if (key == "九月份") value = "9";
                if (key == "十月份") value = "10";
                if (key == "十一月份") value = "11";
                if (key == "十二月份") value = "12";
            }
            if (type == "Quarter")
            {
                if (key == "第一季度") value = "1";
                if (key == "第二季度") value = "2";
                if (key == "第三季度") value = "3";
                if (key == "第四季度") value = "4";
            }
            if (type == "SemiYear")
            {
                if (key == "上半年度") value = "1";
                if (key == "下半年度") value = "2";
            }
            return value;
        }

        public static void cycleList(DropDownList ddl,string cycle)
        {
            ddl.Items.Clear();
            ddl.Hidden = false;
            if (cycle == "1")
            {
                ddl.Items.Add(new ListItem("一月份", "1"));
                ddl.Items.Add(new ListItem("二月份", "2"));
                ddl.Items.Add(new ListItem("三月份", "3"));
                ddl.Items.Add(new ListItem("四月份", "4"));
                ddl.Items.Add(new ListItem("五月份", "5"));
                ddl.Items.Add(new ListItem("六月份", "6"));
                ddl.Items.Add(new ListItem("七月份", "7"));
                ddl.Items.Add(new ListItem("八月份", "8"));
                ddl.Items.Add(new ListItem("九月份", "9"));
                ddl.Items.Add(new ListItem("十月份", "10"));
                ddl.Items.Add(new ListItem("十一月份", "11"));
                ddl.Items.Add(new ListItem("十二月份", "12"));
                ddl.Label = "月份";
            }
            else if (cycle == "2")
            {
                ddl.Items.Add(new ListItem("第一季度", "1"));
                ddl.Items.Add(new ListItem("第二季度", "2"));
                ddl.Items.Add(new ListItem("第三季度", "3"));
                ddl.Items.Add(new ListItem("第四季度", "4"));
                ddl.Label = "季度";
            }
            else if (cycle == "3")
            {
                ddl.Items.Add(new ListItem("上半年度", "1"));
                ddl.Items.Add(new ListItem("下半年度", "2"));
                ddl.Label = "半年度";
            }
        }

        public static string GetQuarter(int time)
        {
            if (time >= 1 && time <= 3)
            {
                return "1";
            }
            else if (time >= 4 && time <= 6)
            {
                return "2";
            }
            else if (time >= 7 && time <= 9)
            {
                return "3";
            }
            else
            {
                return "4";
            }
        }
        public static string GetSemiYear(int time)
        {
            if (time >= 1 && time <= 6)
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
        public static string[] GetTime(string cycle, int time)
        {
            string[] times = { "", "", "" };
            if (cycle == "1")
            {
                times[0] = time.ToString();
                times[1] = GetQuarter(time);
                times[2] = GetSemiYear(time);
            }
            else if (cycle == "2")
            {
                times[0] = "";
                times[1] = time.ToString();
                times[2] = GetSemiYear(time);
            }
            else if (cycle == "3")
            {
                times[0] = "";
                times[1] = "";
                times[2] = time.ToString();
            }
            return times;
        }

        public static void SetDdlSelected(int index, int month, DropDownList ddlCycleList)
        {
            if (index == 0 || index == 4)
            {
                ddlCycleList.Hidden = true;
            }
            else if (index == 1)
            {
                ddlCycleList.SelectedIndex = month - 1;
            }
            else if (index == 2)
            {
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
    }
}
