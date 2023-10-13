using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}