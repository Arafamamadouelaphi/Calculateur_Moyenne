using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class UEPage1 : ContentPage
{
	public UEPage1()
	{
		InitializeComponent();
		//BindingContext = new UeViewModel();
	}
    private void AddUEBloc(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BlockView());
    }
}