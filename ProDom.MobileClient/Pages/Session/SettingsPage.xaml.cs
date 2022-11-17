namespace ProDom.MobileClient.Session;
public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private void btnProfile_Clicked(object sender, EventArgs e)
	{

	}

	private void btnGeneral_Clicked(object sender, EventArgs e)
	{

	}

	private void btnNotif_Clicked(object sender, EventArgs e)
	{

	}

	private void btnSecure_Clicked(object sender, EventArgs e)
	{

	}

	private void btnSupport_Clicked(object sender, EventArgs e)
	{

	}

	private async void btnQuit_Clicked(object sender, EventArgs e)
	{
		Preferences.Default.Set("API", "0");
        Application.Current.Quit();
    }


}