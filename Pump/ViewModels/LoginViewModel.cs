using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pump.Resources;
using System.ComponentModel;

namespace Pump.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        IConfiguration configuration;

        private string userName;
        private string userPassword;
        public event PropertyChangedEventHandler PropertyChanged;
        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }
        public string UserName
        {
            get => userName; set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public LoginViewModel(INavigation navigation, IConfiguration config)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);

            configuration = config;
        }

      
        private bool ValidateForm()
        {
            var listError = new List<string>();
            if (string.IsNullOrEmpty(UserName))
                listError.Add("Email é obrigatório");

            if (string.IsNullOrEmpty(UserPassword))
                listError.Add("Senha é obrigatório");

            if (listError.Any())
            {
                App.Current.MainPage.DisplayAlert("Erros no Formulário!", String.Join(", ", listError), "Ok");
                return false;
            }
            return true;
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            var resultValid = ValidateForm();
            if (resultValid)
            {
                var apiKey = configuration.GetRequiredSection("Settings").Get<Settings>().ApiKey;

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                try
                {
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
                    var content = await auth.GetFreshAuthAsync();
                    var serializedContent = JsonConvert.SerializeObject(content);
                    Preferences.Set("FreshFirebaseToken", serializedContent);
                    await this._navigation.PushAsync(new Dashboard());
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Email ou Senha inválidos", "Ok");
                }
            }
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPage(configuration));
        }
    }
}
