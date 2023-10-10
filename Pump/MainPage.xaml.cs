using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    public partial class MainPage : ContentPage
    {

        public MainPage(IConfiguration config)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation, config);
        }
    }
}