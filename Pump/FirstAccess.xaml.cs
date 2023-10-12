using Pump.ViewModels;

namespace Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstAccess : ContentPage
    {

        public FirstAccess()
        {
            InitializeComponent();
            BindingContext = new FirstAcessViewModel(Navigation);
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