using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation);
        }
    }
}