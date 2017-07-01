<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dept.aspx.cs" Inherits="ISRC.Web.Trigger.Dept" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:Grid ID="gridDept" runat="server" Title="填报单位" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" PageSize="6" 
                                        EnableMultiSelect="false" EnableRowSelectEvent="true">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" runat="server" Text="确认" Icon="SystemSave"></f:Button>
                                <f:Button ID="btnClose" runat="server" Text="关闭" Icon="SystemClose"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:BoundField Width="120px" ColumnID="ID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="单位编号"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Name" DataField="Name" TextAlign="Center" HeaderText="单位名称"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Quality" SortField="Quality" DataField="Quality" TextAlign="Center" HeaderText="单位性质"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="RegionID" SortField="RegionID" DataField="RegionID" TextAlign="Center" HeaderText="区编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Contactor" SortField="Contactor" DataField="Contactor" TextAlign="Center" HeaderText="联系人"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Tel" SortField="Tel" DataField="Tel" TextAlign="Center" HeaderText="电话"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
