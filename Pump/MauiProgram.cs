using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Pump
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
               .UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("material_icon_regulara.ttf", "MaterialIcon");
               });

            builder.Services.AddTransient<MainPage>();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Pump.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();


            builder.Configuration.AddConfiguration(config);

            var app = builder.Build();

            Services = app.Services;
            return app;
        }

        public static IServiceProvider Services { get; private set; }
    }
}