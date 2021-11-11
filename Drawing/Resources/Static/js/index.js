const baseUrl="http://srv.jmeip.com"
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


(async ()=>{
    await CefSharp.BindObjectAsync("dotNetMessage");
})();

const ShowDotNetMessage=()=>{
    let message = document.getElementById('textbox').value;
    // alert(message);
    dotNetMessage.show(message);
}

const Login=async ()=>{
    //登录接口
    let body={
        UserName:"yndzys",
        Password:"123456"
    }
    let loginInfo=await query(baseUrl+"/Api/Login","POST",body);
    console.log(loginInfo);
    alert(JSON.stringify(loginInfo));
}

const query=(url,type,body={})=>{
    return new Promise((reject,_)=>{
        let response=null;
        response=type==='GET'?fetch(url):fetch(url,{
            method:"POST",
            body:JSON.stringify(body),
            headers: { 'Content-Type': 'application/json',
            "apiTicket":"141UIiI586557d84ec8a4ncl517doa184al1md481b7n6opml95p80dl45cm8n4daman8bbqmc8a5d8nqpa4l704",
            "ApiClient":`{m}8162{p}5162{g}0220399e-fe16-4de1-80e6-4128cee64427`
             }
        });
        response.then(res=>{
            return res.json();
        }).then(res=>{
            reject(res);
        })
        .catch(err=>{
            message.warning("请求出错："+err.message);
        })
    })
}

const CallBack=async ()=>{
     let url=document.getElementById("txtUrl").value;
     let type=document.getElementById("selectType").value;
     
     let body={
         page:1,
         pSize:50,
         prjID:10263,
         pSort:"dataTime DESC",
         pExp:"stateID<=3"
     }
     let weather=await query(url,type,body);
     alert(JSON.stringify(weather));
}

const Request=async ()=>{
    let url=baseUrl+document.getElementById("txtSensor").value;
    let bodystr=document.getElementById("body").value;
    let body=bodystr==null||bodystr==""?{}:JSON.parse(bodystr);

    let response=await query(url,"POST",body);
    let element=document.getElementById("wrapper");
    element.innerHTML=JSON.stringify(response,null,"\t");
}

// var Snowflake = /** @class */ (function() {
// 	function Snowflake(_workerId, _dataCenterId, _sequence) {
// 		this.twepoch = 1288834974657n;
// 		//this.twepoch = 0n;
// 		this.workerIdBits = 5n;
// 		this.dataCenterIdBits = 5n;
// 		this.maxWrokerId = -1n ^ (-1n << this.workerIdBits); // 值为：31
// 		this.maxDataCenterId = -1n ^ (-1n << this.dataCenterIdBits); // 值为：31
// 		this.sequenceBits = 12n;
// 		this.workerIdShift = this.sequenceBits; // 值为：12
// 		this.dataCenterIdShift = this.sequenceBits + this.workerIdBits; // 值为：17
// 		this.timestampLeftShift = this.sequenceBits + this.workerIdBits + this.dataCenterIdBits; // 值为：22
// 		this.sequenceMask = -1n ^ (-1n << this.sequenceBits); // 值为：4095
// 		this.lastTimestamp = -1n;
// 		//设置默认值,从环境变量取
// 		this.workerId = 1n;
// 		this.dataCenterId = 1n;
// 		this.sequence = 0n;
// 		if(this.workerId > this.maxWrokerId || this.workerId < 0) {
// 			throw new Error('_workerId must max than 0 and small than maxWrokerId-[' + this.maxWrokerId + ']');
// 		}
// 		if(this.dataCenterId > this.maxDataCenterId || this.dataCenterId < 0) {
// 			throw new Error('_dataCenterId must max than 0 and small than maxDataCenterId-[' + this.maxDataCenterId + ']');
// 		}

// 		this.workerId = BigInt(_workerId);
// 		this.dataCenterId = BigInt(_dataCenterId);
// 		this.sequence = BigInt(_sequence);
// 	}
// 	Snowflake.prototype.tilNextMillis = function(lastTimestamp) {
// 		var timestamp = this.timeGen();
// 		while(timestamp <= lastTimestamp) {
// 			timestamp = this.timeGen();
// 		}
// 		return BigInt(timestamp);
// 	};
// 	Snowflake.prototype.timeGen = function() {
// 		return BigInt(Date.now());
// 	};
// 	Snowflake.prototype.nextId = function() {
// 		var timestamp = this.timeGen();
// 		if(timestamp < this.lastTimestamp) {
// 			thrownew Error('Clock moved backwards. Refusing to generate id for ' +
// 				(this.lastTimestamp - timestamp));
// 		}
// 		if(this.lastTimestamp === timestamp) {
// 			this.sequence = (this.sequence + 1n) & this.sequenceMask;
// 			if(this.sequence === 0n) {
// 				timestamp = this.tilNextMillis(this.lastTimestamp);
// 			}
// 		} else {
// 			this.sequence = 0n;
// 		}
// 		this.lastTimestamp = timestamp;
// 		return((timestamp - this.twepoch) << this.timestampLeftShift) |
// 			(this.dataCenterId << this.dataCenterIdShift) |
// 			(this.workerId << this.workerIdShift) |
// 			this.sequence;
// 	};
// 	return Snowflake;
// }());

const productGUID=()=>{
    let guid=Snowflake(1n, 1n, 0n).nextId();
    console.log(guid);
}