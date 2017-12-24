<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ISRC.Web.JC.Index.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />  
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="HBox">                 
            <Items>
                <f:Panel ID="panelLeft"  BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Layout="Fit">                  
                    <Items>
                        <f:Tree ID="treeBOM" Title="BOM单" ShowBorder="false" ShowHeader="false" EnableSingleClickExpand="false" 
                                EnableCollapse="true" runat="server" AutoScroll="True" EnableMultiSelect="false" OnNodeCommand="treeBOM_NodeCommand">
                        </f:Tree>
                    </Items>
                </f:Panel>
                <f:Panel ID="panelRight" BoxFlex="3" runat="server" ShowBorder="false" ShowHeader="false" Layout="VBox">
                    <Items>
                        <f:Panel ID="panelRightIndex" Hidden="false" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit" runat="server">
                            <Items>
                                <f:Grid ID="gridIndex" Title="子类指标信息表" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="15" 
                                EnableMultiSelect="false" runat="server">
                                    <Toolbars>
                                        <f:Toolbar ID="toolbar_01" runat="server">
                                            <Items>
                                                <f:Button ID="btnAdd" Text="新增" Enabled="false" Icon="Add" runat="server">
                                                </f:Button>
                                                    <f:Button ID="btnDelete" OnClick="btnDelete_Click" Text="删除" Enabled="false" Icon="Delete" runat="server">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                                        ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?IndexID={0}&IndexType=1"
                                        DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                                        <f:BoundField Width="80px" ColumnID="IndexNO" SortField="ID" DataField="ID"
                                                TextAlign="Center" HeaderText="指标编号"></f:BoundField>
                                        <f:BoundField Width="110px" ColumnID="IndexName" SortField="Name" DataField="Name"
                                                TextAlign="Center" HeaderText="指标名称"></f:BoundField>
                                        <f:BoundField Width="110px" ColumnID="IndexCategoryID" SortField="FatherID" DataField="FatherID"
                                                TextAlign="Center" HeaderText="大类指标"></f:BoundField>
                                        <f:BoundField Width="110px" ColumnID="IndexOderID" SortField="OderID" DataField="OderID"
                                                TextAlign="Center" HeaderText="排序等级"></f:BoundField>
                                        <f:BoundField Width="110px" ColumnID="IndexCycle" SortField="Cycle" DataField="Cycle"
                                                TextAlign="Center" HeaderText="填报类型"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="IndexMultiIndex" SortField="MultiIndex" DataField="MultiIndex"
                                                TextAlign="Center" HeaderText="是否参与多指标"></f:BoundField>
                                        <f:BoundField Width="160px" ColumnID="IndexDescription" SortField="Description" DataField="Description"
                                                TextAlign="Center" HeaderText="指标描述"></f:BoundField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="panelRightIndexCategory" Hidden="false" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit" runat="server">
                            <Items>
                                <f:Grid ID="gridIndexCategory" Title="父类指标信息表" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="15" 
                                EnableMultiSelect="false" runat="server">
                                    <Toolbars>
                                        <f:Toolbar ID="toolbar1" runat="server">
                                            <Items>
                                                <f:Button ID="btnAdd_IndexCategory" Text="新增" Icon="Add" runat="server">
                                                </f:Button>
                                                    <f:Button ID="btnDelete_IndexCategory" OnClick="btnDelete_IndexCategory_Click"  Text="删除" Icon="Delete" runat="server">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                                        ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?IndexID={0}&IndexType=0"
                                        DataWindowTitleField="IndexCategoryName" DataWindowTitleFormatString="编辑 - {0}" />
                                        <f:BoundField Width="120px" ColumnID="IndexCategoryNO" SortField="ID" DataField="ID"
                                                TextAlign="Center" HeaderText="大类指标编号"></f:BoundField>
                                        <f:BoundField Width="150px" ColumnID="IndexCategoryName" SortField="Name" DataField="Name"
                                                TextAlign="Center" HeaderText="大类指标名"></f:BoundField>
                                        <f:BoundField Width="150px" ColumnID="IndexCategoryFatherID" Hidden="true" SortField="FatherID" DataField="FatherID"
                                                TextAlign="Center" HeaderText="父类目"></f:BoundField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>    
                </f:Panel>

            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="windowPop_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
