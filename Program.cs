using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using JObjectDemo;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

for (var i = 2; i < 20; ++i)
{
    var splits = RedPackage.SplitRedPackage(100, i);
    foreach (var piece in splits)
    {
        Console.WriteLine(piece);
    }

    Console.WriteLine();
}


string ss = "sfsdfs";
// var objct = JObject.Parse(ss);//Erorr
// Console.WriteLine(objct);

// https://developer.aliyun.com/article/272212  Redis搭建服务 搭建集群 Ops到生产
//Redis语言的基础访问 到高阶框架搭建 等等
var redisConn = ConnectionMultiplexer.Connect("127.0.0.1:8553,connectTimeout=2000");
if (redisConn.IsConnected)
{
    Console.WriteLine("Redis Connn good");
    var db = redisConn.GetDatabase();
    Console.WriteLine(db.StringSet("One", "Haha"));

    db.StringSet("Two", "好的");
}


// string json = @"{"code":200,"message":"OK","data":"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjczMWYwMGFkLWNjZDMtNDdiNC1hNDM0LWMwZTg1OTI0NDIwZSIsImV4cCI6MTY0NjgxNTcxOSwiaXNzIjoiaHR0cHM6Ly93d3cubWdpLXRlY2guY29tLyIsImF1ZCI6Imh0dHBzOi8vd3d3Lm1naS10ZWNoLmNvbS8ifQ.rEaneJd9Kp-wcsdfT_p2QGZHVPhIVI5AeFyaur_-6Qc"}";
//  var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);




