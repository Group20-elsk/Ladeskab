using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface IRfidReader
    {
        event EventHandler<RfidSensedEventArgs> RfidSensedEvents;
        void SetRfidReaderStatus(bool _newRfidStatus, int id);
    }
}
