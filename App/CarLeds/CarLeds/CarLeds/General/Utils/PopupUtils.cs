using CarLeds.CarLeds.Views.ImagePopup;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.General.Utils
{
    class PopupUtils
    {
        public static async Task DisplayImagePopup(string text)
        {
            var popup = new ImagePopup(text);

            await Application.Current.MainPage.ShowPopupAsync(popup);
        }
    }
}
