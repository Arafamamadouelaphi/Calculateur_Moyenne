using CalculateurApp.ViewModel;
using CalculateurMapping;
using ClassCalculateurMoyenne;
using Bussness;

namespace CalculateurApp.View;


public partial class BlockView : ContentPage, IQueryAttributable
{
    public Manager Manager => (Application.Current as App).manager;

    public MaquetteViewModel mvm { get; set; }

    public BlockView()
	{
		InitializeComponent();
        mvm = new MaquetteViewModel();
        mvm.manager = Manager;
        //mvm.init1();
        BindingContext = mvm;
    }

    private async void Aer(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new BlockView());
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
    }

    void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        mvm.init1();
    }
}