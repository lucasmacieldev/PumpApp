using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Pump.Resources;
using System.ComponentModel;

namespace Pump.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        IConfiguration configuration;
        private INavigation _navigation;
        private string email;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public Command BackBtn { get; }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Command RegisterUser { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation, IConfiguration config)
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
            BackBtn = new Command(BackBtnTappedAsync);
            
            configuration = config;
        }
        private bool ValidateForm()
        {
            var listError = new List<string>();
            if (string.IsNullOrEmpty(Email))
                listError.Add("Email é obrigatório");

            if (string.IsNullOrEmpty(Password))
                listError.Add("Senha é obrigatório");

            if (listError.Any())
            {
                App.Current.MainPage.DisplayAlert("Erros no Formulário!", String.Join(", ", listError), "Ok");
                return false;
            }
            return true;
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            var resultValid = ValidateForm();
            if (resultValid)
            {
                try
                {
                    var apiKey = configuration.GetRequiredSection("Settings").Get<Settings>().ApiKey;
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                    string token = auth.FirebaseToken;
                    if (token != null)
                        await App.Current.MainPage.DisplayAlert("Alert", "Usuário cadastrado com Sucesso!", "OK");
                    
                    await this._navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }

        private async void BackBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new MainPage(configuration));
        }
    }
}
