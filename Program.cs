using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string ss = "sfsdfs";
// var objct = JObject.Parse(ss);//Erorr
// Console.WriteLine(objct);

// https://developer.aliyun.com/article/272212  Redis搭建服务 搭建集群 Ops到生产
//Redis语言的基础访问 到高阶框架搭建 等等
var redisConn = ConnectionMultiplexer.Connect("127.0.0.1:8553,connectTimeout=2000");
if(redisConn.IsConnected)
{
    Console.WriteLine("Redis Connn good");
    var db = redisConn.GetDatabase();
    Console.WriteLine(db.StringSet("One", "Haha"));

    db.StringSet("Two", "好的");
}




