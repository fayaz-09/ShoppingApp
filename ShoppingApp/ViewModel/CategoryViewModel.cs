using ShoppingApp.Services;
using ShoppingApp.View;
namespace ShoppingApp.ViewModel;

[QueryProperty("Category", "Category")]
public partial class CategoryViewModel : BaseViewModel
{
    ShopService shopService;

    [ObservableProperty]
    string category;
    public ObservableCollection<Item> CatItems { get; } = new();

    public CategoryViewModel(ShopService shopService)
    {
        Title = "Shop";
        this.shopService = shopService;
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Item item)
    {
        if (item is null)
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
    async Task GoToCartAsync()
    {

        await Shell.Current.GoToAsync($"{nameof(CartPage)}");

    }

    [RelayCommand]
    async Task GoToHomeAsync()
    {

        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");

    }

    [RelayCommand]
    async Task GetCatItems()
    {
        if (IsBusy)
            return;

        try
        {

            IsBusy = true;
            var catItems = await shopService.GetCatItems(category);

            if (CatItems.Count != 0)
            {
                CatItems.Clear();
            }

            foreach (var item in catItems)
                CatItems.Add(item);
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
