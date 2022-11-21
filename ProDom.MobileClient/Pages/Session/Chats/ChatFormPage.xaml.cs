namespace ProDom.MobileClient.Chats;

public partial class ChatFormPage : ContentPage
{
	public ChatFormPage() 
	{
		InitializeComponent();

	}


	private async void backbutton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}