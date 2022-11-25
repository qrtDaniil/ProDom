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
            lbAdress.Text = "��. ������, �. 35";
            lbName.Text = "���� ������";
        }


    }

    private async void Edit_Clicked(object sender, EventArgs e)
	{
		is_editing = !is_editing;
		if (is_editing)
		{
			btnEdit.Text = "���������";
			phone.IsEnabled = true;
		} else
		{
            btnEdit.Text = "������������� �������";
            phone.IsEnabled = false;
		}
	}
}