using CalculateurApp.ViewModel;
using Bussness;
using ClassCalculateurMoyenne;

namespace CalculateurApp.View;

public partial class AjtMaquette : ContentPage
{
	public Manager Manager => (Application.Current as App).manager;

	public AjtMaquette(PageAjoutMaquette vm)
	{
		vm.manager = Manager;
		vm.Init();
		InitializeComponent();
		BindingContext = vm;
		Routing.RegisterRoute(nameof(BlockView), typeof(BlockView));
    }
}
