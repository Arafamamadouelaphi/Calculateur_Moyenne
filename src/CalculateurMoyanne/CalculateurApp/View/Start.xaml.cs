
using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class Start : TabbedPage
{
	public Start()
	{
		InitializeComponent();
        BindingContext = new BlocViewModel();
    }
    public async void ok(object sender, EventArgs e)
    {
        //bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        //Debug.WriteLine("Answer: " + answer);
    }
}