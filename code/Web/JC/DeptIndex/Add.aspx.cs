using FineUI;
using System;
using System.Data;
using System.Text;


namespace ISRC.Web.JC.DeptIndex
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            //提取数据
            DataSet dsIndex = CreatTreeTable();
            DataSet ds_DeptIndex = GetDeptIndexList();
            DataTable Dept_Index = ds_DeptIndex.Tables[0];
            txtName.Text = Session["deptName"].ToString();

            dsIndex.Relations.Add("TreeRelation", dsIndex.Tables[0].Columns["Id"], dsIndex.Tables[0].Columns["FatherID"]);

            foreach (DataRow row in dsIndex.Tables[0].Rows)
            {
                if (row.IsNull("FatherID"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.Expanded = true;
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    treeIndex.Nodes.Add(node);

                    ResolveSubTree(row, node, Dept_Index);
                }
            }
        }

        //创建子节点
        private void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode, DataTable Dept_Index)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    //判断是否为已有指标
                    bool exist = false;
                    foreach (DataRow rowDeptIndex in Dept_Index.Rows)
                    {
                        if (node.Text.ToString() == rowDeptIndex["Index_Name"].ToString())
                        {
                            //node.Checked = true;
                            exist = true;
                        }
                    }
                    if (!exist)
                    {
                        treeNode.Nodes.Add(node);
                    }
                    ResolveSubTree(row, node, Dept_Index);
                }
            }
        }

        //获取指标信息，树结构
        private DataSet CreatTreeTable()
        {
            DataSet ds = new DataSet();
            BLL.T_Index bllIndex = new BLL.T_Index();
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" 1=1");
            ds = bllIndex.GetTreeList(sqlStr.ToString());
            return ds;
        }

        //获取部门指标信息
        private DataSet GetDeptIndexList()
        {
            string DeptID = Session["deptId"].ToString();
            DataSet ds = new DataSet();
            BLL.vw_Dept_Index vwDeptIndex = new BLL.vw_Dept_Index();
            StringBuilder sqlString = new StringBuilder();
            sqlString.Append(" Dept_ID = '" + DeptID + "'");
            ds = vwDeptIndex.GetList(sqlString.ToString());
            return ds;
        }

        //全选或反选
        protected void treeIndex_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treeIndex.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                treeIndex.UncheckAllNodes(e.Node.Nodes);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = GetCheckValue();
            string DeptID = Session["deptId"].ToString();
            if (dtCheck.Rows.Count > 0)
            {
                foreach (DataRow rowIndex in dtCheck.Rows)
                {
                    BLL.T_DeptIndex bllDeptIndex = new BLL.T_DeptIndex();

                    Model.T_DeptIndex modelDeptIndex = new Model.T_DeptIndex();
                    modelDeptIndex.DeptID = DeptID;
                    modelDeptIndex.IndexID = rowIndex["ID"].ToString();

                    bllDeptIndex.Add(modelDeptIndex);
                }
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("未选中任何指标项项！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
            LoadData();
        }

        private DataTable GetCheckValue()
        {
            string deptID = Session["deptId"].ToString();
            BLL.T_Index DeptIndex = new BLL.T_Index();
            DataSet ds = DeptIndex.GetList("1=1");

            DataTable dt = new DataTable();
            DataColumn column = new DataColumn();
            column = dt.Columns.Add("ID");
            FineUI.TreeNode[] nodes = treeIndex.GetCheckedNodes();
            if (nodes.Length > 0)
            {

                foreach (FineUI.TreeNode node in nodes)
                {
                    string IndexID = "";
                    bool exist = false;//验证是否为子指标
                    foreach (DataRow rowDeptName in ds.Tables[0].Rows)
                    {
                        if (rowDeptName["Name"].ToString() == node.Text.ToString())
                        {
                            exist = true;
                            IndexID = rowDeptName["ID"].ToString();
                        }
                    }
                    if (exist)
                    {
                        DataRow row = dt.NewRow();
                        row["ID"] = IndexID;
                        dt.Rows.Add(row);
                    }
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
    }
}