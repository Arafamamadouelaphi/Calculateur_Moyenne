using Appcalculateur.View;

namespace Appcalculateur
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Tabbed());
        }
    }
}