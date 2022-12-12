using CalculateurApp.ViewModel;
using CalculateurMapping;
using ClassCalculateurMoyenne;
using Bussness;

namespace CalculateurApp.View;


public partial class BlockView : ContentPage
{
    
	public BlockView()
	{
		InitializeComponent();
        BindingContext = new MaquetteViewModel ();
    }
    private async void Aer(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new BlockView());
    }
}