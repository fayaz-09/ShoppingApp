using ShoppingApp.Services;
using ShoppingApp.View;
namespace ShoppingApp.ViewModel;

public partial class CartViewModel : BaseViewModel  
{
    ShopService shopService;

    public ObservableCollection<CartItem> CartItems { get; } = new();
    public CartViewModel(ShopService shopService)
    {
        Title = "Cart";
        this.shopService = shopService;
    }

    [RelayCommand]
    async Task GetCartItemsAsync()
    {
        if (IsBusy)
            return;

        try
        {

            IsBusy = true;
            var cartItems = shopService.GetCartItems();

            if (CartItems.Count != 0)
            {
                CartItems.Clear();
            }

            foreach (var item in cartItems)
                CartItems.Add(item);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", "Unable to get items", "ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
