using bbbbb.Model;
using bbbbb.ViewModel;

namespace bbbbb.View;

public partial class Exemple : ContentPage
{
	public Exemple()
	{
		InitializeComponent();
		BindingContext = new ExempleViewModel();
	}
}