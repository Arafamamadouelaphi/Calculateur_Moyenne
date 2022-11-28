using proo.ViewModel;

namespace proo;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}