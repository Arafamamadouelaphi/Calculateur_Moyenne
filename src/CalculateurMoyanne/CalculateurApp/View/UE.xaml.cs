using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class UE : ContentPage
{
    
    public UE(UeViewModel u)
	{
		InitializeComponent();
		BindingContext = u;
	}
}