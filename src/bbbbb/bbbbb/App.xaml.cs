using bbbbb.Model;
using bbbbb.View;

namespace bbbbb;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
