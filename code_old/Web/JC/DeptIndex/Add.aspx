<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ISRC.Web.JC.DeptIndex.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" runat="server" Text="关闭" Icon="SystemClose"></f:Button>
                        <f:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Icon="SystemSave"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:TextBox ID="txtName" Enabled="false" runat="server" Label="单位名称" Width="300px" LabelWidth="100px" Readonly="true" Required="true"></f:TextBox>
                <f:Tree ID="treeIndex" OnNodeCheck="treeIndex_NodeCheck" Width="850px" ShowHeader="true" EnableCollapse="true" Title="可选指标" runat="server">

                </f:Tree>



                <f:Grid ID="gridIndex" Hidden="true" runat="server" ShowBorder="true" AllowPaging="true" ShowHeader="false" IsDatabasePaging="true"
                                        DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="6" 
                                        EnableMultiSelect="false" EnableRowSelectEvent="true">
                    <Columns>
                        <f:TemplateField Width="120px" HeaderText="子指标编号" TextAlign="Center">
                            <ItemTemplate>
                                <f:TextBox ID="txbID" runat="server" Readonly="true"></f:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField Width="150px" HeaderText="子指标名称" TextAlign="Center">
                            <ItemTemplate>
                                <f:TextBox ID="txbName" runat="server" Readonly="true"></f:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField Width="150px" HeaderText="大类指标名称" TextAlign="Center">
                            <ItemTemplate>
                                <f:TextBox ID="txbCategoryID" runat="server" Readonly="true"></f:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField Width="250px" HeaderText="描述" TextAlign="Center">
                            <ItemTemplate>
                                <f:TextArea ID="txaDescription" runat="server" Height="50px"></f:TextArea>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>


            </Items>
        </f:Panel>
        <f:Window ID="windowPop" runat="server" Title="编辑" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="500px"></f:Window>
    </form>
</body>
</html>
