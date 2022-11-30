using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class Maquette : ContentPage
{
	public Maquette()
	{
		InitializeComponent();
        BindingContext = new MaquetteViewModel ();
    }
}