
using Bussness;
using CalculateurApp.ViewModel;

namespace CalculateurApp.View;

public partial class UeView : ContentPage
{
    public Manager Manager => (Application.Current as App).manager;
    public BlocViewModel mv { get; set; }
    public UeView()
    {
        InitializeComponent();
        mv = new BlocViewModel();
        mv.manager = Manager;
        BindingContext = mv;
        mv.init1();

    }

   
    void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        mv.init1();
    }

    void ContentPage_Loaded_1(System.Object sender, System.EventArgs e)
    {
    }

    void ContentPage_Loaded_2(System.Object sender, System.EventArgs e)
    {
    }
}
