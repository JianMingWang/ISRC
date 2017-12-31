<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ISRC.Web.JC.DeptIndex.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" runat="server" Text="关闭" Icon="SystemClose"></f:Button>
                        <f:Button ID="btnSave" runat="server" Text="保存" Icon="SystemSave"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:TriggerBox ID="tgbName" runat="server" Label="单位名称" Width="250px" LabelWidth="70px" TriggerIcon="Search" EnableEdit="false" Required="true" Readonly="true"></f:TriggerBox>
                <f:TextBox ID="txtDeptID" runat="server" Label="单位ID" Width="250px" LabelWidth="70px" Readonly="true" Required="true"></f:TextBox>
                <f:Grid ID="gridDeptIndex" runat="server" Title="填报指标" ShowBorder="true" ShowHeader="true">
                    <Columns>
                        <f:RenderField Width="120px" ColumnID="ID" DataField="ID" FieldType="String" HeaderText="子指标编号" TextAlign="Center">
                            <Editor>
                                <f:TriggerBox ID="tgbIndexID" runat="server" Label="子指标编号" TriggerIcon="Search" EnableEdit="false" Required="true"></f:TriggerBox>
                            </Editor>
                        </f:RenderField>
                        <f:BoundField Width="150px" ColumnID="Name" SortField="Name" DataField="Name" TextAlign="Center" HeaderText="子指标名称"></f:BoundField>
                        <f:BoundField Width="150px" ColumnID="CategoryID" SortField="CategoryID" DataField="CategoryID" TextAlign="Center" HeaderText="父指标"></f:BoundField>
                        <f:TemplateField Width="250px" HeaderText="描述" TextAlign="Center">
                            <ItemTemplate>
                                <f:TextArea ID="txaDscription" runat="server" Height="50px"></f:TextArea>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
