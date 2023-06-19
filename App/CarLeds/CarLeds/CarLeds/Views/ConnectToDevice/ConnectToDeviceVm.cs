using CarLeds.CarLeds.General.ViewModel;
using Plugin.BLE;

namespace CarLeds.CarLeds.Views.ConnectToDevice;

public class ConnectToDeviceVm : ViewModelBase
{
    public ConnectToDeviceVm()
    {
        var ble = CrossBluetoothLE.Current;
        var adapter = CrossBluetoothLE.Current.Adapter;
    }
}