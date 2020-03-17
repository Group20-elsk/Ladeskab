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
            CurrentCurrent = 0.0; //Tilføjet af Pat for at lave tests. Skal måske fjernes. 
            _display = display;
            _charger = usbCharger;
            usbCharger.CurrentValueEvent += HandleCurrentEvent; //Attach
        }

        public event EventHandler<CurrentEventArgs> CurrentValueEvent; //The connection point for Observers. //Fra Pat, måske slet

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)   //Update
        {
            CurrentCurrent = e.Current; //Her lægges strøm værdien ind i den lokale variable

            if (CurrentCurrent == 0.0)
            {
                _display.DisplayNothing();
                StopCharge();
            }
            else if (CurrentCurrent > 0.0 && CurrentCurrent <= 5.0)
            {
                _display.DisplayFullyCharge();
                OnNewCurrent(); //Måske fjern. Fra Pat.
                StopCharge();
            }
            else if (CurrentCurrent > 5.0 && CurrentCurrent <= 500.0)
            {
                _display.DisplayCharging();
                OnNewCurrent(); //Måske fjern. Fra Pat. 
                StartCharge();
            }
            else if (CurrentCurrent > 500.0)
            {
                _display.DisplayErrorCharging();
                OnNewCurrent(); //Måske fjern. Fra Pat. 
                StopCharge();
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

        // Måske fjern denne metode. Fra Pat. 
        private void OnNewCurrent()
        {
            CurrentValueEvent?.Invoke(this, new CurrentEventArgs() { Current = this.CurrentCurrent });
        }

    }
}
