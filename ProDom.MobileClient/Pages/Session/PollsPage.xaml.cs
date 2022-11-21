using ProDom.MobileClient.Pages.Session;

namespace ProDom.MobileClient.Session;

public partial class PollsPage : ContentPage
{

	public PollsPage()
	{
		InitializeComponent();
	}


	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}


}