using Mod02Exer02Modified.View;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Networking;
using System.Diagnostics;
using System.Net.Http;

namespace Mod02Exer02Modified
{
    public partial class App : Application
    {
        private const string TestUrl = "https://reqbin.com";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;
            Debug.WriteLine($"Network access: {current}");

            bool isWebsiteReachable = await IsWebsiteReachable("https://reqbin.com");
            Debug.WriteLine($"Is website reachable: {isWebsiteReachable}");

            //var current = Connectivity.NetworkAccess;
            //bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                Debug.WriteLine("Application Started (Online)");
            }
            else
            {
                await Shell.Current.GoToAsync("//OfflinePage");
                Debug.WriteLine("Application Started (Offline)");
            }
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                var response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
