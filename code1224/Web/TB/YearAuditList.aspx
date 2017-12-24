<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearAuditList.aspx.cs" Inherits="ISRC.Web.TB.YearAuditList" %>

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
                        <f:Grid ID="gridAudit" runat="server" Title="年度报表审核" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" EnableCheckBoxSelect="false" PageSize="6" EnableRowClickEvent="true" 
                                        EnableMultiSelect="false" OnRowClick="gridAudit_RowClick" OnSort="gridAudit_Sort" OnPageIndexChange="gridAudit_PageIndexChange"
                                        OnRowCommand="gridAudit_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:DropDownList ID="ddlCycle" runat="server" Label="报表类型" Width="190px" LabelWidth="65px" AutoPostBack="true" OnSelectedIndexChanged="ddlCycle_SelectedIndexChanged">
                                            <f:ListItem Text="所有报表类型" Selected="true" Value="0" />
                                            <f:ListItem Text="月报表" Value="1" />
                                            <f:ListItem Text="季报表" Value="2" />
                                            <f:ListItem Text="半年报表" Value="3" />
                                            <f:ListItem Text="年报表" Value="4" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="nbxStartYear" runat="server" Label="起始年份" Required="true" CompareControl="nbxEndYear" CompareOperator="LessThanEqual" CompareMessage="起始日期应该小于等于截止日期！" Width="160px" LabelWidth="65px" AutoPostBack="true" OnTextChanged="nbxStartYear_TextChanged"></f:NumberBox>
                                        <f:DropDownList ID="ddlStartPeriod" runat="server" Hidden="true" Width="100px" AutoPostBack="true"></f:DropDownList>
                                        <f:NumberBox ID="nbxEndYear" runat="server" Label="截止年份" Required="true" CompareControl="nbxStartYear" CompareOperator="GreaterThanEqual" CompareMessage="截止日期应该大于等于起始日期！"  Width="160px" LabelWidth="65px" AutoPostBack="true" OnTextChanged="nbxEndYear_TextChanged"></f:NumberBox>
                                        <f:DropDownList ID="ddlEndPeriod" runat="server" Hidden="true" Width="100px" AutoPostBack="true"></f:DropDownList>
                                        <f:DropDownList ID="ddlStatus" runat="server" Label="状态" Width="150px" LabelWidth="40px">
                                            <f:ListItem Text="请选择状态" Selected="true" Value="0" />
                                            <f:ListItem Text="已提交" Value="1" />
                                            <f:ListItem Text="退审" Value="2" />
                                        </f:DropDownList>
                                        <f:Button ID="btnSearch" runat="server" Text="查询" Icon="SystemSearch" OnClick="btnSearch_Click"></f:Button>
                                        <f:Button ID="btnReturn" runat="server" Text="返回列表" Hidden="true" OnClick="btnReturn_Click"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:LinkButtonField Width="60px" TextAlign="Center" ConfirmText="退回该报表？" Icon="Cross" ConfirmTarget="Top"
                                     ColumnID="lbReturn" HeaderText="退审" CommandName="Return"></f:LinkButtonField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="ID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="ID"></f:BoundField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="DeptID" SortField="DeptID" DataField="DeptID" TextAlign="Center" HeaderText="单位ID"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="DeptName" SortField="DeptName" DataField="DeptName" TextAlign="Center" HeaderText="填报单位"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Cycle" SortField="Cycle" DataField="Cycle" TextAlign="Center" HeaderText="报表类型"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Year" SortField="Year" DataField="Year" TextAlign="Center" HeaderText="年"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Month" SortField="Month" DataField="Month" TextAlign="Center" HeaderText="月"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Quarter" SortField="Quarter" DataField="Quarter" TextAlign="Center" HeaderText="季度"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="SemiYear" SortField="SemiYear" DataField="SemiYear" TextAlign="Center" HeaderText="半年度"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="Status" SortField="Status" DataField="Status" TextAlign="Center" HeaderText="状态"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="FillDate" SortField="FillDate" DataField="FillDate" TextAlign="Center" HeaderText="填报日期"></f:BoundField>
                                <f:BoundField Width="100px" Hidden="true" ColumnID="UserID" SortField="UserID" DataField="UserID" TextAlign="Center" HeaderText="用户ID"></f:BoundField>
                                <f:BoundField Width="100px" ColumnID="UserName" SortField="UserName" DataField="UserName" TextAlign="Center" HeaderText="填报用户"></f:BoundField>
                                <f:BoundField Width="250px" ColumnID="Description" SortField="Description" DataField="Description" TextAlign="Center" HeaderText="说明"></f:BoundField>
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel ID="panelBottom" runat="server" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit">
                    <Items>
                        <f:Grid ID="gridAuditIndex" runat="server" Title="报表指标" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                        DataKeyNames="ID" EnableCollapse="false" PageSize="6" EnableRowSelectEvent="true" 
                                        EnableMultiSelect="false" OnSort="gridAuditIndex_Sort" OnPageIndexChange="gridAuditIndex_PageIndexChange">
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
                EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="500px"></f:Window>
    </form>
</body>
</html>
