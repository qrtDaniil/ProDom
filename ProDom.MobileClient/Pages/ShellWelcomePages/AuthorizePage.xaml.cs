using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.Welcome;

public partial class AuthorizePage : ContentPage
{
	Server server;
	public AuthorizePage(Server server)
	{
		this.server = server;
		InitializeComponent();
	}

	private void btnForgotPassword_Clicked(object sender, EventArgs e)
	{

	}

	private async void btnAuthorize_Clicked(object sender, EventArgs e)
	{
		if (server.IsHasConnection())
		{
			ServerGets ser = new(server);
			string result = ser.GetAPI(number.Text, password.Text);

			if (result == Constants.Server.STATUS_DENIED)
			{
				error.IsVisible = true;
			}
			else
			{
				Preferences.Default.Set("API", result);
				await Shell.Current.GoToAsync("//session/NewsPage");
			}
		}
		else
		{
			await DisplayAlert("Ошибка", "Соединение с сервером не установлено", "ОК");
		}
	}

	private async void btnRegister_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}
}