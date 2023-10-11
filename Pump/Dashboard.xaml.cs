using Newtonsoft.Json;
using Plugin.CloudFirestore;

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

            var response = await CrossCloudFirestore.Current
                                     .Instance
                                     .Collection("UserMetaDataModel")
                                     .WhereEqualsTo("Email", userInfo.User.Email)
                                     .GetAsync();

            if (response.Count == 0)
                await Navigation.PushAsync(new FirstAccess());
        }
    }
}