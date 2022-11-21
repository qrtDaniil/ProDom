using System.ComponentModel;
using ProDom.MobileClient.Services;

namespace ProDom.MobileClient;

public partial class AppShell : Shell
{
	Server server;
	public AppShell()
	{
		Routing.RegisterRoute("chats/ChatForm", typeof(Chats.ChatFormPage));
		InitializeComponent();

		if (isAuthorized() || true) CurrentItem = session; 
		else CurrentItem = Authorize;

    }


    private bool isAuthorized()
	{
		return Preferences.Default.Get("API", "0") != "0";
    }
}
