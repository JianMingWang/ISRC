using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Xml;

namespace ISRC.Web.SYS.Role
{
    public partial class RoleMenu : System.Web.UI.Page
    {
        List<string> menuIdList = new List<string>();
        DataSet dsAllMenu = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            string roleId = Session["RoleID"].ToString();
            bool authority = true;
            if (new BLL.vw_Sys_RoleMenuUrl().GetRecordCount(" RoleID='" + roleId + "' and MenuUrl='~/SYS/Role/List.aspx'")==0)
            {
                authority = false;
            }
            if (!authority)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                initTree();
            }
        }

        /// <summary>
        /// 初始化菜单树，并保持角色已有的权限菜单为选中状态
        /// </summary>
        protected void initTree()
        {
            menuIdList.Clear();
            BLL.T_Sys_RoleMenu bllRoleMenu = new BLL.T_Sys_RoleMenu();
            DataSet result = bllRoleMenu.GetList(" RoleID='" + Request.QueryString["id"] + "' ");
            foreach (DataRow dr in result.Tables[0].Rows)
            {
                menuIdList.Add(dr["MenuID"].ToString());
            }

            dsAllMenu = new BLL.T_Sys_Menu().GetAllList();
            foreach (DataRow row in dsAllMenu.Tables[0].Select("ParentID='0'","SortNo"))
            {
                TreeNode node = new TreeNode();
                node.NodeID = row["ID"].ToString();
                node.Text = row["MenuName"].ToString();
                node.Expanded = true;
                node.EnableCheckBox = true;
                node.EnableCheckEvent = true;
                //保持节点选中
                foreach (string str in menuIdList)
                {
                    if (node.NodeID == str) node.Checked = true;
                }
                treeMenu.Nodes.Add(node);

                ResolveSubTree(node);
            }
        }

        /// <summary>
        /// 生成子树，这里为二级导航菜单
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="treeNode"></param>
        private void ResolveSubTree(TreeNode treeNode)
        {
            string parentId = treeNode.NodeID;
            //DataSet ds = new BLL.T_Sys_Menu().GetList("ParentID='" + parentId + "'");
            //DataRowCollection rows = ds.Tables[0].Rows;
            DataRow[] rows = dsAllMenu.Tables[0].Select("ParentID='" + parentId + "'");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.NodeID = row["ID"].ToString();
                    node.Text = row["MenuName"].ToString();
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    //保持节点选中
                    foreach (string str in menuIdList)
                    {
                        if (node.NodeID == str) node.Checked = true;
                    }
                    treeNode.Nodes.Add(node);

                    //ResolveSubTree(row, node);//此处只有二级菜单无需递归
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TreeNode[] nodes = treeMenu.GetCheckedNodes();

            BLL.T_Sys_Menu bllMenu = new BLL.T_Sys_Menu();
            HashSet<string> hs = new HashSet<string>();//存放选中的ID

            if (nodes.Length > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    string id = node.NodeID;
                    hs.Add(id);

                    string parentId = bllMenu.GetParentIdById(id);
                    if (parentId != "0")
                    {
                        hs.Add(parentId);
                    }
                }
            }

            string roleId = Request.QueryString["id"];
            BLL.T_Sys_RoleMenu bllRoleMenu = new BLL.T_Sys_RoleMenu();
            BLL.T_Sys_RoleXML bllRoleXML = new BLL.T_Sys_RoleXML();
            try
            {
                bllRoleMenu.DeleteListByRoleID(roleId);//先批量删除，再新增
                //循环添加
                foreach (string menuId in hs)
                {
                    Model.T_Sys_RoleMenu modelRoleMenu = new Model.T_Sys_RoleMenu();
                    modelRoleMenu.ID = System.Guid.NewGuid().ToString();
                    modelRoleMenu.RoleID = roleId;
                    modelRoleMenu.MenuID = menuId;
                    bllRoleMenu.Add(modelRoleMenu);
                }

                bllRoleXML.DeleteByRoleID(roleId);//先删除T_Sys_RoleXML中的相关记录，再新增
                Model.T_Sys_RoleXML modelRoleXML = new Model.T_Sys_RoleXML();
                modelRoleXML.ID = System.Guid.NewGuid().ToString();
                modelRoleXML.RoleID = roleId;
                modelRoleXML.RoleXml = GetXmlString(hs);
                bllRoleXML.Add(modelRoleXML);

                Alert.ShowInTop("保存成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            catch (Exception)
            {
                Alert.ShowInTop("数据库错误，保存失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }

            //string str = "";
            //foreach (string s in hs)
            //{
            //    str += s + "\n";
            //}
            //Alert.Show(str);

        }

        /// <summary>
        /// 根据选中的节点，创建XML字符串
        /// 只有二级菜单，无须递归
        /// </summary>
        /// <returns></returns>
        protected string GetXmlString(HashSet<string> selectedIdSet)
        {
            string str = "";
            foreach (string menuId in selectedIdSet)
            {
                str += "'" + menuId + "',";
            }
            str = str.Remove(str.Length - 1);
            DataSet ds = new BLL.T_Sys_Menu().GetList(" ID in(" + str + ") order by ParentID,SortNo");

            string xmlStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Tree>";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["ParentID"].ToString().Equals("0"))
                {
                    xmlStr += "<TreeNode Text=\"" + row["MenuName"].ToString() + "\" SingleClickExpand=\"true\"> ";

                    DataRow[] subRows = ds.Tables[0].Select("ParentID='" + row["ID"].ToString() + "'");
                    if (subRows.Length > 0)
                    {
                        foreach (DataRow subRow in subRows)
                        {
                            xmlStr += "<TreeNode Text=\"" + subRow["MenuName"].ToString() + "\" NavigateUrl=\"" + subRow["MenuUrl"].ToString() + "\" />";
                        }
                    }
                    xmlStr += "</TreeNode>";
                }
            }
            xmlStr += "</Tree>";
            return xmlStr;
        }

        /// <summary>
        /// 全选与反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void treeMenu_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treeMenu.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                treeMenu.UncheckAllNodes(e.Node.Nodes);
            }
        }
    }
}