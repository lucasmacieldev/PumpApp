using Newtonsoft.Json;
using Pump.ViewModels;

namespace Pump
{
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            ValidateSession();

            InitializeComponent();
            BindingContext = new PerfilViewModel(Navigation);
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