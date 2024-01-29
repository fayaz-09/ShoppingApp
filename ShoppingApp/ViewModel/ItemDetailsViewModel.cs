namespace ShoppingApp.ViewModel;

[QueryProperty("Item", "Item")]
public partial class ItemDetailsViewModel : BaseViewModel
{
    public ItemDetailsViewModel()
    {

    }

    [ObservableProperty]
    Item item;
}
