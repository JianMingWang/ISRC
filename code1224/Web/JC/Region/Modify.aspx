<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ISRC.Web.JC.Region.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                                <f:TextBox ID="txtRegionID" Label="地区编号" Width="250px" LabelWidth="70px" Required="true" Enabled="false" runat="server">
                                </f:TextBox>
                                <f:TextBox ID="txbRegionName" Label="地区名称" Width="250px" LabelWidth="70px" Required="true" runat="server">
                                </f:TextBox>   
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
