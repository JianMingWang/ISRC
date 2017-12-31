<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="ISRC.Web.Trigger.Region" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server">
            <Items>
                <f:Grid ID="gridRegion" Title="地区信息表" ShowBorder="false" AllowPaging="false" ShowHeader="true" IsDatabasePaging="true"
                    DataKeyNames="ID" AllowSorting="false" EnableCollapse="false" EnableCheckBoxSelect="true"
                    EnableMultiSelect="false" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="确认" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:BoundField Width="120px" ColumnID="ID" SortField="ID" DataField="ID"
                            TextAlign="Center" HeaderText="地区编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Name" SortField="Name" DataField="Name"
                            TextAlign="Center" HeaderText="地区名称"></f:BoundField>
                        
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
