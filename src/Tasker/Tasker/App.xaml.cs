using Tasker.MVVM.View;

namespace Tasker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainView();
	}
}
