using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLeds.CarLeds.General.Bluetooth;

public class BluetoothProvider
{
    public static IBluetoothLE Current {
        get
        {
            if (MauiProgram.Testing)
            {
                return new Testing.Bluetooth.BluetoothLE(Testing.Bluetooth.BluetoothLE.TestingMode.SendMessages);
            }

            return CrossBluetoothLE.Current;            
        }
    }
}
