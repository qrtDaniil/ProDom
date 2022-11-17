using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.Welcome;

public partial class PhoneVerifyPage : ContentPage
{

	bool editing;
	Models.RegisterProfile profile;
    Models.Tables.Users res;
	Server server;

	public PhoneVerifyPage(Models.RegisterProfile registerProfile = null, bool phoneEditing = false, Models.Tables.Users user = null, Server _server = null)
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
		Database.SmartYardDB db = new Database.SmartYardDB();
		if (!editing)
		{
			Models.Tables.Users user = new Models.Tables.Users()
			{
				Name = profile.Name,
				Adress = profile.Adress,
				Password = profile.Password,
				Phone = profile.PhoneNumber,
			};

			ServerSets ser = new(server);
			if (server.IsHasConnection())
			{
                await ser.SendCode(user);
            }
			
			Preferences.Default.Set("isAuthorized", true);
			await Shell.Current.GoToAsync("//session/NewsPage");
		} else
		{
			//await db.UpdateUser(res);
			//await Navigation.PopAsync();
		}
	}
}