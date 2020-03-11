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

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)   //Update
        {
            CurrentCurrent = e.Current; //Her lægges strøm værdien ind i den lokale variable

            if (CurrentCurrent == 0.0)
            {
                _display.DisplayNothing();
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
                _display.DisplayErrorCharging();
            }

        }

        public bool IsConnected()
        {
            return _charger.Connected;
        }

        public void StartCharge()
        {
            _charger.StartCharge();
        }

        public void StopCharge()
        {
            _charger.StopCharge();
        }
    }
}
