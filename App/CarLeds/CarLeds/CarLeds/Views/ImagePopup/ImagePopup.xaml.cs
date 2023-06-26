using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.Views.ImagePopup;

public partial class ImagePopup : Popup
{
	public ImagePopup(string text)
	{
		InitializeComponent();

		var vm = (ImagePopupVm)BindingContext;

		vm.Text = text;
	}
}