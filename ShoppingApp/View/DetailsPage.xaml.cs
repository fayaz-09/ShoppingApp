namespace ShoppingApp.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(ItemDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetItemsCommand.Execute(this);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int index = picker.SelectedIndex;

        if (index != -1)
        {
            (BindingContext as ItemDetailsViewModel).changeQuantity((int)picker.ItemsSource[index]);
        }
    }
}