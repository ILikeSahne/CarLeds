using CarLeds.CarLeds.General.Bluetooth;
using CarLeds.CarLeds.General.Utils;
using CarLeds.CarLeds.General.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace CarLeds.CarLeds.Views.NoBluetoothOverlay;

public class NoBluetoothOverlayVm : ViewModelBase
{
    private Dictionary<BluetoothState, string> _bluetoothStateToStringDict = new Dictionary<BluetoothState, string>()
    {
        { BluetoothState.On, "On" },
        { BluetoothState.Off, "Off" },
        { BluetoothState.TurningOn, "Turning On..." },
        { BluetoothState.TurningOff, "Turning Off..." },
        { BluetoothState.Unavailable, "Unavailable" },
        { BluetoothState.Unauthorized, "Unauthorized" },
        { BluetoothState.Unknown, "Unknown" }
    };

    private BluetoothState _state;
    
    public BluetoothState State
    {
        get => _state;
        set
        {
            _state = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(StateString));
        }
    }

    public string StateString => BluetoothStateToString(State);

    public NoBluetoothOverlayVm()
    {
        var ble = BluetoothProvider.Current;

        State = ble.State;

        ble.StateChanged += BluetoothStateChanged;
    }

    private void BluetoothStateChanged(object sender, BluetoothStateChangedArgs e)
    {
        State = e.NewState;
    }

    private string BluetoothStateToString(BluetoothState newState)
    {
        return _bluetoothStateToStringDict[newState];
    }
}