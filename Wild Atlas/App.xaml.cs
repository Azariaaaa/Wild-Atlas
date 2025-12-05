using Wild_Atlas.Views;

namespace Wild_Atlas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Routing.RegisterRoute(nameof(SpeciesCheckForm), typeof(SpeciesCheckForm));
        Routing.RegisterRoute(nameof(SpeciesCheckResult), typeof(SpeciesCheckResult));
    }
}
