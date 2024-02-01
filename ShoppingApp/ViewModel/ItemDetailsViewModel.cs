using ShoppingApp.Services;
using ShoppingApp.View;
namespace ShoppingApp.ViewModel;

[QueryProperty("Item", "Item")]
public partial class ItemDetailsViewModel : BaseViewModel
{
    ShopService shopService;
    public ObservableCollection<Item> Items { get; } = new();
     
    public ItemDetailsViewModel(ShopService shopService)
    {
        this.shopService = shopService;
    }

    [ObservableProperty]
    Item item;

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
}
