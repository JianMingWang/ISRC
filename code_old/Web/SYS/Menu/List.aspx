<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.SYS.Menu.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统菜单维护</title>
</head>
<body>
    <form id="form_01" runat="server">
    <div>
        <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridMenu" runat="server" DataKeyNames="ID" Title="系统菜单列表" ShowBorder="false" ShowHeader="true"  EnableCollapse="false" 
                    EnableCheckBoxSelect="true" EnableMultiSelect="false" AllowSorting="true" OnSort="gridMenu_Sort" 
                    AllowPaging="true"  IsDatabasePaging="false" PageSize="10" OnPageIndexChange="gridMenu_PageIndexChange" >
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" ConfirmText="确定要删除吗？" ConfirmTitle="警告" ConfirmTarget="Top" Text="删除" OnClick="btnDelete_Click" Enabled="false" Icon="Delete" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowModify" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="MenuName" DataWindowTitleFormatString="编辑 - {0}" SortField="SortNo" />
                        <f:BoundField Width="120px" ColumnID="MenuName" SortField="MenuName" DataField="MenuName" TextAlign="Center" HeaderText="菜单名称"></f:BoundField>
                        <f:TemplateField ID="TemplateField1" Width="100px" TextAlign="Center" HeaderText="上级菜单" runat="server" SortField="ParentID">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# GetFatherMenuName(Eval("ParentID").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="200px" ColumnID="MenuUrl" SortField="MenuUrl" DataField="MenuUrl" TextAlign="left" HeaderText="菜单路径"></f:BoundField>
                        <f:BoundField Width="100px" ColumnID="SortNo" SortField="SortNo" DataField="SortNo" TextAlign="Center" HeaderText="排序号"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="windowModify" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
        <f:Window ID="windowAdd" Title="新增"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </div>
    </form>
</body>
</html>
