using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.Views.ImagePopup;

public partial class ImagePopup : Popup
{
    public ImagePopup(string sourcePath, string text)
    {
        InitializeComponent();

        var vm = (ImagePopupVm)BindingContext;

        vm.Source = sourcePath;
        vm.Text = text;

        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        PopupBorder.WidthRequest = displayInfo.Width / displayInfo.Density - 32;
    }

    private void OkButtonClicked(object sender, EventArgs e)
    {
        Close();
    }
}