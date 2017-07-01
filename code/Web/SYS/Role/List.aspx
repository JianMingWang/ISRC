<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.SYS.Role.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统角色维护</title>
</head>
<body>
    <form id="form_01" runat="server">
    <div>
        <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridRole" runat="server" DataKeyNames="ID" Title="系统角色列表" ShowBorder="false" ShowHeader="true"  EnableCollapse="false" 
                    EnableCheckBoxSelect="true" EnableMultiSelect="false" AllowSorting="true" OnSort="gridRole_Sort" 
                    AllowPaging="true"  IsDatabasePaging="false" PageSize="10" OnPageIndexChange="gridRole_PageIndexChange" >
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" ConfirmText="确定要删除吗？" ConfirmTitle="警告" ConfirmTarget="Top" Text="删除" OnClick="btnDelete_Click" Icon="Delete" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowModify" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="RoleName" DataWindowTitleFormatString="编辑 - {0}" SortField="SortNo" />
                        <f:BoundField Width="120px" ColumnID="RoleName" SortField="RoleName" DataField="RoleName" TextAlign="Center" HeaderText="角色名称"></f:BoundField>
                        <f:WindowField Width="80px" WindowID="windowRoleMenu" TextAlign="Center" HeaderText="角色权限" Icon="Pencil"
                            ToolTip="角色权限" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="RoleMenu.aspx?id={0}"
                            DataWindowTitleField="RoleName" DataWindowTitleFormatString="角色权限 - {0}" SortField="SortNo" />
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
        <f:Window ID="windowRoleMenu" Title="角色权限"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </div>
    </form>
</body>
</html>
