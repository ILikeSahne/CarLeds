using CarLeds.CarLeds.General.Utils;
using CarLeds.CarLeds.General.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System.Collections.ObjectModel;

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

    public ObservableCollection<IDevice> FoundBluetoothDevices { get; set; } = new ObservableCollection<IDevice>();

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
            SearchForDevicesAsync();
        }

        _ble.StateChanged += BluetoothStateChanged;
        _adapter.DeviceDiscovered += BluetoothDeviceFound;
    }

    private void BluetoothStateChanged(object sender, BluetoothStateChangedArgs e)
    {
        var isOn = e.NewState == BluetoothState.On;

        if(isOn)
        {
            SearchForDevicesAsync();
        }

        ShowBluetoothStateOverlay = !isOn;
    }

    private async void SearchForDevicesAsync()
    {
        FoundBluetoothDevices.Clear();

        var scanFilterOptions = new ScanFilterOptions();
        await _adapter.StartScanningForDevicesAsync(scanFilterOptions);
    }

    private void BluetoothDeviceFound(object sender, DeviceEventArgs e)
    {
        FoundBluetoothDevices.Add(e.Device);
    }

}