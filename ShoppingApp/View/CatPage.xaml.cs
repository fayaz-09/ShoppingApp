namespace ShoppingApp.View;

public partial class CatPage : ContentPage
{
	public CatPage(CategoryViewModel catModel)
    {
        InitializeComponent();
        BindingContext = catModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as CategoryViewModel).GetCatItemsCommand.Execute(this);
    }
}