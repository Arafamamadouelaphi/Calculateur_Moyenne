using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class AjtMaquette : ContentPage
{
	public AjtMaquette(PageAjoutMaquette vm)
	{
		InitializeComponent();
		BindingContext = vm;
		Routing.RegisterRoute(nameof(BlockView), typeof(BlockView));
    }
}
