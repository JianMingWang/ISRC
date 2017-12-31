<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MultiIndexList.aspx.cs" Inherits="ISRC.Web.CX.MultiIndexList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .resultTable {
            border: 1px solid #000;
            border-collapse: collapse;
        }

            .resultTable td {
                padding: 8px;
            }
    </style>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar3" runat="server">
                    <Items>
                        <f:ContentPanel ID="CheckList" Width="1200px" runat="server" Title="选择指标" BodyPadding="5px">
                            <f:CheckBoxList ID="IndexList" runat="server" ColumnNumber="3" Width="1200px" ColumnVertical="true" ShowRedStar="true" Required="true">

                            </f:CheckBoxList>
                        </f:ContentPanel>
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
                    <div id="resultDiv" style="padding-bottom:200px;">
                        <table id="tbResult" border="1" style="display: none;">
                        </table>
                    </div>
                    <br />
                    <div id="chartDiv" style="display: none;">
                        <div style="float:left;">
                            <div>
                                按指标统计：
                                <select id="chartOptions">
                                    <option value="0" selected="selected">柱状图</option>
                                    <option value="1">折线图</option>
                                </select>
                                <br />
                            </div>
                            <div id="echart" style="width: 500px; height: 400px;"></div>
                        </div>
                        <div style="float:left; margin-left:20px;">
                            按时间统计：
                            <select id="timeOptions">
                            </select>
                            <br />
                            <div id="echartPie" style="width: 500px; height: 400px;"></div>
                        </div>
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
    $(document).ready(function () {
        var jsonStr = '<%=jsonStr%>';
        //alert(jsonStr);
        var jsonObj = $.parseJSON(jsonStr);
        var data, indexNameArr, timeArr;

        if (jsonStr != "") {
            data = jsonObj["Data"];//json中的指标数据，key为时间，value为多指标值构成的数组
            indexNameArr = jsonObj["IndexNameArr"];//指标名称集合
            timeArr = new Array();//时间序列，为一个数组
            for (var k in data) {
                timeArr.push(k);
            }
            drawTable();
            drawBar();
            initTimeOption();
        }

        //选择图表类型
        $("#chartOptions").change(function () {
            if (jsonStr == "") {
                return;
            }
            var value = $(this).val();
            if (value == "0") {
                drawBar();
            }
            if (value == "1") {
                drawLine();
            }
        })

        //选择时间，生成饼形图
        $("#timeOptions").change(function () {
            if (jsonStr == "") {
                return;
            }
            drawPie($(this).val());
        })

        //画二维表格，行列数均不确定
        function drawTable() {
            var timeRow = '<tr><td>时间</td>';
            var multiIndexRow = '';
            for (var i = 0; i < timeArr.length; i++) {
                timeRow += '<td>' + timeArr[i] + '</td>';
            }
            timeRow += '</tr>';
            for (var i = 0; i < indexNameArr.length; i++) {
                multiIndexRow += '<tr><td>' + indexNameArr[i] + '</td>';
                for (var k in data) {
                    if (data[k][i] == 0) {
                        multiIndexRow += '<td>' + '</td>';
                    }
                    else {
                        multiIndexRow += '<td>' + data[k][i] + '</td>';
                    }
                }
                multiIndexRow += '</tr>'
            }
            $("#tbResult").html(timeRow + multiIndexRow).addClass('resultTable').show();
        }

        //画柱状图
        function drawBar() {
            var series = new Array();//柱状图或折线图的多指标数据集合，为一个数组
            for (var i = 0; i < indexNameArr.length; i++) {
                var obj = new Object();
                obj.name = indexNameArr[i];
                obj.type = 'bar';
                var objDataArr = new Array();
                for (var k in data) {
                    objDataArr.push(data[k][i]);
                }
                obj.data = objDataArr;
                series.push(obj);
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
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    top: '7%',
                    containLabel: true
                },
                xAxis: {
                    data: timeArr
                },
                yAxis: {},
                series: series
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            $("#chartDiv").show();
        }

        //画折线图
        function drawLine() {
            var series = new Array();//柱状图或折线图的多指标数据集合，为一个数组
            for (var i = 0; i < indexNameArr.length; i++) {
                var obj = new Object();
                obj.name = indexNameArr[i];
                obj.type = 'line';
                var objDataArr = new Array();
                for (var k in data) {
                    objDataArr.push(data[k][i]);
                }
                obj.data = objDataArr;
                series.push(obj);
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
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    top: '7%',
                    containLabel: true
                },
                xAxis: {
                    boundaryGap: false,
                    data: timeArr
                },
                yAxis: {},
                series: series
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            $("#chartDiv").show();
        }

        //饼形图的时间序列下拉框值填充
        function initTimeOption() {
            var html = '<option value="-1">请选择</option>';
            for (var i = timeArr.length - 1; i >= 0; i--) {
                html += '<option value="' + timeArr[i] + '">' + timeArr[i] + '</option>';
            }
            $("#timeOptions").append(html);
        }

        //画饼形图，指定时间点上多个指标的占比
        function drawPie(time) {
            if (time == "-1") return;
            var pieData = new Array();
            for (var i = 0; i < indexNameArr.length; i++) {
                var obj = new Object();
                obj.name = indexNameArr[i];
                obj.value = data[time][i];
                pieData.push(obj);
            }

            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(document.getElementById("echartPie"));

            // 指定图表的配置项和数据
            var option = {
                tooltip: {
                    trigger: 'item',
                    formatter: "{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    left: 'left',
                    data: indexNameArr
                },
                series: [
                    {
                        type: 'pie',
                        radius: '55%',
                        center: ['50%', '60%'],
                        data: pieData
                    }
                ]
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
            $("#chartDiv").show();
        }
    })

</script>
