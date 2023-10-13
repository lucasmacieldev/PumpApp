using Microsoft.Extensions.Configuration;
using Pump.ViewModels;

namespace Pump
{
    public partial class FlyoutSamplePage : FlyoutPage
    {
        public FlyoutSamplePage(IConfiguration config)
        {
            InitializeComponent();

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
    }
}