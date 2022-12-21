using CalculateurApp.ViewModel;
namespace CalculateurApp.View;
using Bussness;

public partial class MatiereView : ContentPage
{
    public Manager Manager => (Application.Current as App).manager;
    public UeViewModel mvm { get; set; }

    public MatiereView()
	{
		InitializeComponent();
        mvm = new UeViewModel();
        mvm.manager = Manager;
     mvm.init1();
        BindingContext = mvm;
    }

    void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        //mvm.init1();
    }
    //private async void pop(object sender, EventArgs e)
    //{
    //    string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
    //}
}
