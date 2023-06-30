using CarLeds.CarLeds.Views.ImagePopup;
using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.General.Utils
{
    class PopupUtils
    {
        public static async Task DisplayImagePopup(string sourcePath, string text)
        {
            var popup = new ImagePopup(sourcePath, text);

            await Application.Current.MainPage.ShowPopupAsync(popup);
        }
    }
}
