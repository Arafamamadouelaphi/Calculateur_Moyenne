using CalculateurApp.ViewModel;
using CalculateurMapping;
using ClassCalculateurMoyenne;
using Bussness;

namespace CalculateurApp.View;


public partial class BlockView : ContentPage
{
    public Manager Manager => (Application.Current as App).manager;


    public BlockView()
	{
		InitializeComponent();
        var mvm = new MaquetteViewModel();
        mvm.manager = Manager;
        mvm.init1();
        BindingContext = mvm;
    }
    private async void Aer(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new BlockView());
    }
}