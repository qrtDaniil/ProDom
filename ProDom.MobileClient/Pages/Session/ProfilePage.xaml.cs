namespace ProDom.MobileClient.Session;

public partial class ProfilePage : ContentPage
{
	bool is_editing = false;

	Models.User user;

    public ProfilePage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        Services.Server ser = new();
        if (await ser.IsHasConnection())
        {
            Services.ServerGets get = new(ser);
            user = get.GetCurrentUserInfo();
        }
        if(user!= null)
        {
            lbName.Text = user.Name;
            lbAdress.Text = user.Adress;
        }
        else
        {
            lbAdress.Text = "ул. Победы, д. 35";
            lbName.Text = "Иван Иванов";
        }


    }

    private async void Edit_Clicked(object sender, EventArgs e)
	{
		is_editing = !is_editing;
		if (is_editing)
		{
			btnEdit.Text = "Сохранить";
			phone.IsEnabled = true;
		} else
		{
            btnEdit.Text = "Редактировать профиль";
            phone.IsEnabled = false;
		}
	}
}