<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.T_Dept.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>填报单位维护</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridDept" Title="填报单位信息表" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="false"
                    DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="10" 
                    EnableMultiSelect="false" OnSort="gridDept_Sort" OnPageIndexChange="gridDept_PageIndexChange" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" Text="删除" OnClick="btnDelete_Click" Icon="Delete" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="Name" DataWindowTitleFormatString="编辑 - {0}" />
                        <f:BoundField Width="120px" ColumnID="ID" SortField="ID" DataField="ID"
                                    TextAlign="Center" HeaderText="单位编号"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Name" DataField="Name"
                                    TextAlign="Center" HeaderText="单位名称"></f:BoundField>
                        <f:TemplateField Width="100px" TextAlign="Center" HeaderText="单位性质" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="lblQuality" runat="server" Text='<%# ISRC.Web.Code.PublicMethod.getKey("Quality",Eval("Quality").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="100px" ColumnID="RegionID" SortField="RegionID" DataField="RegionID"
                                    TextAlign="Center" HeaderText="区编号"></f:BoundField>
                        <f:BoundField Width="100px" ColumnID="Contactor" SortField="Contactor" DataField="Contactor"
                                    TextAlign="Center" HeaderText="联系人"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="Tel" SortField="Tel" DataField="Tel"
                                    TextAlign="Center" HeaderText="电话"></f:BoundField>
                        <f:BoundField Width="100px" ColumnID="OderID" SortField="OderID" DataField="OderID"
                                    TextAlign="Center" HeaderText="排序等级"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>