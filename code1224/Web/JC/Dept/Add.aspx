<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ISRC.Web.T_Dept.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增填报单位</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01"  AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formInfo_01,formInfo_02" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="formInfo_01" ShowBorder="false" LabelAlign="left" ShowHeader="false" runat="server"
                                    EnableCollapse="false" Expanded="true" LabelWidth="100px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbDeptNO" Label="单位编号" Width="250px" LabelWidth="70px" Required="true" RegexPattern="NUMBER" runat="server"></f:TextBox>
                                <f:TextBox ID="txbDeptName" Label="单位名称" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>                                 
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlDeptQuality" Label="单位性质" Width="250px" LabelWidth="70px" Required="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDeptQuality_SelectedIndexChanged">
                                    <f:ListItem Text="省市单位" Value="0" Selected="true" />
                                    <f:ListItem Text="区单位" Value="1" />
                                </f:DropDownList>
                                <f:TextBox ID="txtDeptTel" Label="电话" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>
                            </Items>
                         </f:FormRow>
                         <f:FormRow>
                            <Items> 
                                <f:TextBox ID="txbDeptContactor" Label="联系人" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>
                                <f:TriggerBox ID="tgbDeptRegionID" Width="250px" LabelWidth="70px" runat="server" Hidden="true" Label="所在地区" EnableEdit="false" TriggerIcon="Search" Required="true"></f:TriggerBox> 
                            </Items>
                         </f:FormRow>
                         <f:FormRow>
                            <Items> 
                                <f:NumberBox ID="nbxOderID" Label="排序等级" Width="250px" LabelWidth="70px" MinValue="0" NoDecimal="true" Required="true" runat="server"></f:NumberBox>
                            </Items>
                         </f:FormRow>
                         <f:FormRow>
                            <Items>
                                <f:HiddenField ID="hdfDeptNO" runat="server"></f:HiddenField>
                            </Items>
                         </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="新增" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
