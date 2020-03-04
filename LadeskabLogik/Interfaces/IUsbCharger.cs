using System;

namespace LadeskabLogik
{
    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; } //Property, dataene. 
    }

    public interface IUsbCharger
    {
        // Event triggered on new current value
        event EventHandler<CurrentEventArgs> CurrentValueEvent; //The Connection point for Observers. 

        // Direct access to the current current value
        double CurrentValue { get; }

        // Require connection status of the phone
        bool Connected { get; }

        // Start charging
        void StartCharge();
        // Stop charging
        void StopCharge();
    }
}