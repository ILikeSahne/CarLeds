﻿using CarLeds.CarLeds.Views.ImagePopup;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace CarLeds.CarLeds.General.Utils
{
    class PopupUtils
    {
        public static async Task DisplayImagePopup(string sourcePath, string text, Page page = null)
        {
            if (page == null)
            {
                page = Application.Current.MainPage;
            }

            var popup = new ImagePopup(sourcePath, text);

            await page.ShowPopupAsync(popup);
        }
    }
}
