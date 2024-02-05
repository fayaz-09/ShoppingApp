namespace ShoppingApp.View;

public partial class ItemsPage : ContentPage
{
	public ItemsPage (ItemViewModel itemModel)
    {
        InitializeComponent();
        BindingContext = itemModel;
        itemModel.GetItemsCommand.Execute(this);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}