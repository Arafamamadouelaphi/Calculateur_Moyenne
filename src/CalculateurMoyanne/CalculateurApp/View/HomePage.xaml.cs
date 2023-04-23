using System.Diagnostics;

namespace CalculateurApp.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		

			Navigation.PushAsync(new AjtMaquette(new ViewModel.PageAjoutMaquette()));
       

    }
}