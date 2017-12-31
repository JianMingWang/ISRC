<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.TB.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="pageManager_01" runat="server" AutoSizePanelID="panelMain"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="VBox">
            <Items>
                <f:Panel ID="panelTop" runat="server" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit">
                    <Items>
                        <f:Grid ID="gridTBFather" runat="server" Title="报表填报及维护" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" EnableCheckBoxSelect="false" PageSize="6" EnableRowClickEvent="true" 
                                        EnableMultiSelect="false" OnPreRowDataBound="gridTBFather_PreRowDataBound" OnRowClick="gridTBFather_RowClick" OnSort="gridTBFather_Sort" OnPageIndexChange="gridTBFather_PageIndexChange"
                                        OnRowCommand="gridTBFather_RowCommand" CheckBoxSelectOnly="false">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:Button ID="btnAdd" runat="server" Text="新增" Icon="Add"></f:Button>
                                        <f:ToolbarSeparator ID="toolbarSeparator_01" runat="server"></f:ToolbarSeparator>
                                        <f:ToolbarSeparator ID="toolbarSeparator1" runat="server"></f:ToolbarSeparator>
                                        <f:NumberBox ID="nbxStartYear" runat="server" Label="起始年份" Required="true" CompareControl="nbxEndYear" CompareOperator="LessThanEqual" CompareMessage="起始日期应该小于等于截止日期！"  Width="180px" LabelWidth="70px" OnTextChanged="nbxStartYear_TextChanged"></f:NumberBox>
                                        <f:NumberBox ID="nbxEndYear" runat="server" Label="截止年份" Required="true" CompareControl="nbxStartYear" CompareOperator="GreaterThanEqual" CompareMessage="截止日期应该大于等于起始日期！"  Width="180px" LabelWidth="70px" OnTextChanged="nbxEndYear_TextChanged"></f:NumberBox>                                       
                                        <f:DropDownList ID="ddlStatus" runat="server" Label="状态" Width="150px" LabelWidth="40px" AutoPostBack="true">
                                            <f:ListItem Text="全部" Value="all" />
                                            <f:ListItem Text="未提交" Value="0" />
                                            <f:ListItem Text="已提交" Value="1" />
                                            <f:ListItem Text="退审" Value="2" />
                                        </f:DropDownList>
                                        <f:Button ID="btnSearch" runat="server" Text="查询" Icon="SystemSearch" OnClick="btnSearch_Click"></f:Button>
                                        <f:Button ID="btnReturn" runat="server" Text="返回列表" Hidden="true" OnClick="btnReturn_Click"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:WindowField ID="windowEdit" Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit" ToolTip="编辑"
                                     DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                                        Title="填报维护" DataWindowTitleFormatString="编辑 - {0}" />
                                <f:LinkButtonField Width="60px" TextAlign="Center" ConfirmText="删除选中行？" Icon="Delete" ConfirmTarget="Top"
                                     ColumnID="lbDelete" HeaderText="删除" CommandName="Delete"></f:LinkButtonField>
                                <f:LinkButtonField Width="60px" TextAlign="Center" ConfirmText="提交选中报表？" Icon="Accept" ConfirmTarget="Top"
                                     ColumnID="lbSubmit" HeaderText="提交" CommandName="Submit"></f:LinkButtonField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="ID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="ID"></f:BoundField>
                                <f:BoundField  Width="100px" ColumnID="Cycle" SortField="Cycle" DataField="Cycle" TextAlign="Center" HeaderText="报表类型"></f:BoundField>
                                <f:BoundField  Width="100px" ColumnID="Year" SortField="Year" DataField="Year" TextAlign="Center" HeaderText="年"></f:BoundField>
                                <f:BoundField  Width="100px" ColumnID="Month" SortField="Month" DataField="Month" TextAlign="Center" HeaderText="月"></f:BoundField>
                                <f:BoundField  Width="100px" ColumnID="Quarter" SortField="Quarter" DataField="Quarter" TextAlign="Center" HeaderText="季度"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="SemiYear" SortField="SemiYear" DataField="SemiYear" TextAlign="Center" HeaderText="半年度"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="FillDate" SortField="FillDate" DataField="FillDate" TextAlign="Center" HeaderText="填报日期"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Status" SortField="Status" DataField="Status" TextAlign="Center" HeaderText="状态"></f:BoundField>
                                <f:BoundField Width="250px" ColumnID="Description" SortField="Description" DataField="Description" TextAlign="Center" HeaderText="说明"></f:BoundField>
                                
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel ID="panelBottom" runat="server" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit">
                    <Items>
                        <f:Grid ID="gridTBIndex" runat="server" Title="填报指标" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        DataKeyNames="ID" EnableCollapse="false" PageSize="10" EnableRowSelectEvent="true" 
                                        EnableMultiSelect="false" OnSort="gridTBIndex_Sort" OnPageIndexChange="gridTBIndex_PageIndexChange">
                            <Columns>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="sID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="ID"></f:BoundField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="ReportID" SortField="ReportID" DataField="ReportID" TextAlign="Center" HeaderText="父表ID"></f:BoundField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="IndexID" SortField="IndexID" DataField="IndexID" TextAlign="Center" HeaderText="填报指标"></f:BoundField>
                                <f:BoundField Width="150px" ColumnID="IndexName" SortField="IndexName" DataField="IndexName" TextAlign="Center" HeaderText="填报指标名"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="IndexValue" SortField="IndexValue" DataField="IndexValue" TextAlign="Center" HeaderText="指标值"></f:BoundField>
                                <f:BoundField Width="250px" ColumnID="sDescription" SortField="sDescription" DataField="sDescription" TextAlign="Center" HeaderText="说明"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" runat="server" Title="编辑" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="500px" OnClose="windowPop_Close"></f:Window>
    </form>
</body>
</html>
