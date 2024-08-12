using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using ControleEndereco.Crosscutting.IoC;
using ControleEndereco.Presentation.Components.ViewModels;
using System.Reflection;

namespace ControleEndereco.Presentation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Configuration.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"appsettings.json"), optional: false, reloadOnChange: true);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddScoped<EnderecoViewModel>();

            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.ConfigureContainer(builder.Configuration);

            return builder.Build();
        }
    }
}
