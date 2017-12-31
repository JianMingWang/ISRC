<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.JC.DeptIndex.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridDeptIndex" runat="server" Title="填报单位填报指标设置" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="6" 
                                        EnableMultiSelect="false" EnableRowSelectEvent="true">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnDelete" runat="server" Text="删除所选项" OnClick="btnDelete_Click" Icon="Delete"></f:Button>
                                <f:ToolbarSeparator ID="toolbarSeparator_01" runat="server"></f:ToolbarSeparator>
                                <f:ToolbarSeparator ID="toolbarSeparator1" runat="server"></f:ToolbarSeparator>
                                <f:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" Label="填报单位" Width="470px" LabelWidth="70px"></f:DropDownList>
                                <f:Button ID="btnAdd" Enabled="false" runat="server" Text="新增指标" Icon="Add" ></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:WindowField Width="60px" Hidden="true" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                                                ToolTip="编辑" />
                        <f:BoundField Width="120px" ColumnID="DeptName" SortField="Dept_Name" DataField="Dept_Name" TextAlign="Center" HeaderText="单位名称"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Index_Name" DataField="Index_Name" TextAlign="Center" HeaderText="子指标名称"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="FatherName" SortField="FatherName" DataField="FatherName" TextAlign="Center" HeaderText="大类指标"></f:BoundField>
                        <f:BoundField Width="250px" ColumnID="Index_Description" SortField="Index_Description" DataField="Index_Description" TextAlign="Center" HeaderText="描述"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Dept_ID" SortField="Dept_ID" DataField="Dept_ID" TextAlign="Center" HeaderText="单位编号" Hidden="true"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Index_Id" SortField="Index_Id" DataField="Index_Id" TextAlign="Center" HeaderText="制表编号" Hidden="true"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" runat="server" Title="编辑" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" OnClose="windowPop_Close" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="500px"></f:Window>
    </form>
</body>
</html>
