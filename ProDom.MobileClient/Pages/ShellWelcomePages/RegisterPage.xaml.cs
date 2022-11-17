namespace ProDom.MobileClient.Welcome;

using ProDom.MobileClient.Services;
using System.Text.RegularExpressions;

public partial class RegisterPage : ContentPage
{
	Server server;
	public RegisterPage(Server _server = null)
	{
		server = _server;
		InitializeComponent();
	}


	private async void btnRegister_Clicked(object sender, EventArgs e)
	{
        if (!checkFieldsIsFilledCorrectly()) return;
        Models.RegisterProfile profile = new Models.RegisterProfile()
		{
			Name = name.Text,
			Password = password.Text,
			PhoneNumber = number.Text,
			Adress = adress.Text,
			Token = null
		};

		ServerSets ser = new(server);
		if (server.IsHasConnection())
        {
            await DisplayAlert("Ошибка", "Нет соединения с сервером, попробуйте позже", "OK");
			return;
        }
		switch(await ser.SendRegisterProfile(profile))
		{
			case Constants.Server.REGISTER_STATUS_SUCCESS:
				await Navigation.PushAsync(new PhoneVerifyPage(profile));
				break;
			case Constants.Server.REGISTER_STATUS_INCORRECT_IDENTIFICATOR:
				await DisplayAlert("Ошибка", "Лицевой счет введен неверно", "OK");
				break;
            case Constants.Server.REGISTER_STATUS_PHONE_USED:
                await DisplayAlert("Ошибка", "На этот телефон уже зарегистрирован аккаунт", "OK");
                break;
        }
	}

	private bool checkFieldsIsFilledCorrectly()
	{
		if (
			name.Text == null ||
			adress.Text == null ||
			password.Text == null ||	
			number.Text == null ||
			passwordConfirm.Text == null
            )
		{
			error.Text = "Не все поля заполнены";
			error.IsVisible = true;
			return false;
		}

        if (password.Text != passwordConfirm.Text)
        {
            error.Text = "Пароли не совпадают";
            error.IsVisible = true;
            return false;
        }
		return true;
    }

	private void entryFamily_TextChanged(object sender, TextChangedEventArgs e)
	{

    }

	private void entryName_TextChanged(object sender, TextChangedEventArgs e)
	{

    }

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}