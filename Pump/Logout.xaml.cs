namespace Pump
{
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            Preferences.Set("FreshFirebaseToken", "");
            Microsoft.Maui.Controls.Application.Current!.MainPage = new MenuPage();
            ToMainPage();
            InitializeComponent();
        }

        private async void ToMainPage()
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}