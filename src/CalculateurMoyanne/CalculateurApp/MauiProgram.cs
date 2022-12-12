using CalculateurApp.View;
using CalculateurApp.ViewModel;

namespace CalculateurApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
           

           // builder.Services.AddSingleton<UEPage1>();
           // builder.Services.AddSingleton<UeViewModel>();

            builder.Services.AddSingleton<BlockView>();
            builder.Services.AddSingleton<MaquetteViewModel>();
            builder.Services.AddSingleton<AjtMaquette>();
            builder.Services.AddSingleton<PageAjoutMaquette>();
            builder.Services.AddTransient<Start>();
            builder.Services.AddTransient<BlocViewModel>();

            return builder.Build();
        }
    }
}