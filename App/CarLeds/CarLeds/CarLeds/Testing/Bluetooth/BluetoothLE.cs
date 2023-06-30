using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLeds.CarLeds.Testing.Bluetooth;

public class BluetoothLE : IBluetoothLE
{
    public BluetoothLE() {
        new Task(async () =>
        {
            while(true)
            {
                State = BluetoothState.Off;
                await Task.Delay(1000);

                State = BluetoothState.TurningOn;
                await Task.Delay(1000);

                State = BluetoothState.On;
                await Task.Delay(5000);

                State = BluetoothState.TurningOff;
                await Task.Delay(1000);
            }
        }).Start();
    }

    private BluetoothState _state = BluetoothState.Off;

    public BluetoothState State {
        get => _state;
        set
        {
            StateChanged?.Invoke(this, new BluetoothStateChangedArgs(_state, value));
            _state = value;
        }
    }

    public bool IsAvailable => throw new NotImplementedException();

    public bool IsOn => State == BluetoothState.On;

    public IAdapter Adapter => new Adapter();

    public event EventHandler<BluetoothStateChangedArgs> StateChanged;
}
