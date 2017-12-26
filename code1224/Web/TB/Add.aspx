<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ISRC.Web.TB.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="pageManager_01" runat="server" OnCustomEvent="pageManager_01_CustomEvent" AutoSizePanelID="panelMain"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" runat="server" Text="关闭" Icon="SystemClose"></f:Button>
                        <f:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Icon="SystemSave"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="panelBottom" runat="server" ShowBorder="false" ShowHeader="false" Layout="VBox">
                    <Items>
                        <f:Panel ID="panelUp" runat="server" Width="400px" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:Form ID="formInfo_01" runat="server" ShowBorder="true" LabelAlign="left" ShowHeader="false"
                                     EnableCollapse="false" Expanded="true">
                                    <Rows>
                                        <f:FormRow>
                                            <Items>
                                                <f:TextBox ID="txbID" runat="server" Label="ID" Hidden="true"></f:TextBox>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:NumberBox ID="nbxYear" runat="server" Label="年份" Width="210px" LabelWidth="70px" AutoPostBack="true" OnTextChanged="nbxYear_TextChanged"></f:NumberBox>
                                                <f:DropDownList ID="ddlCycle" runat="server" Label="报表类型" Width="210px" LabelWidth="70px" AutoPostBack="true"
                                                    Required="true"  OnSelectedIndexChanged="ddlCycle_SelectedIndexChanged">
                                                    <f:ListItem Text="请选择报表类型" Selected="true" />
                                                    <f:ListItem Text="月报表" Value="1" />
                                                    <f:ListItem Text="季报表" Value="2" />
                                                    <f:ListItem Text="半年报表" Value="3" />
                                                    <f:ListItem Text="年报表" Value="4" />
                                                </f:DropDownList>
                                                <f:DropDownList ID="ddlCycleList" runat="server" Hidden="true" Width="210px" LabelWidth="70px" AutoPostBack="true"></f:DropDownList>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:DatePicker ID="dapFillDate" runat="server" Label="填报日期" Width="210px" LabelWidth="70px"></f:DatePicker>
                                                <f:TextBox ID="txbStatus" runat="server" Label="状态" Width="210px" LabelWidth="70px" Text="未提交" Enabled="false"></f:TextBox>
                                                <f:TextBox runat="server" Hidden="true"></f:TextBox>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:TextArea ID="txaDescription" runat="server" Height="100px" Label="说明" LabelWidth="70px" Width="500px"></f:TextArea>
                                            </Items>
                                        </f:FormRow>
                                    </Rows>
                                </f:Form>
                            </Items>
                        </f:Panel>
                        <f:Panel runat="server" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:Button ID="btnIndex" runat="server" Text="填报指标" OnClick="btnIndex_Click"></f:Button>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="panelIndex" runat="server" ShowBorder="false" ShowHeader="false" Title="填报指标" Hidden="true">
                            <Items>
                                <f:Grid ID="gridIndex" runat="server" ShowBorder="false" ShowHeader="false" PageSize="5" AllowPaging="true"
                                     IsDatabasePaging="true" DataKeyNames="ID,ReportID,IndexID,IndexName" OnPageIndexChange="gridIndex_PageIndexChange"
                                     AllowCellEditing="true" ClicksToEdit="1">
                                    <Columns>
                                        <f:BoundField Width="100px" Hidden="true" ColumnID="ID" SortField="ID" DataField="ID" TextAlign="Center" HeaderText="ID"></f:BoundField>
                                        <f:BoundField Width="100px" Hidden="true" ColumnID="ReportID" SortField="ReportID" DataField="ReportID" TextAlign="Center" HeaderText="父表ID"></f:BoundField>
                                        <f:BoundField Width="100px" Hidden="true" ColumnID="IndexID" SortField="IndexID" DataField="IndexID" TextAlign="Center" HeaderText="填报指标"></f:BoundField>
                                        <f:BoundField Width="150px" Enabled="false" ColumnID="IndexName" SortField="IndexName" DataField="IndexName" TextAlign="Center" HeaderText="填报指标名"></f:BoundField>
                                        <f:RenderField Width="150px" ColumnID="IndexValue" DataField="IndexValue" TextAlign="Center" HeaderText="指标值">
                                            <Editor>
                                                <f:TextBox ID="txbIndexValue" runat="server" Required="true" RegexPattern="NUMBER"  Width="120px"></f:TextBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="400px" ColumnID="sDescription" DataField="sDescription" TextAlign="Center" HeaderText="说明">
                                            <Editor>
                                                <f:TextArea ID="txaSubDescription" runat="server" Height="30px" Width="380px"></f:TextArea>
                                            </Editor>
                                        </f:RenderField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="新增" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
