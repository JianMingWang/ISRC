<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ISRC.Web.SYS.Role.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增角色</title>
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
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formInfo_01" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="formInfo_01" ShowBorder="false" LabelAlign="left" ShowHeader="false" runat="server"
                                    EnableCollapse="false" Expanded="true" LabelWidth="100px" BodyPadding="10px">
                    <Rows>
                         <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbRoleName" Label="角色名称" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>
                                <f:NumberBox ID="txbSortNo" Label="排序" Width="250px" LabelWidth="70px" MinValue="1" NoDecimal="true" Required="false" runat="server" Text="1"></f:NumberBox>
                            </Items>
                         </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
