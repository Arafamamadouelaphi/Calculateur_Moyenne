using CalculApp.View;
using CalculApp.View;



namespace CalculApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new StartPage ());
            MainPage = new AppShell();
        }
    }
}