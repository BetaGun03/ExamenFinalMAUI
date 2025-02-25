using ExamenFinal.MVVM.Views;

namespace ExamenFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrincipalView());
        }
    }
}
