namespace ShoppingApp.View;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel cartModel)
	{
		InitializeComponent();
        BindingContext = cartModel;
        cartModel.GetCartItemsCommand.Execute(this);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as CartViewModel).GetCartItemsCommand.Execute(this);
    }

}