using ProDom.MobileClient.Constants;
using ProDom.MobileClient.Models;

namespace ProDom.MobileClient.Session;

public partial class NewsPage : ContentPage
{
	public NewsPage()
	{
		InitializeComponent();
	}

	User user;


    protected async override void OnAppearing()
	{
		base.OnAppearing();
		Services.Server ser = new();
		if (await ser.IsHasConnection())
		{
			Services.ServerGets get = new(ser);
			user = get.GetCurrentUserInfo();
		}
		if (user != null)
		{
			lbAdress.Text = user.Adress;
			lbName.Text = user.Name;
		} else
		{
			lbAdress.Text = "ул. Победы, д. 35";
			lbName.Text = "Иван Иванов";
		}

	}

	private async void secure_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SecurityPage());
	}

	private async void requests_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RequestsPage());
	}

	private void ad_Clicked(object sender, EventArgs e)
	{

	}

	private async void polls_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PollsPage());
	}

	private async void chats_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//session/chats/private");
	}

	private async void profile_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//session/profile");
    }
}
