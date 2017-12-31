<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ISRC.Web.JC.Region.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                                <f:TextBox ID="txbRegionNO" Label="地区编号" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>
                                <f:TextBox ID="txbRegionName" Label="地区名称" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>                                 
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
