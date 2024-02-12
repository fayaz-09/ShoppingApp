using Microsoft.Extensions.Logging;
using ShoppingApp.Services;
using ShoppingApp.View;

namespace ShoppingApp;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ShopService>();

        builder.Services.AddSingleton<ItemViewModel>();
        builder.Services.AddTransient<ItemDetailsViewModel>();
        builder.Services.AddSingleton<CartViewModel>();
        builder.Services.AddTransient<CategoryViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddSingleton<ItemsPage>();
        builder.Services.AddSingleton<CartPage>();
        builder.Services.AddTransient<CatPage>();

        return builder.Build();
    }
}
