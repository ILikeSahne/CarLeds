using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.General.Utils
{
    class PopupUtils
    {
        public static async Task DisplayText(string text)
        {
            var popup = new Popup
            {
                Content = new Label { Text = text }
            };

            await Application.Current.MainPage.ShowPopupAsync(popup);
        }

        public static async Task Alert(string title, string text)
        {
            await Application.Current.MainPage.DisplayAlert(title, text, "");
        }
    }
}
