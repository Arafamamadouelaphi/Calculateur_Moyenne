namespace CalculateurApp.View;

public partial class HomePage : TabbedPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Start());

    }
}