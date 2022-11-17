namespace ProDom.MobileClient.Session;

public partial class RequestsPage : ContentPage
{
	public RequestsPage()
	{
		InitializeComponent();
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}