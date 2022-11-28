using Tasker.MVVM.Model;
using Tasker.MVVM.ViewModel;

namespace Tasker.MVVM.View;

public partial class MainView : ContentPage
{
    private MainViewModel mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

	private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
        mainViewModel.UpdateData();

    }
}