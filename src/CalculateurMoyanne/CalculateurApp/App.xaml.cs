using CalculateurApp.View;
using CalculateurApp.ViewModel;
using ClassCalculateurMoyenne;
using Bussness;

//using Java.Util.Logging;
using CalculateurMapping;

namespace CalculateurApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new HomePage());
            //MainPage = new AppShell(BlocViewModel c);
           // MainPage = new MatiereView ();



      // MainPage = new AppShell();


             MainPage = new HomePage();


        }
        public Manager manager { get; set; } = new Manager( new MatiereDbDataManager<CalculDbMaui>(), new UeDbDataManager<CalculDbMaui>(), new BlocDbDataManager<CalculDbMaui>(), new MaquetteDbDataManager<CalculDbMaui>())
        {

        };


    }
}