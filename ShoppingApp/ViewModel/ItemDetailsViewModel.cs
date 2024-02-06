using ShoppingApp.Services;
using ShoppingApp.View;
namespace ShoppingApp.ViewModel;

[QueryProperty("Item", "Item")]
public partial class ItemDetailsViewModel : BaseViewModel
{
    ShopService shopService;
    int Quantity;
    public ObservableCollection<Item> Items { get; } = new();
     
    public ItemDetailsViewModel(ShopService shopService)
    {
        this.shopService = shopService;
        Quantity = 0;
    }

    [ObservableProperty]
    Item item;

    [RelayCommand]
    async Task GoToHomeAsync()
    {

        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");

    }

    [RelayCommand]
    async Task GoToCartAsync()
    {

        await Shell.Current.GoToAsync($"{nameof(CartPage)}");

    }

    [RelayCommand]
    async Task GetItemsAsync()
    {
        if (IsBusy)
            return;

        try
        {

            IsBusy = true;
            var items = await shopService.GetItems();

            if (Items.Count != 0)
            {
                Items.Clear();
            }

            foreach (var item in items)
                Items.Add(item);

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

    [RelayCommand]
    private void addToBasket(Item item)
    {
        if (IsBusy)
            return;

        try
        {

            IsBusy = true;
            if (Quantity > 0)
            {
                shopService.AddToCart(item, Quantity);
            }
            else
                shopService.AddToCart(item, 1);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            Shell.Current.DisplayAlert("Error!", "Unable to get items", "ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void changeQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
