using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLeds.CarLeds.Testing.Bluetooth;

public class Device : IDevice
{
    private Guid _id = Guid.NewGuid();

    public Guid Id => _id;

    private string _name = GetRandomName();

    public string Name => _name;

    public int Rssi => throw new NotImplementedException();

    public object NativeDevice => throw new NotImplementedException();

    public DeviceState State => throw new NotImplementedException();

    public IList<AdvertisementRecord> AdvertisementRecords => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<IService> GetServiceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<IService>> GetServicesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> RequestMtuAsync(int requestValue)
    {
        throw new NotImplementedException();
    }

    public bool UpdateConnectionInterval(ConnectionInterval interval)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRssiAsync()
    {
        throw new NotImplementedException();
    }

    private static string GetRandomName()
    {
        var names = new string[]
        {
            "Bob", 
            "Laura",
            "Peter",
            "Jonathan",
            "Paul",
            "Alex",
            "Chiara"
        };

        var name = names[Random.Shared.Next(names.Length)] + Random.Shared.NextInt64();

        return name;
    }
}
