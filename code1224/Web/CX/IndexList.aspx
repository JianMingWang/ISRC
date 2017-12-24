<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="IndexList.aspx.cs" Inherits="ISRC.Web.CX.IndexList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .resultTable {
            border: 1px solid #000; border-collapse: collapse;
        }
        .resultTable td {
            padding:8px;
        }
    </style>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:DropDownList ID="ddlIndex" runat="server" Label="指标类型">
                            <f:ListItem Text="请选择一项指标" Value="-1" Selected="true" />
                        </f:DropDownList>
                    </Items>
                </f:Toolbar>

                <f:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <f:DropDownList ID="ddlReportType" runat="server" Label="报表类型" OnSelectedIndexChanged="reportType_SelectedIndexChanged" AutoPostBack="true">
                            <f:ListItem Text="请选择" Value="-1" Selected="true" />
                            <f:ListItem Text="月报表" Value="1" Selected="true" />
                            <f:ListItem Text="季度报表" Value="2" />
                            <f:ListItem Text="半年报表" Value="3" />
                            <f:ListItem Text="年报表" Value="4" />
                        </f:DropDownList>
                        <f:NumberBox ID="nbxStartYear" runat="server" Hidden="true" Label="年份" Width="150px" LabelWidth="40px" AutoPostBack="true"></f:NumberBox>
                        <f:DropDownList ID="startMonth" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="一月" Value="1" Selected="true" />
                            <f:ListItem Text="二月" Value="2" />
                            <f:ListItem Text="三月" Value="3" />
                            <f:ListItem Text="四月" Value="4" />
                            <f:ListItem Text="五月" Value="5" />
                            <f:ListItem Text="六月" Value="6" />
                            <f:ListItem Text="七月" Value="7" />
                            <f:ListItem Text="八月" Value="8" />
                            <f:ListItem Text="九月" Value="9" />
                            <f:ListItem Text="十月" Value="10" />
                            <f:ListItem Text="十一月" Value="11" />
                            <f:ListItem Text="十二月" Value="12" />
                        </f:DropDownList>

                        <f:DropDownList ID="startQuarter" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="第一季度" Value="1" Selected="true" />
                            <f:ListItem Text="第二季度" Value="2" />
                            <f:ListItem Text="第三季度" Value="3" />
                            <f:ListItem Text="第四季度" Value="4" />
                        </f:DropDownList>

                        <f:DropDownList ID="startHalfYear" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="上半年" Value="1" Selected="true" />
                            <f:ListItem Text="下半年" Value="2" />
                        </f:DropDownList>

                        <f:NumberBox ID="nbxEndYear" runat="server" Hidden="true" Label="年份" Width="150px" LabelWidth="40px" AutoPostBack="true"></f:NumberBox>
                        <f:DropDownList ID="endMonth" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="一月" Value="1" Selected="true" />
                            <f:ListItem Text="二月" Value="2" />
                            <f:ListItem Text="三月" Value="3" />
                            <f:ListItem Text="四月" Value="4" />
                            <f:ListItem Text="五月" Value="5" />
                            <f:ListItem Text="六月" Value="6" />
                            <f:ListItem Text="七月" Value="7" />
                            <f:ListItem Text="八月" Value="8" />
                            <f:ListItem Text="九月" Value="9" />
                            <f:ListItem Text="十月" Value="10" />
                            <f:ListItem Text="十一月" Value="11" />
                            <f:ListItem Text="十二月" Value="12" />
                        </f:DropDownList>

                        <f:DropDownList ID="endQuarter" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="第一季度" Value="1" Selected="true" />
                            <f:ListItem Text="第二季度" Value="2" />
                            <f:ListItem Text="第三季度" Value="3" />
                            <f:ListItem Text="第四季度" Value="4" />
                        </f:DropDownList>

                        <f:DropDownList ID="endHalfYear" runat="server" Width="100px" Hidden="true">
                            <f:ListItem Text="上半年" Value="1" Selected="true" />
                            <f:ListItem Text="下半年" Value="2" />
                        </f:DropDownList>
                        
                        <f:Button ID="queryBtn" runat="server" Text="查询" EnableAjax="false" 
                            OnClick="queryBtn_Click">
                        </f:Button>

                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:ContentPanel ID="ContentPanel1" BodyPadding="10px" EnableCollapse="false"
                    ShowHeader="true" runat="server" Title="查询结果" AutoScroll="true">
                    <div id="resultDiv">
                        <table id="tbResult" border="1" style="display:none;">                            
                        </table>
                    </div>
                    <br />

                    <div id="chartDiv" style="display:none;">
                        <div>
                            选择生成的图表类型：
                            <select id="chartOptions">
                                <option value="0" selected="selected">柱状图</option>
                                <option value="1">折线图</option>
                            </select>
                        </div>
                        <div id="echart" style="width: 600px;height:400px;"></div>
                    </div>
                </f:ContentPanel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
<script src="../Js/jquery.min.js"></script>
<script src="../Js/echarts.common.min.js"></script>
<script type="text/javascript">
    var jsonStr = '<%=jsonStr%>';
    //alert(jsonStr);
    var jsonObj = $.parseJSON(jsonStr);
        
    $(document).ready(function () {
        if (jsonStr != "") {
            drawTable(jsonObj);
            drawBar(jsonObj);
        }
        
        //选择图表类型
        $("#chartOptions").change(function () {
            if (jsonStr == "") {
                return;
            }
            var value = $(this).val();
            if (value == "0") {
                drawBar(jsonObj);
            }
            if (value == "1") {
                drawLine(jsonObj);
            }
        })


        //画二维表格
        function drawTable(jsonObj) {
            var data = jsonObj["Data"];
            var row1 = '<tr><td>时间</td>';
            var row2 = '<tr><td>指标值</td>';
            for (var k in data) {
                row1 += '<td>' + k + '</td>';
                if (data[k][0] == 0) {
                    row2 += '<td>' + '</td>';
                }
                else {
                    row2 += '<td>' + data[k][0] + '</td>';
                }
            }
            row1 += '</tr>';
            row2 += '</tr>';
            $("#tbResult").html(row1 + row2).addClass('resultTable').show();
        }


        //画柱状图
        function drawBar(jsonObj) {
            var indexNameArr = jsonObj["IndexNameArr"];
            var data = jsonObj["Data"];
            var timeArr = new Array();
            var valueArr = new Array();

            var i = 0;
            for (var k in data) {
                timeArr[i] = k;
                valueArr[i] = data[k][0];
                i++;
            }

            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(document.getElementById("echart"));

            // 指定图表的配置项和数据
            var option = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                legend: {
                    data: indexNameArr
                },
                xAxis: {
                    data: timeArr
                },
                yAxis: {},
                series: [{
                    name: indexNameArr[0],
                    type: 'bar',
                    data: valueArr
                }]
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            $("#chartDiv").show();
        }


        //画折线图
        function drawLine(jsonObj) {
            var indexNameArr = jsonObj["IndexNameArr"];
            var data = jsonObj["Data"];
            var timeArr = new Array();
            var valueArr = new Array();

            var i = 0;
            for (var k in data) {
                timeArr[i] = k;
                valueArr[i] = data[k][0];
                i++;
            }

            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(document.getElementById("echart"));

            // 指定图表的配置项和数据
            var option = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                legend: {
                    data: indexNameArr
                },
                xAxis: {
                    boundaryGap: false,
                    data: timeArr
                },
                yAxis: {},
                series: [{
                    name: indexNameArr[0],
                    type: 'line',
                    data: valueArr
                }]
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            $("#chartDiv").show();
        }
    })
</script>