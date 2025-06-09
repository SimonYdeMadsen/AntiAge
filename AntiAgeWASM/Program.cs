using AntiAgeWASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;
namespace AntiAgeWASM;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddBlazorBootstrap();

        builder.Services.AddSingleton<HttpClient>(client =>
        {
            return new HttpClient { BaseAddress = new Uri("https://localhost:7230/") };
        });


        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<AuthService>();



        await builder.Build().RunAsync();



    }
}
