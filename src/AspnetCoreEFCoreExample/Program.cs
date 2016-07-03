using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AspnetCoreEFCoreExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = HostingAbstractionsWebHostBuilderExtensions.UseContentRoot(WebHostBuilderKestrelExtensions.UseKestrel(new WebHostBuilder()), Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            WebHostExtensions.Run(host);
        }
    }
}
