using System;
using System.Data;
using System.Web;
using System.Xml;

namespace ISRC.Web
{
    public partial class Default : PageBase
    {
        private string _menuType = "accordion";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitMenuStyleButton();
                InitThemeMenuButton();
                ((System.Web.UI.WebControls.Label)regionBottom.FindControl("lblBlock")).Text = Session["RoleName"].ToString();
            }
        }

        protected void Page_Init(object sender,EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            //设置Cookie中保存的菜单样式，若不存在则设为默认样式
            HttpCookie menuCookie = Request.Cookies["MenuStyle"];
            if(menuCookie != null)
            {
                _menuType = menuCookie.Value;
            }

            if(_menuType == "accordion")
            {
                InitAccordionMenu();
            }
            else
            {
                InitTreeMenu();
            }
        }

        //获取XML文件
        private XmlDocument getXmlDocument()
        {
            //BLL.tb_SYS_Account bllAccount = new BLL.tb_SYS_Account();
            //DataTable dtAccount = bllAccount.GetList("ID='" + Session["AccountID"] + "'").Tables[0];
            //BLL.tb_SYS_RoleXML bllRoleXML = new BLL.tb_SYS_RoleXML();
            //DataTable dtRoleXML = bllRoleXML.GetList("RoleID='" + dtAccount.Rows[0]["RoleID"].ToString() + "'").Tables[0];
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.LoadXml(dtRoleXML.Rows[0]["XML"].ToString());
            //return xmlDocument;

            BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();
            DataTable dtAccount = bllAccount.GetList("ID='" + Session["AccountID"] + "'").Tables[0];
            BLL.T_Sys_RoleXML bllRoleXML = new BLL.T_Sys_RoleXML();
            DataTable dtRoleXML = bllRoleXML.GetList("RoleID='" + dtAccount.Rows[0]["RoleID"].ToString() + "'").Tables[0];
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(dtRoleXML.Rows[0]["RoleXml"].ToString());
            return xmlDocument;
        }

        /// <summary>
        /// 手风琴样式菜单
        /// </summary>
        /// <returns></returns>
        private FineUI.Accordion InitAccordionMenu()
        {
            FineUI.Accordion accordionMenu = new FineUI.Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            regionLeft.Items.Add(accordionMenu);

            XmlDocument xmlDoc = getXmlDocument();
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    FineUI.AccordionPane accordionPane = new FineUI.AccordionPane();
                    accordionPane.Title = xmlNode.Attributes["Text"].Value;
                    accordionPane.Layout = FineUI.Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    FineUI.Tree innerTree = new FineUI.Tree();
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = true;
                    innerTree.AutoScroll = true;
                    innerTree.EnableSingleClickExpand = true;
                    accordionPane.Items.Add(innerTree);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));

                    // 绑定AccordionPane内部的树控件
                    innerTree.NodeDataBound += treeMenu_NodeDataBound;
                    innerTree.DataSource = doc;
                    innerTree.DataBind();
                }
            }
            return accordionMenu;
        }

        /// <summary>
        /// 树样式菜单
        /// </summary>
        /// <returns></returns>
        private FineUI.Tree InitTreeMenu()
        {
            FineUI.Tree treeMenu = new FineUI.Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.AutoScroll = true;
            treeMenu.EnableIcons = true;
            treeMenu.EnableSingleClickExpand = true;
            regionLeft.Items.Add(treeMenu);

            XmlDocument doc = getXmlDocument();

            // 绑定 XML 数据源到树控件
            treeMenu.NodeDataBound += treeMenu_NodeDataBound;
            treeMenu.DataSource = doc;
            treeMenu.DataBind();

            return treeMenu;
        }

        /// <summary>
        /// 树节点的绑定后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeMenu_NodeDataBound(object sender, FineUI.TreeNodeEventArgs e)
        {
            // 如果当前节点不是子节点，则展开当前节点
            if (!e.Node.Leaf)
            {
                e.Node.Expanded = true;
            }
        }

        private void InitMenuStyleButton()
        {
            string menuStyleID = "MenuStyleTree";

            HttpCookie menuStyleCookie = Request.Cookies["MenuStyle"];
            if (menuStyleCookie != null)
            {
                switch (menuStyleCookie.Value)
                {
                    case "menu":
                        menuStyleID = "MenuStyleTree";
                        break;
                    case "accordion":
                        menuStyleID = "MenuStyleAccordion";
                        break;
                }
            }
            SetSelectedMenuID(MenuStyle, menuStyleID);
        }

        private void InitThemeMenuButton()
        {
            string themeMenuID = "MenuThemeBlue";

            string themeValue = pageManager_01.Theme.ToString().ToLower();
            switch (themeValue)
            {
                case "blue":
                    themeMenuID = "MenuThemeBlue";
                    break;
                case "gray":
                    themeMenuID = "MenuThemeGray";
                    break;
                case "access":
                    themeMenuID = "MenuThemeAccess";
                    break;
                case "neptune":
                    themeMenuID = "MenuThemeNeptune";
                    break;
            }

            SetSelectedMenuID(MenuTheme, themeMenuID);
        }

        private void SetSelectedMenuID(FineUI.MenuButton menuButton, string selectedMenuID)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                FineUI.MenuCheckBox menu = (item as FineUI.MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["AccountName"] = null;
            Session["AccountID"] = null;
            Response.Redirect("Login.aspx");
        }

        //protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpCookie themeCookie = new HttpCookie("Theme_v4", ddlTheme.SelectedValue);
        //    themeCookie.Expires = DateTime.Now.AddDays(90);
        //    Response.Cookies.Add(themeCookie);
            
        //    FineUI.PageContext.Refresh();
        //}

        //protected void ddlMenuStyle_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpCookie menuCookie = new HttpCookie("MenuStyle", ddlMenuStyle.SelectedValue);
        //    menuCookie.Expires = DateTime.Now.AddDays(90);
        //    Response.Cookies.Add(menuCookie);

        //    FineUI.PageContext.Refresh();
        //}
    }
}