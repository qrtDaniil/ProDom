using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.Welcome;

public partial class PhoneVerifyPage : ContentPage
{

	bool editing;
	Models.RegisterProfile profile;
    Models.User res;
	Server server;

	public PhoneVerifyPage(Models.RegisterProfile registerProfile = null, bool phoneEditing = false, Models.User user = null, Server _server = null)
	{
		server = _server;
		res = user;
		editing = phoneEditing;
		profile = registerProfile;
		InitializeComponent();
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void btnRegister_Clicked(object sender, EventArgs e)
	{
		if (!editing)
		{
			Models.RegisterProfile user = new Models.RegisterProfile()
			{
				FullName = profile.FullName,
				Adress = profile.Adress,
				Password = profile.Password,
				PhoneNumber = profile.PhoneNumber,
			};

			ServerSets ser = new(server);
			if (await server.IsHasConnection())
			{
				string code = code1.Text + code2.Text + code3.Text + code4.Text;
				if(code.Length == 4)
				{
					error.IsVisible = false;
					string Response = await ser.SendCode(user, code);

					if(Response == Constants.Server.STATUS_DENIED)
					{
                        error.IsVisible = true;
                    } else
					{
						Preferences.Default.Set("API", Response);
                        await Shell.Current.GoToAsync("//session/NewsPage");
                    }

                } else
				{
                    error.IsVisible = true;
                }
                
            }
			
		} else
		{
			await Navigation.PopAsync();
		}
	}
}