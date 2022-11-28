﻿using CalculateurApp.View;
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
            builder.Services.AddTransient<Start>();
            builder.Services.AddTransient<BlocViewModel>();
            builder.Services.AddSingleton<UE>();
            builder.Services.AddSingleton<UeViewModel>();
            builder.Services.AddSingleton<Maquette>();
            builder.Services.AddSingleton<MaquetteViewModel>();

            return builder.Build();
        }
    }
}