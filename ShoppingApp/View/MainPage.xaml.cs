namespace ShoppingApp.View;

public partial class MainPage : ContentPage
{
    public MainPage(ItemViewModel itemModel)
    {
        InitializeComponent();
        BindingContext = itemModel;
        itemModel.GetItemsCommand.Execute(this);
    }
}
