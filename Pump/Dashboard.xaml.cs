using Newtonsoft.Json;
using Pump.Application.Models;
using Pump.Application.Services;

namespace Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            GetProfileInfo();
        }

        private async void GetProfileInfo()
        {

            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
            UserEmail.Text = userInfo.User.Email;

            var user = new UserInfosModel 
            { 
                Altura = "172",
                Peso = "76",
                UID = "12314"
            };


            //var xpto = await UserService.GetUserAsync(user);

        }
    }
}