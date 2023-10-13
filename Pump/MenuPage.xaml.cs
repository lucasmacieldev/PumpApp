using Newtonsoft.Json;

namespace Pump
{
	public partial class MenuPage : Shell
	{
		public MenuPage()
		{
			InitializeComponent();
            Routing.RegisterRoute(nameof(Logout), typeof(Logout));
        }
    }
}