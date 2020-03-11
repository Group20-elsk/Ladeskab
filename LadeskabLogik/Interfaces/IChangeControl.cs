using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface IChangeControl
    {
        void HandleCurrentEvent(object sender, CurrentEventArgs e);

        bool IsConnected();

        void StartCharge();

        void StopCharge();

    }
}
