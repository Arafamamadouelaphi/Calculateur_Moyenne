namespace proo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		///creation de route pour passer d 'une page a une autre
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	}
}
