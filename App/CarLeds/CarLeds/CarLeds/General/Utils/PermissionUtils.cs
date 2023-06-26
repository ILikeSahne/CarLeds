namespace CarLeds.CarLeds.General.Utils;

using CommunityToolkit.Maui.Views;

#if ANDROID
    using Android.Content;
    using Android.Locations;
#elif IOS || MACCATALYST
using CoreLocation;
#elif WINDOWS
    using Windows.Devices.Geolocation;
#endif

public class PermissionUtils
{
    public static async Task CheckBluetoothPermissions()
    {
        var bluetoothStatus = await CheckBluetoothPermissionsAndroid();
        var locationServices = IsLocationServiceEnabled();

        if (IsGranted(bluetoothStatus) && locationServices)
            return;

        await PopupUtils.DisplayText("This app needs access to Bluetooth to find nearby CarLed devices.\nPlease accept the corresponding permissions!");

        bluetoothStatus = await CheckBluetoothPermissionsAndroid(true);
        locationServices = IsLocationServiceEnabled();

        if (IsGranted(bluetoothStatus) && locationServices)
            return;

        await PopupUtils.Alert("Bluetooth Permissions weren't accepted", "Please accept the permissions next time!\nIf they don't open again, manually add them in the settings!");
        Application.Current.Quit();
    }

    private static async Task<PermissionStatus> CheckBluetoothPermissionsAndroid(bool request = false)
    {
        var bluetoothStatus = PermissionStatus.Granted;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            if (DeviceInfo.Version.Major >= 12)
            {
                bluetoothStatus = await CheckPermissions<BluetoothPermissions>(request);
            }
            else
            {
                bluetoothStatus = await CheckPermissions<Permissions.LocationWhenInUse>(request);
            }
        }

        return bluetoothStatus;
    }

    private static async Task<PermissionStatus> CheckPermissions<TPermission>(bool request = false) where TPermission : Permissions.BasePermission, new()
    {
        var status = await Permissions.CheckStatusAsync<TPermission>();

        if (request)
        {
            status = await Permissions.RequestAsync<TPermission>();
        }

        return status;
    }

    private static bool IsGranted(PermissionStatus status)
    {
        return status == PermissionStatus.Granted || status == PermissionStatus.Limited;
    }

#if ANDROID
    private static bool IsLocationServiceEnabled()
    {
        var locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
        return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
    }
#elif IOS || MACCATALYST
    private static bool IsLocationServiceEnabled()
    {
        return CLLocationManager.Status == CLAuthorizationStatus.Denied;
    }
#elif WINDOWS
    private static bool IsLocationServiceEnabled()
    {
        var locationservice = new Geolocator();
        return locationservice.LocationStatus == PositionStatus.Disabled;
    }
#endif
}
