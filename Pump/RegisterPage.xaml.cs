using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(IConfiguration config)
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation, config);
        }
    }
}