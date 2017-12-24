<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ISRC.Web.JC.Index.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="pageManager_01"  AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Text="关闭" OnClick="btnClose_Click" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formIndexInfo" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="formIndexInfo" ShowBorder="false" LabelAlign="left" ShowHeader="false" runat="server"
                                    EnableCollapse="false" Expanded="true" LabelWidth="100px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbIndexNO" Enabled="false" Label="指标编号" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>
                                <f:TextBox ID="txbIndexName" Label="指标名称" Width="250px" LabelWidth="70px" Required="true" runat="server"></f:TextBox>                                 
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlIndexCategory" Label="父类目" Width="250px" LabelWidth="70px" Required="true" runat="server" AutoPostBack="true" >
                                </f:DropDownList>
                            </Items>
                         </f:FormRow>
                         <f:FormRow>
                            <Items> 
                                <f:TextBox ID="txbIndexDescription" Hidden="false" Label="指标描述" Width="250px" LabelWidth="70px" runat="server"></f:TextBox>
                                <f:NumberBox ID="nbxIndexOrderID" Hidden="false" Label="排序等级" Width="250px" LabelWidth="70px" MinValue="0" NoDecimal="true" Required="true" runat="server"></f:NumberBox>
                            </Items>
                         </f:FormRow>
                        <f:FormRow>
                            <Items> 
                                 <f:DropDownList ID="ddlIndexCycle"  Width="250px" LabelWidth="70px" runat="server" Label="填报类型">
                                     <f:ListItem Text="不受限" Value="0" />
                                     <f:ListItem Text="月报表" Value="1"  />
                                     <f:ListItem Text="季报表" Value="2"  />
                                     <f:ListItem Text="半年报表" Value="3" />
                                     <f:ListItem Text="年报表" Value="4" />
                                 </f:DropDownList>
                                <f:DropDownList ID="ddlIndexMultiIndex"  Width="250px" LabelWidth="70px" Required="true" runat="server"   Label="是否参与多指标">
                                     <f:ListItem Text="不参与" Value="0"  />
                                     <f:ListItem Text="参与" Value="1"  />                           
                                 </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>  
            </Items>
        </f:Panel>
    </form>
</body>
</html>
