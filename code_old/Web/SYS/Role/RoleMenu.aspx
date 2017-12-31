<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleMenu.aspx.cs" Inherits="ISRC.Web.SYS.Role.RoleMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色权限</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" Icon="SystemSave">
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
                                <f:Tree ID="treeMenu" runat="server" ShowBorder="true" ShowHeader="false" AutoScroll="true"
                                     OnNodeCheck="treeMenu_NodeCheck">
                                </f:Tree>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
