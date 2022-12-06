using CalculateurApp.View;
using CalculateurApp.ViewModel;
using ClassCalculateurMoyenne;

namespace CalculateurApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
            //MainPage = new AppShell(BlocViewModel c);
          //    MainPage = new Maquette ();
       //  MainPage = new Start();
           
        }
    }
}