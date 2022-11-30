using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class UEPage1 : ContentPage
{
	public UEPage1()
	{
		InitializeComponent();
		BindingContext = new UeViewModel();
	}
}