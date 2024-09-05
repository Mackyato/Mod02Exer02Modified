using Mod02Exer02Modified.ViewModel;
using Microsoft.Maui.ApplicationModel;


namespace Mod02Exer02Modified.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (username == "admin1" && password == "admin1")
        {
            try
            {
                await Shell.Current.GoToAsync("//EmployeePage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid username or password. The username and password is admin1 admin1", "OK");
        }
    }
}