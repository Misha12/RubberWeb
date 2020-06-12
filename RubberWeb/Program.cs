using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RubberWeb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>();

                    if(args.Length > 0 && int.TryParse(args[0], out int port))
                    {
                        builder.UseUrls($"http://127.0.0.1:{port}");
                    }
                })
                .Build()
                .Run();
        }
    }
}
