<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexCategory.aspx.cs" Inherits="ISRC.Web.Trigger.IndexCategory" %>

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
                <f:Grid ID="gridIndexCategory" runat="server" Title="父类指标" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
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
                        <f:BoundField Width="120px" ColumnID="ID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="大类指标编号"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Name" DataField="Name" TextAlign="Center" HeaderText="大类指标名"></f:BoundField>
                        <f:BoundField Width="100px" ColumnID="FatherID" SortField="FatherID" DataField="FatherID" TextAlign="Center" HeaderText="父类目"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
