using Wild_Atlas.ViewModels;

namespace Wild_Atlas.Views;

public partial class SpeciesCheckResult : ContentPage
{
	public SpeciesCheckResult()
	{
		InitializeComponent();
        BindingContext = new SpeciesCheckResultViewModel();
    }
}