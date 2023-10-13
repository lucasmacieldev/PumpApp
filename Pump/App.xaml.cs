namespace Pump
{
    public partial class App 
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MenuPage();
        }

        protected override void OnStart()
        {
            UserAppTheme = AppTheme.Light;
            base.OnStart();
        }

        public record City(string Name, double Population);
    }
}