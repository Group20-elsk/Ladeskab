using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class RfidReader : IRfidReader
    {
        private bool _oldRfidStatus;
        public event EventHandler<RfidSensedEventArgs> RfidSensedEvents;

        public void SetRfidReaderStatus(bool _newRfidStatus)
        {
            OnRfidStatusChanged(new RfidSensedEventArgs { RfidSensed = _newRfidStatus });
            _oldRfidStatus = _newRfidStatus;
        }

        protected virtual void OnRfidStatusChanged(RfidSensedEventArgs e)
        {
            RfidSensedEvents?.Invoke(this, e);
        }
    }
}
