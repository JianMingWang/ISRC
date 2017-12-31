<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ISRC.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="Icon/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="CSS/default.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ISRC</title>
    <script src="Js/default.js" type="text/javascript"></script>
    <style> 
        /* 主题相关样式 - neptune */
        .f-theme-neptune #header,
        .f-theme-neptune .bottomtable,
        .f-theme-neptune .x-splitter {
            background-color: #1475BB;
            color: #fff;
        }

            .f-theme-neptune #header a,
            .f-theme-neptune .bottomtable a {
                color: #fff;
            }


        /* 主题相关样式 - blue */
        .f-theme-blue #header,
        .f-theme-blue .bottomtable {
            background-color: #DFE8F6;
            color: #000;
        }

            .f-theme-blue #header a,
            .f-theme-blue .bottomtable a {
                color: #000;
            }

        /* 主题相关样式 - gray */
        .f-theme-gray #header,
        .f-theme-gray .bottomtable {
            background-color: #E0E0E0;
            color: #333;
        }

            .f-theme-gray #header a,
            .f-theme-gray .bottomtable a {
                color: #333;
            }

        /* 主题相关样式 - access */
        .f-theme-access #header,
        .f-theme-access .bottomtable {
            background-color: #3F4757;
            color: #fff;
        }

            .f-theme-access #header a,
            .f-theme-access .bottomtable a {
                color: #fff;
            }

        .f-theme-access .maincontent .x-panel-body {
            background-image: none;
        }
    </style>
</head>
<body>
    <form id="form_01" runat="server">
        <div runat="server">
            <f:PageManager ID="pageManager_01" AutoSizePanelID="regionPanel_01" runat="server"></f:PageManager>
            <f:RegionPanel ID="regionPanel_01" ShowBorder="false" runat="server">
                <Regions>
                    <%--顶部区域--%>
                    <f:Region ID="regionTop" ShowBorder="false" ShowHeader="false" Position="Top" Layout="Fit" runat="server">
                        <Content>
                            <div id="header">
                                <div style="float:left;display:block;padding-left:10px;line-height:40px;font-size:20px">
                                    科技金融监测与分析信息系统
                                </div>
                                <div style="float:right;display:block;padding-right:10px;line-height:40px;">
                                    <f:Button ID="btnLogOut" Text="注销" Icon="Cancel" OnClick="btnLogOut_Click" runat="server" EnableAjax="false">
                                    </f:Button>
                                </div>
                            </div>
                        </Content>
                        
                    </f:Region>

                    <%--左侧菜单区域--%>
                    <f:Region ID="regionLeft" AutoScroll="false" RegionSplit="true" Width="220px" ShowHeader="true" ShowBorder="true" Title="功能目录"
                        Expanded="true" EnableCollapse="true" Layout="Fit" Collapsed="false" RegionPosition="Left" runat="server">
                    </f:Region>
                
                    <%--中间主页面区域--%>
                    <f:Region ID="regionCenter" ShowHeader="false" Layout="Fit" ShowBorder="false" Position="Center" runat="server">
                        <Items>
                            <f:TabStrip ID="tabStripMain" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                                <Tabs>
                                    <f:Tab Title="首页" Layout="Fit" Icon="House" CssClass="maincontent" runat="server">
                                        <Items>
                                            <f:Image runat="server" ImageUrl="~/Images/1.png" Margin="-5 0 0 0" />
                                        </Items>
                                    </f:Tab>
                                </Tabs>
                            </f:TabStrip>
                        </Items>
                    </f:Region>

                    <%--底部区域--%>
                    <f:Region ID="regionBottom" Height="25px" ShowBorder="false" ShowHeader="false" Position="Bottom" Layout="Fit" runat="server">
                        <Content>
                            <div id="divBottom" class="bottom" runat="server">
                                <div class="bottomLeft">
                                    <f:Label ID="lblSystemInfo" Text="" runat="server"></f:Label>
                                </div>
                                <div class="bottomMiddle" runat="server">
                                    <asp:Label ID="lblBlock" Text="" runat="server"></asp:Label>
                                </div>
                                <div class="bottomRight">
                                    <asp:Label ID="lblActor" Text="测试运行" runat="server"></asp:Label>
                                </div>
                            </div>
                        </Content>
                    </f:Region>
                </Regions>
            </f:RegionPanel>
        </div>
        <f:Menu ID="menuSettings" runat="server">
            <f:MenuButton ID="btnExpandAll" IconUrl="Images/expand-all.gif" Text="展开菜单" EnablePostBack="false" runat="server">
            </f:MenuButton>

            <f:MenuButton ID="btnCollapseAll" IconUrl="Images/collapse-all.gif" Text="折叠菜单" EnablePostBack="false" runat="server">
            </f:MenuButton>

            <f:MenuSeparator ID="MenuSeparator1" runat="server">
            </f:MenuSeparator>

            <f:MenuButton EnablePostBack="false" Text="菜单样式" ID="MenuStyle" runat="server">
                <Menu runat="server">
                    <f:MenuCheckBox Text="树菜单" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="手风琴+树菜单" ID="MenuStyleAccordion" GroupName="MenuStyle" runat="server">
                    </f:MenuCheckBox>
                </Menu>
            </f:MenuButton>

            <f:MenuButton ID="MenuTheme" EnablePostBack="false" Text="主题" runat="server">
                <Menu ID="Menu4" runat="server">
                    <f:MenuCheckBox Text="Neptune" ID="MenuThemeNeptune" Checked="true" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="Blue" ID="MenuThemeBlue" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="Gray" ID="MenuThemeGray" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                    <f:MenuCheckBox Text="Access" ID="MenuThemeAccess" GroupName="MenuTheme" runat="server">
                    </f:MenuCheckBox>
                </Menu>
            </f:MenuButton>
        </f:Menu>
        <%--<asp:XmlDataSource ID="xmlDataSourceMenu" runat="server" DataFile="Menu.xml"></asp:XmlDataSource>--%>
    </form>

    <script src="Js/jquery.min.js"></script>
    <script>

        var btnExpandAllClientID = '<%= btnExpandAll.ClientID %>';
        var btnCollapseAllClientID = '<%= btnCollapseAll.ClientID %>';
        var leftPanelClientID = '<%= regionLeft.ClientID %>';
        var tabStripMainClientID = '<%= tabStripMain.ClientID %>';
        var menuSettingsClientID = '<%= menuSettings.ClientID %>';

        var MenuStyleClientID = '<%= MenuStyle.ClientID %>';
        var MenuThemeClientID = '<%= MenuTheme.ClientID %>';


        F.ready(function () {
            var btnExpandAll = F(btnExpandAllClientID);
            var btnCollapseAll = F(btnCollapseAllClientID);
            var leftPanel = F(leftPanelClientID);
            var tabStripMain = F(tabStripMainClientID);
            var menuSettings = F(menuSettingsClientID);

            var MenuStyle = F(MenuStyleClientID);
            var MenuTheme = F(MenuThemeClientID);

            var mainMenu = leftPanel.items.getAt(0);
            var menuType = 'accordion';
            if (mainMenu.isXType('treepanel')) {
                menuType = 'menu';
            }

            // 当前展开的手风琴面板
            function getExpandedPanel() {
                var panel = null;
                mainMenu.items.each(function (item) {
                    if (!item.getCollapsed()) {
                        panel = item;
                    }
                });
                return panel;
            }

            // 点击展开菜单
            btnExpandAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.expandAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).expandAll();
                    }
                }
            });

            // 点击折叠菜单
            btnCollapseAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.collapseAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).collapseAll();
                    }
                }
            });

            // 点击菜单样式
            function MenuStyleItemCheckChange(cmp, checked) {
                if (checked) {
                    var menuStyle = 'accordion';
                    if (cmp.id.indexOf('MenuStyleTree') >= 0) {
                        menuStyle = 'tree';
                    }
                    F.cookie('MenuStyle', menuStyle, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuStyle.menu.items.each(function (item, index) {
                item.on('checkchange', MenuStyleItemCheckChange);
            });

            // 切换主题
            function MenuThemeItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'neptune';
                    if (cmp.id.indexOf('MenuThemeBlue') >= 0) {
                        lang = 'blue';
                    } else if (cmp.id.indexOf('MenuThemeGray') >= 0) {
                        lang = 'gray';
                    } else if (cmp.id.indexOf('MenuThemeAccess') >= 0) {
                        lang = 'access';
                    }

                    F.cookie('Theme_v4', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuTheme.menu.items.each(function (item, index) {
                item.on('checkchange', MenuThemeItemCheckChange);
            });


            function createToolbar(tabConfig) {
            }



            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // tabStripMain： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.util.initTreeTabStrip(mainMenu, tabStripMain, createToolbar, true, false, false);



            // 添加示例标签页
            window.addExampleTab = function (id, url, text, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // tabStripMain： 选项卡实例
                // id： 选项卡ID
                // url: 选项卡IFrame地址 
                // text： 选项卡标题
                // icon： 选项卡图标
                // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.util.addMainTab(tabStripMain, id, url, text, icon, null, refreshWhenExist);
            };

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = tabStripMain.getActiveTab();
                tabStripMain.removeTab(activeTab.id);
            };


            // 添加工具图标，并在点击时显示上下文菜单
            leftPanel.addTool({
                type: 'gear',
                //tooltip: '系统设置',
                handler: function (event) {
                    menuSettings.showBy(this);
                }
            });

        });
        </script>
</body>
</html>
