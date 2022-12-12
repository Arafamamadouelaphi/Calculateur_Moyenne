using CalculateurApp.View;

namespace CalculateurApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BlockView), typeof(BlockView));
        }
    }
}