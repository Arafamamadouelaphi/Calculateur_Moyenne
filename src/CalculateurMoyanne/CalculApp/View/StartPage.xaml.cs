


using System.Diagnostics;

namespace CalculApp.View;

public partial class StartPage : TabbedPage
{
   

    public StartPage()
	{
		InitializeComponent();
	}

    public async void ok(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        Debug.WriteLine("Answer: " + answer);
    }

}