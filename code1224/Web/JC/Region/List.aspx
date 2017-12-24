<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.JC.Region.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
    <div>
        <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridRegion" Title="地区信息表" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                    DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="15" 
                    EnableMultiSelect="false" OnSort="gridRegion_Sort" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" OnClick="btnDelete_Click" Text="删除" Icon="Delete" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                        <f:BoundField Width="120px" ColumnID="ID" SortField="ID" DataField="ID"
                                    TextAlign="Center" HeaderText="地区编号"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Name" DataField="Name"
                                    TextAlign="Center" HeaderText="地区名称"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </div>
    </form>
</body>
</html>
