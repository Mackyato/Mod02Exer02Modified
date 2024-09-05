using Mod02Exer02Modified.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Mod02Exer02Modified.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();

        BindingContext = new EmployeeViewModel();
        CheckConnectivityAndUpdateUI();
    }

    private async void CheckConnectivityAndUpdateUI()
    {
        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            // Navigate to OfflinePage if offline
            await Navigation.PushAsync(new OfflinePage());
        }
    }
}