

using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.Pages.Session;

public partial class AddPollPage : ContentPage
{
    Server Server { get; set; }

    public AddPollPage(Server _server = null)
	{
        Server = _server;
        List<string> days = new List<string>();
        for(int i = 5; i < 11; i++) days.Add($"{i} дней");
        InitializeComponent();
        pollDateStart.MinimumDate = DateTime.Now;
        pollTimeActive.ItemsSource = days;

	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnCreate_Clicked(object sender, EventArgs e)
    {
        
        var poll = new Models.Poll() {
            name = pollName.Text,
            dateStart = pollDateStart.Date,
            timeConducting = TimeSpan.FromDays(pollTimeActive.SelectedIndex+6),
            description = pollDescription.Text 
        };

        ServerSets server = new(Server);

        if (Server.IsHasConnection())
        {
            await server.AddPoll(poll);
        }

        await Navigation.PopAsync();
    }
}