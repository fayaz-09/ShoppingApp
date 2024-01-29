using ShoppingApp.Services;
using ShoppingApp.View;
namespace ShoppingApp.ViewModel;

public partial class ItemViewModel : BaseViewModel
{
    ShopService shopService;
    public ObservableCollection<Item> Items { get; } = new();

    public ObservableCollection<Item> SaleItems { get; } = new();

    
    public ItemViewModel(ShopService shopService)
    {
        Title = "Shop";
        this.shopService = shopService;
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Item item)
    {
        if(item is null)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Item", item}
            });

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
            var saleItems = await shopService.GetSaleItems();

            if (Items.Count != 0)
            {
                Items.Clear();
                SaleItems.Clear();
            }
            
            foreach (var item in items)
                Items.Add(item);

            foreach (var item in saleItems)
                SaleItems.Add(item);
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

