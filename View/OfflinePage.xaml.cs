using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Module02Exercise01.View
{
    public partial class OfflinePage : ContentPage
    {
        public OfflinePage()
        {
            InitializeComponent();
        }

        private async void OnRetryClicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            var app = (App)Application.Current;

            bool isWebsiteReachable = await app.IsWebsiteReachable(App.TestUrl);

            if (current == NetworkAccess.Internet)
            {
                await DisplayAlert("You're connection is back", "Redirecting to Login Page", "Ok");
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await DisplayAlert("You're still offline", "Check your connection and try again.", "OK");
            }
        }

        private async void OnCloseAppClicked(object sender, EventArgs e)
        {
            bool shouldClose = await DisplayAlert("Close this app?", "Are you sure you want to close?", "CLOSE", "STAY");

            if (shouldClose)
            {
                Application.Current.Quit();
            }
        }
    }
}
