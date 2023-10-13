using Newtonsoft.Json;
using Pump.ViewModels;

namespace Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstAccess : ContentPage
    {
        public FirstAccess()
        {
            ValidateSession();

            InitializeComponent();
            BindingContext = new FirstAcessViewModel(Navigation);
        }

        private async void ValidateSession()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));

            if (userInfo == null)
                await Navigation.PushAsync(new MainPage());
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                labelname.Text = picker.Items[selectedIndex];
            }
        }
    }
}