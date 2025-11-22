using Wild_Atlas.ViewModels;

namespace Wild_Atlas;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as MainPageViewModel)?.OnPageAppearing();
    }
}

