using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HotChocolateAuthTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Build().Run();
        }
        public static IWebHostBuilder BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

    }
}