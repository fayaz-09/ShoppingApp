using ShoppingApp.View;

namespace ShoppingApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));  
        Routing.RegisterRoute(nameof(CatPage), typeof(CatPage));
    }
}
