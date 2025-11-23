using Wild_Atlas.ViewModels;

namespace Wild_Atlas.Views;

public partial class SpeciesCheckForm : ContentPage
{
	public SpeciesCheckForm()
	{
		InitializeComponent();
		BindingContext = new SpeciesCheckFormViewModel();
	}
}