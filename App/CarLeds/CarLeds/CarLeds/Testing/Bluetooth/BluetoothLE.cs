using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace CarLeds.CarLeds.Testing.Bluetooth;

public class BluetoothLE : IBluetoothLE
{
    public BluetoothLE(TestingMode mode)
    {
        new Task(async () =>
        {
            if (mode == TestingMode.OnOff)
            {
                while (true)
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
            }

            if (mode == TestingMode.SendMessages)
            {
                State = BluetoothState.On;
            }
        }).Start();
    }

    private BluetoothState _state = BluetoothState.Off;

    public BluetoothState State
    {
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

    public enum TestingMode
    {
        OnOff, SendMessages
    }
}
