using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlastOff.Shared;

namespace BlastOff.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddHttpClient("imageofday", iod =>
            {
                iod.BaseAddress = new Uri("http://localhost:7071" ?? builder.HostEnvironment.BaseAddress);
            });
            builder.Services.AddScoped<IImageService, ImageService>();

            await builder.Build().RunAsync();
        }
    }
}
