<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ISRC.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�û���¼</title>
    <link href="CSS/login/xtree.css" type="text/css" rel="stylesheet" />
    <link href="CSS/login/User_Login.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
</head>
<body id="userlogin_body">
    <form runat="server">
        <div></div>

        <div id="user_login">
            <dl>
                <dd id="user_top">
                    <ul>
                        <li class="user_top_l"></li>
                        <li class="user_top_c"></li>
                        <li class="user_top_r"></li>
                    </ul>
                    <dd id="user_main">
                        <ul>
                            <li class="user_main_l"></li>
                            <li class="user_main_c">
                                <div class="user_main_box">
                                    <ul>
                                        <li class="user_main_text">�û����� </li>
                                        <li class="user_main_input">
                                            <asp:TextBox runat="server" ID="txbUserName" CssClass="TxtUserNameCssClass" MaxLength="20"></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li class="user_main_text">�� �룺 </li>
                                        <li class="user_main_input">
                                            <asp:TextBox runat="server" ID="txbPassword" CssClass="TxtPasswordCssClass" TextMode="Password"></asp:TextBox>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="user_main_r">
                                <asp:ImageButton runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="IbtnEnterCssClass"
                                    ImageUrl="~/Images/login/user_botton.gif" />
                            </li>
                        </ul>
                        <dd id="user_bottom">
                            <ul>
                                <li class="user_bottom_l"></li>
                                <li class="user_bottom_c"><span style="MARGIN-TOP: 40px"></span></li>
                                <li class="user_bottom_r"></li>
                            </ul>
                        </dd>
            </dl>
        </div>
        <div></div>
    </form>
</body>
<script src="Js/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input[type='image']").click(function () {
            if ($("input.TxtUserNameCssClass").val() == "") {
                alert("�û�������Ϊ��");
                return false;
            }
            if ($("input.TxtPasswordCssClass").val() == "") {
                alert("���벻��Ϊ��");
                return false;
            }
            return true;
        })
    })

</script>
</html>
