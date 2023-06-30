#if WINDOWS
#define TESTING
#endif
namespace CarLeds;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
		Application.Current.UserAppTheme = AppTheme.Dark;

		MainPage = new NavigationPage(new MainPage());
	}
}
