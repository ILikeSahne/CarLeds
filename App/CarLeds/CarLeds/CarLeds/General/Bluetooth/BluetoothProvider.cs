using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLeds.CarLeds.Testing.Bluetooth;

namespace CarLeds.CarLeds.General.Bluetooth;

public class BluetoothProvider
{
    public static IBluetoothLE Current {
        get
        {
#if WINDOWS

#endif

#if !WINDOWS
            return CrossBluetoothLE.Current;
#else
            return new BluetoothLE();
#endif
        }
    }
}
