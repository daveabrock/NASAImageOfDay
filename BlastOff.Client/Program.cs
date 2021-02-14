using BlastOff.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Blazored.Modal;
using MudBlazor.Services;

namespace BlastOff.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddHttpClient("imageofday", iod =>
            {
                iod.BaseAddress = new Uri("http://localhost:7071" ?? builder.HostEnvironment.BaseAddress);
            });
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddMudServices();
            builder.Services.AddMudBlazorDialog();

            await builder.Build().RunAsync();
        }
    }
}