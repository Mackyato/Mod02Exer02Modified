using Mod02Exer02Modified.ViewModel;
using Microsoft.Maui.Controls;

namespace Mod02Exer02Modified.View;

public partial class OfflinePage : ContentPage
{
	public OfflinePage()
	{
		InitializeComponent();
	}
    private async void OnRetryButtonClicked(object sender, EventArgs e)
    {
        var current = Connectivity.NetworkAccess;
        bool isWebsiteReachable = await IsWebsiteReachable("https://reqbin.com");

        if (current == NetworkAccess.Internet && isWebsiteReachable)
        {
            await Shell.Current.GoToAsync("//LoginPage"); // Navigate to LoginPage if online
        }
        else
        {
            await DisplayAlert("Connection Error", "Still offline. Please check your internet connection.", "OK");
        }
    }

    // Close button functionality
    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        // Close the application
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    private async Task<bool> IsWebsiteReachable(string url)
    {
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                var response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
        }
        catch
        {
            return false;
        }
    }
}