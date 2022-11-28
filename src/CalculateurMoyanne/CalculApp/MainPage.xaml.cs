namespace CalculApp;

public partial class MainPage : ContentPage
{
	public MainPage(MainPage vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}