using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class ChargeControl : IChangeControl
    {
        public double CurrentCurrent { get; set; }
        private IDisplay _display;
        private IUsbCharger _charger;

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _display = display;
            usbCharger.CurrentValueEvent += HandleCurrentEvent; //Attach
        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)   //update
        {
            CurrentCurrent = e.Current;

            if (CurrentCurrent == 0.0)
            {

            }
            else if (CurrentCurrent > 0.0 && CurrentCurrent <= 5.0)
            {
                _display.DisplayFullyCharge();
            }
            else if (CurrentCurrent > 5.0 && CurrentCurrent <= 500.0)
            {
                _display.DisplayCharging();
            }
            else if (CurrentCurrent > 500.0)
            {
                _display.DisplayError(); 
            }

        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }
    }
}
