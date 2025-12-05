using CommunityToolkit.Mvvm.Input;
using Wild_Atlas.ViewModels;
using Wild_Atlas.Views;

namespace Wild_Atlas;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnPageAppearing();
    }

    private void OnButton2Tapped(object sender, TappedEventArgs e)
    {
        // ...
    }

    private void OnButton3Tapped(object sender, TappedEventArgs e)
    {
        // ...
    }
    private void OnButton4Tapped(object sender, TappedEventArgs e)
    {
        // ...
    }
}

