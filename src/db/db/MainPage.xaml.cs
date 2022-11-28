using db.ViewModel;

namespace db;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}

	
}

