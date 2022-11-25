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

		ServerSets ser = new(server);
		if (await server.IsHasConnection())
        {
            await DisplayAlert("������", "��� ���������� � ��������, ���������� �����", "OK");
			return;
        }

		await ser.RegisterUserAsync(
				fullName: name.Text,
				phoneNumber: number.Text,
				password: password.Text
			);

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
			error.Text = "�� ��� ���� ���������";
			error.IsVisible = true;
			return false;
		}

        if (password.Text != passwordConfirm.Text)
        {
            error.Text = "������ �� ���������";
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