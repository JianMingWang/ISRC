<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.SYS.Account.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户账号维护</title>
</head>
<body>
    <form id="form_01" runat="server">
    <div>
        <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridAccount" runat="server" DataKeyNames="ID" Title="用户账号列表" ShowBorder="false" ShowHeader="true"  EnableCollapse="false" 
                    EnableCheckBoxSelect="true" EnableMultiSelect="false" AllowSorting="true" OnSort="gridAccount_Sort" 
                    AllowPaging="true"  IsDatabasePaging="false" PageSize="10" OnPageIndexChange="gridAccount_PageIndexChange" >
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
                            DataWindowTitleField="Account" DataWindowTitleFormatString="编辑 - {0}" SortField="SortNo" />
                        <f:BoundField Width="120px" ColumnID="Account" SortField="Account" DataField="Account" TextAlign="Center" HeaderText="账户"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="TrueName" SortField="TrueName" DataField="TrueName" TextAlign="Center" HeaderText="姓名"></f:BoundField>
                        <f:TemplateField ID="TemplateField1" Width="300px" TextAlign="Center" HeaderText="所属部门" runat="server" SortField="DeptID">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# GetDeptName(Eval("DeptID").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField ID="TemplateField2" Width="100px" TextAlign="Center" HeaderText="角色" runat="server" SortField="RoleID">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# GetRoleName(Eval("RoleID").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
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
