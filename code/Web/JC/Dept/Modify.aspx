<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ISRC.Web.T_Dept.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改页</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pagemanager_01" AutoSizePanelID="panel_01" runat="server"></f:PageManager>
        <f:Panel ID="panel_01" Layout="Fit" ShowBorder="False" ShowHeader="false" runat="server">
            <Items>
                <f:Form ID="formInfo" ShowBorder="true" LabelAlign="Left" ShowHeader="false" EnableCollapse="false" Expanded="true" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="保存" ValidateForms="formInfo" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txtDeptID" Label="单位编号" Width="250px" LabelWidth="70px" Required="true" Enabled="false" runat="server">
                                </f:TextBox>
                                <f:TextBox ID="txbDeptName" Label="单位名称" Width="250px" LabelWidth="70px" Required="true" runat="server">
                                </f:TextBox>   
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlDeptQuality" Label="单位性质" Width="250px" LabelWidth="70px" Required="true" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlDeptQuality_SelectedIndexChanged">
                                    <f:ListItem Text="省市单位" Value="0" Selected="true" />
                                    <f:ListItem Text="区单位" Value="1" />
                                </f:DropDownList>
                                <f:TextBox ID="txtDeptTel" Label="电话" Width="250px" LabelWidth="70px" Required="true" runat="server">
                                </f:TextBox> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items> 
                                <f:TextBox ID="txbDeptContactor" Label="联系人" Width="250px" LabelWidth="70px" runat="server">
                                </f:TextBox>
                                 <f:TriggerBox ID="tgbDeptRegionID" Width="250px" LabelWidth="70px" Hidden="true" runat="server" Label="所在地区" EnableEdit="false" TriggerIcon="Search" Required="true">
                                </f:TriggerBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items> 
                                <f:NumberBox ID="nbxOderID" Label="排序等级" Width="250px" LabelWidth="70px" MinValue="0" NoDecimal="true" Required="true" runat="server">
                                </f:NumberBox>
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
        <f:Window ID="windowPop" Title="选择" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
