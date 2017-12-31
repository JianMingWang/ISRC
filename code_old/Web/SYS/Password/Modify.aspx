<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ISRC.Web.SYS.Password.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" LabelAlign="Top" EnableCollapse="true"
            Title="修改密码" Width="500px" ShowHeader="True">
            <Items>
                <f:TextBox runat="server" ID="txbOldPW" Label="旧密码" TextMode="Password" Required="true" EmptyText="请输入旧的登录密码"
                    AutoPostBack="true" >
                </f:TextBox>
                <f:TextBox runat="server" ID="txbNewPW" Label="新密码" TextMode="Password" EmptyText="请输入新的登陆密码">
                </f:TextBox>
                <f:TextBox runat="server" ID="txbNewPWConfirm" Label="确认新密码" TextMode="Password" EmptyText="请再次输入新的登录密码" EnableBlurEvent="true" AutoPostBack="true" OnTextChanged="txbNewPWConfirm_TextChanged">
                </f:TextBox>
                <f:Button runat="server" ID="btnChangePW" Enabled="false" Text="修改密码" OnClick="btnChangePW_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label ID="labelError" Hidden="true" Text="两次输入的密码不相同！" runat="server">
        </f:Label>
        <br />
    </form>
</body>
</html>
