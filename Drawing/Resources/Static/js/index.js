function InitCodeData(listdata) {
    myChart = echarts.init(document.getElementById('main'), 'macarons');
    //alert(listdata.Name);
    option = {
        title: {
            text: '动态折线图'
        },
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'cross',
                label: {
                    backgroundColor: '#6a7985'
                }
            }
        },
        legend: {
            data: ['XX数据'],
        },
        //toolbox: {
        //    feature: {
        //        saveAsImage: {}
        //    }
        //},
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                data: listdata.Name
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                name: 'XX数据',
                type: 'line',
                stack: '测试数据1',
                areaStyle: {},
                data: listdata.Values
            },
        ]
    };
    myChart.setOption(option);
}