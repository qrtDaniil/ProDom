using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ProDom.MobileClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			//.UseSharpnadoTabs(loggerEnable: false)
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<Models.CurrentUser>();
		builder.Services.AddSingleton<Services.Server>();
		//builder.UseSharpnadoTabs(false);



        return builder.Build();
	}
}
