using Wild_Atlas.ViewModels;

namespace Wild_Atlas.Views;

public partial class SpeciesCheckResult : ContentPage
{
    private readonly SpeciesCheckResultViewModel _viewModel;

    public SpeciesCheckResult()
    {
        InitializeComponent();

        _viewModel = new SpeciesCheckResultViewModel();
        BindingContext = _viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnPageAppearing();
    }
}