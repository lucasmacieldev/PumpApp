using Newtonsoft.Json;
using Plugin.CloudFirestore;
namespace Pump
{
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
            if (userInfo == null)
                await Navigation.PushAsync(new MainPage());
            else
            {
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
}