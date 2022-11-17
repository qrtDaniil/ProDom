namespace ProDom.MobileClient.Pages.HelpPages;

public class toHomeShell : ContentPage
{
	public toHomeShell()
	{
		Content = new VerticalStackLayout
		{
			Children = 
			{
				new Image 
				{
                    Source="Images/ChatsPage/background.svg",
					Aspect=Aspect.AspectFill,
					ZIndex=0,
					HeightRequest =10000
                }
            }
		};
        

    }
}