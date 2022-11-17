namespace ProDom.MobileClient.Session;

public partial class SecurityPage : ContentPage
{
	public SecurityPage()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}