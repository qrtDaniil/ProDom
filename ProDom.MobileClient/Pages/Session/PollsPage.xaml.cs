using ProDom.MobileClient.Pages.Session;

namespace ProDom.MobileClient.Session;

public partial class PollsPage : ContentPage
{

	public PollsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await getPolls();
    }

    public async Task getPolls()
	{

    }

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPollPage());
	}
}