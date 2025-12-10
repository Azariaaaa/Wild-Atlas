using Wild_Atlas.ViewModels;

namespace Wild_Atlas.Views;

public partial class SpeciesCheckResult : ContentPage
{
    private readonly SpeciesCheckResultViewModel _viewModel;
	public SpeciesCheckResult(SpeciesCheckResultViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnPageAppearing();
    }
}