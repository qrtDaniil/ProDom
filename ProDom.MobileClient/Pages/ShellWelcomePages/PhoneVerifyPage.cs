namespace ProDom.MobileClient.Pages.ShellWelcomePages;

public class PhoneVerifyPage : ContentPage
{
	public PhoneVerifyPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}