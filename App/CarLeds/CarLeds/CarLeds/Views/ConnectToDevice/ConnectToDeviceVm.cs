using CarLeds.CarLeds.General.Utils;
using CarLeds.CarLeds.General.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

    public ICommand SearchForDevicesCommand { get; set; }

    public ObservableCollection<IDevice> FoundBluetoothDevices { get; set; } = new ObservableCollection<IDevice>();

    public ConnectToDeviceVm()
    {
        _ble = CrossBluetoothLE.Current;
        _adapter = _ble.Adapter;

        ShowBluetoothStateOverlay = _ble.IsOn;

        _ble.StateChanged += BluetoothStateChangedAsync;
        _adapter.DeviceDiscovered += BluetoothDeviceFound;

        RequestPermissions();
    }

    private void RequestPermissions()
    {
        Task.Run(() =>
        {
            Application.Current.Dispatcher.Dispatch(async() =>
            {
                await PermissionUtils.CheckBluetoothPermissions();
            });
        });
    }

    private async void BluetoothStateChangedAsync(object sender, BluetoothStateChangedArgs e)
    {
        var isOn = e.NewState == BluetoothState.On;

        if(isOn)
        {
            await SearchForDevicesAsync();
        }

        ShowBluetoothStateOverlay = !isOn;
    }

    private async Task SearchForDevicesAsync()
    {
        FoundBluetoothDevices.Clear();

        var scanFilterOptions = new ScanFilterOptions();
        await _adapter.StartScanningForDevicesAsync();
    }

    private void BluetoothDeviceFound(object sender, DeviceEventArgs e)
    {
        FoundBluetoothDevices.Add(e.Device);
        Console.WriteLine("test");
    }
}