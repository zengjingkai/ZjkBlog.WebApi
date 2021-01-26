using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ZjkBlog.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                    .ConfigureLogging(p =>
                    {
                        var path = System.IO.Directory.GetCurrentDirectory();
                        p.AddLog4Net($"{path}/config/log4net.config");//配置文件
                        p.AddFilter("System", LogLevel.Warning);//过滤命名空间
                        p.AddFilter("Microsoft",LogLevel.Warning);//过滤掉系统默认的一些日志
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
