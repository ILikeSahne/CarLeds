using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLeds.CarLeds.Testing.Bluetooth;

public class Adapter : IAdapter
{
    public bool IsScanning => throw new NotImplementedException();

    public int ScanTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ScanMode ScanMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IReadOnlyList<IDevice> DiscoveredDevices => throw new NotImplementedException();

    public IReadOnlyList<IDevice> ConnectedDevices => throw new NotImplementedException();

    public event EventHandler<DeviceEventArgs> DeviceAdvertised;
    public event EventHandler<DeviceEventArgs> DeviceDiscovered;
    public event EventHandler<DeviceEventArgs> DeviceConnected;
    public event EventHandler<DeviceEventArgs> DeviceDisconnected;
    public event EventHandler<DeviceErrorEventArgs> DeviceConnectionLost;
    public event EventHandler ScanTimeoutElapsed;

    public Task ConnectToDeviceAsync(IDevice device, ConnectParameters connectParameters = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IDevice> ConnectToKnownDeviceAsync(Guid deviceGuid, ConnectParameters connectParameters = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DisconnectDeviceAsync(IDevice device)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<IDevice> GetKnownDevicesByIds(Guid[] ids)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<IDevice> GetSystemConnectedOrPairedDevices(Guid[] services = null)
    {
        throw new NotImplementedException();
    }

    public Task StartScanningForDevicesAsync(ScanFilterOptions scanFilterOptions = null, Func<IDevice, bool> deviceFilter = null, bool allowDuplicatesKey = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StartScanningForDevicesAsync(Guid[] serviceUuids, Func<IDevice, bool> deviceFilter = null, bool allowDuplicatesKey = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StopScanningForDevicesAsync()
    {
        throw new NotImplementedException();
    }
}
