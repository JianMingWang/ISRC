using ISRC.Web.Code;
using System;
using System.Data;
using System.Text;

namespace ISRC.Web.JC.Index
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["selectedIndexID"] = "-1";
                Session["selectedIndexName"] = "";
                BindTree();
                LoadData();
            }
            btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx?IndexType=1", "增加指标");//新增子类
            btnAdd_IndexCategory.OnClientClick = windowPop.GetShowReference("Add.aspx?IndexType=0", "增加指标");//新增父类
            btnDelete.OnClientClick = gridIndex.GetNoSelectionAlertReference("至少选择一项！");
            btnDelete_IndexCategory.OnClientClick = gridIndexCategory.GetNoSelectionAlertReference("至少选择一项！");
        }

        private void LoadData()
        {
            string selectedIndexID = Session["selectedIndexID"].ToString();
            string selectedIndexName = Session["selectedIndexName"].ToString();
            if (selectedIndexID == "-1")
            {
                //子表增加、删除按钮显示
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

                //仅绑定父表数据
                BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();
                DataSet dsIndexCategory = bllIndexCategory.GetList(" ID !='-1' ");
                DataTable dtSource = dsIndexCategory.Tables[0];
                foreach (DataRow row in dtSource.Rows)//将父类ID去掉前面"#"  并展示出来
                {
                    string ID = row["ID"].ToString();
                    ID = ID.Substring(1, ID.Length - 1);
                    row["ID"] = ID;
                }
                gridIndexCategory.DataSource = dtSource;
                gridIndexCategory.DataBind();

                //子表为空
                DataTable dtIndexSource = new DataTable();
                gridIndex.DataSource = dtIndexSource;
                gridIndex.DataBind();
            }
            else
            {
                //bugbugbugbugbugbug
                BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();
                DataSet dsIndexCategory = bllIndexCategory.GetList(" ID='" + selectedIndexID + "'");
                //判断选定节点的类型
                if (dsIndexCategory.Tables[0].Rows.Count > 0)//父节点
                {
                    //子表增加、删除按钮显示
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;

                    //绑定父表数据
                    DataTable dtdsIndexCategorySource = dsIndexCategory.Tables[0];
                    foreach (DataRow row in dtdsIndexCategorySource.Rows)//将父类ID去掉前面"#"  并展示出来
                    {
                        string ID = row["ID"].ToString();
                        ID = ID.Substring(1, ID.Length - 1);
                        row["ID"] = ID;
                    }
                    gridIndexCategory.DataSource = dtdsIndexCategorySource;
                    gridIndexCategory.DataBind();

                    //绑定子表数据
                    BLL.T_Index bllIndex = new BLL.T_Index();
                    DataSet dsIndex = bllIndex.GetList(" FatherID='" + selectedIndexID + "'");
                    DataTable dtIndexSource = dsIndex.Tables[0];
                    foreach (DataRow row in dtIndexSource.Rows)
                    {
                        row["Cycle"] = PublicMethod.getKey("Cycle", row["Cycle"].ToString().Trim());
                        row["MultiIndex"] = PublicMethod.getKey("MultiIndex", row["MultiIndex"].ToString().Trim());
                        row["FatherID"] = Session["selectedIndexName"].ToString();
                    }
                    gridIndex.DataSource = dtIndexSource;
                    gridIndex.DataBind();
                }
                else//子节点
                {
                    //跳转到修改界面
                    windowPop.IFrameUrl = "Modify.aspx?IndexID=" + selectedIndexID + "&IndexType=1";//1代表具体指标
                    windowPop.Hidden = false;
                }
            }
        }

        private void BindTree()
        {
            treeBOM.Nodes.Clear();

            DataSet dsTree = CreatTreeTable();
            dsTree.Relations.Add("TreeRelation", dsTree.Tables[0].Columns["Id"], dsTree.Tables[0].Columns["FatherID"]);
            foreach (DataRow row in dsTree.Tables[0].Rows)
            {
                if (row.IsNull("FatherID"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["ID"].ToString();
                    node.Expanded = true;
                    node.EnableClickEvent = true;
                    treeBOM.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        //绑定树
        private void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Name"].ToString();
                    node.NodeID = row["ID"].ToString();
                    node.EnableClickEvent = true;//自动回发事件
                    treeNode.Nodes.Add(node);

                    ResolveSubTree(row, node);
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

        /// <summary>
        /// 删除子类指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.T_Index bllIndex = new BLL.T_Index();

            //注意此处：多页删除时，默认为第一页，需根据页码计算行数
            //string id = gridDeptIndex.DataKeys[gridDeptIndex.PageIndex * gridDeptIndex.PageSize + gridDeptIndex.SelectedRowIndex][0].ToString();

            string IndexID = gridIndex.DataKeys[gridIndex.SelectedRowIndex][0].ToString();
            bool result = bllIndex.Delete(IndexID);
            if (result)
            {
                //bug
                Session["selectedIndexID"] = "-1";
                Session["selectedIndexName"] = "";
                BindTree();
                LoadData();
            }
            else
            {
                Session["selectedIndexID"] = "-1";
                Session["selectedIndexName"] = "";
                BindTree();
                LoadData();
            }
        }

        /// <summary>
        /// 删除父类指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_IndexCategory_Click(object sender, EventArgs e)
        {
            BLL.T_IndexCategory bllIndexCategory = new BLL.T_IndexCategory();

            //注意此处：多页删除时，默认为第一页，需根据页码计算行数
            //string id = gridDeptIndex.DataKeys[gridDeptIndex.PageIndex * gridDeptIndex.PageSize + gridDeptIndex.SelectedRowIndex][0].ToString();

            string IndexCategory = "#" + gridIndexCategory.DataKeys[gridIndexCategory.SelectedRowIndex][0].ToString();
            bool result = bllIndexCategory.Delete(IndexCategory);
            Session["selectedIndexID"] = "-1";
            Session["selectedIndexName"] = "";
            BindTree();
            LoadData();
        }

        protected void windowPop_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            Session["selectedIndexID"] = "-1";
            BindTree();
            LoadData();
        }

        protected void treeBOM_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            Session["selectedIndexID"] = e.NodeID.ToString();
            Session["selectedIndexName"] = e.Node.Text.ToString();
            LoadData();
        }
    }
}