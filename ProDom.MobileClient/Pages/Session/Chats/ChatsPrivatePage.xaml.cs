using ProDom.MobileClient.Models;

namespace ProDom.MobileClient.Chats;

public partial class ChatsPrivatePage : ContentPage
{
    public ChatsPrivatePage()
	{    
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void layoutSettings(IList<Models.Message> users)
    {
        if (users == null)
        {
            layNoMessages.IsVisible = true;
            layMessages.IsVisible = false;
        }
        else
        {
            BindingContext = users;
            layMessages.IsVisible = true;
            layNoMessages.IsVisible = false;
        }
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ViewCell_Tapped(object sender, EventArgs e)
    {
        var cell = sender as ViewCell;
    }

    private async void layMessages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Message messageForAllChat = e.SelectedItem as Message;
        await Navigation.PushAsync(new ChatFormPage(userId: messageForAllChat.userId, isEnteranceChat: false, isHouseChat: false));
    }
}