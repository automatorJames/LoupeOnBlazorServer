using Loupe.Agent.Core.Services;
using Loupe.Agent.AspNetCore;
using Loupe.Extensions.Logging;

namespace LoupeOnBlazorServer;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddHttpContextAccessor();

        builder.Host.AddLoupe().AddLoupeLogging();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        
        app.UseLoupeCookies();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}