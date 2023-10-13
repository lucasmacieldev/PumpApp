using Newtonsoft.Json;
using Plugin.CloudFirestore;
using Pump.ViewModels;

namespace Pump
{
    public partial class Dashboard : FlyoutPage
    {
        public Dashboard()
        {
            InitializeComponent();
            //GetProfileInfo();
            flyoutPage.collectionViewFlyout.SelectionChanged += OnSelectionChanged;

        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
            if (item != null)
            {

                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;

                //switch (item.Title)
                //{
                //    case "Dashboard":
                //        Detail = new NavigationPage(new Dashboard());

                //        break;

                //}
            }
        }

        //private async void GetProfileInfo()
        //{
        //    var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        //    UserEmail.Text = userInfo.User.Email;

        //    var response = await CrossCloudFirestore.Current
        //                             .Instance
        //                             .Collection("UserMetaDataModel")
        //                             .WhereEqualsTo("Email", userInfo.User.Email)
        //                             .GetAsync();

        //    if (response.Count == 0)
        //        await Navigation.PushAsync(new FirstAccess());
        //}
    }
}