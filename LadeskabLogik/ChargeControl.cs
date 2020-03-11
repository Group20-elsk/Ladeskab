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
            usbCharger.CurrentValueEvent += HandleCurrentEvent;
        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {
            CurrentCurrent = e.Current;
            //Muligvis tilføj mere. 
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
