namespace ShoppingApp.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(ItemDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}