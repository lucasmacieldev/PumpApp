using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(IConfiguration config)
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation, config);
        }
    }
}