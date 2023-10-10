using Microsoft.Extensions.Configuration;

namespace Pump
{
    public partial class App 
    {
        public App(IConfiguration config)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(config));
        }
    }
}