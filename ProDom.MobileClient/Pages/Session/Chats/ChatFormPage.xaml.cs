namespace ProDom.MobileClient.Chats;

public partial class ChatFormPage : ContentPage
{
	public ChatFormPage(int userId, bool isEnteranceChat, bool isHouseChat)
	{
		InitializeComponent();

	}

	private async void backbutton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}