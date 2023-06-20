using CarLeds.CarLeds.General.Utils;
using CarLeds.CarLeds.General.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace CarLeds.CarLeds.Views.ConnectToDevice;

public class ConnectToDeviceVm : ViewModelBase
{
    private IBluetoothLE _ble;
    private IAdapter _adapter;

    private bool _showBluetoothStateOverlay;

    public bool ShowBluetoothStateOverlay
    {
        get => _showBluetoothStateOverlay;
        set {
            _showBluetoothStateOverlay = value;
            OnPropertyChanged();
        }
    }

    public ConnectToDeviceVm()
    {
        _ble = CrossBluetoothLE.Current;
        _adapter = _ble.Adapter;

        var status = _ble.State;

        if(status != BluetoothState.On)
        {
            ShowBluetoothStateOverlay = true;
        }
        else
        {
            SearchForDevices();
        }

        _ble.StateChanged += BluetoothStateChanged;
    }

    private void BluetoothStateChanged(object sender, BluetoothStateChangedArgs e)
    {
        var isOn = e.NewState == BluetoothState.On;

        if(isOn)
        {
            SearchForDevices();
        }

        ShowBluetoothStateOverlay = !isOn;
    }

    private void SearchForDevices()
    {

    }
}