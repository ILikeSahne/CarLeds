using CarLeds.CarLeds.General.Utils;

namespace CarLeds.CarLeds.Views;

public partial class DebugPage : ContentPage
{
	public DebugPage()
	{
		InitializeComponent();
	}

    private async void TestPopupButtonClicked(object sender, EventArgs e)
    {
        await PopupUtils.DisplayImagePopup("icon_bluetooth.png", "Please accept the permissions next time!\nIf they don't open again, you have to manually add them in the settings!", this);
    }
}