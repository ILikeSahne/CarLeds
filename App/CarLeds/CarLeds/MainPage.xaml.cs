using CarLeds.CarLeds.General.Utils;
using CarLeds.CarLeds.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace CarLeds;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void DebugButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DebugPage());
    }
}

