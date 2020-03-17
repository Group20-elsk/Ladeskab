using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface IChangeControl
    {
        // Event triggered on new current value
        event EventHandler<CurrentEventArgs> CurrentValueEvent; //The Connection point for Observers. //Fra Pat. Måske slet 

        //void HandleCurrentEvent(object sender, CurrentEventArgs e); Pat som har udkommenteret. Måske skal den ikke det. 

        bool IsConnected();

        void StartCharge();

        void StopCharge();

    }
}
