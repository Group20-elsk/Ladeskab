using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{

    public class Door : IDoor
    {
        private bool _oldStatus;

        public event EventHandler<DoorChangedEventArgs> DoorChangedEvents;

        public void SetDoorStatus(bool newStatus)
        {
            if (newStatus != _oldStatus)
            {
                OnDoorStatusChanged(new DoorChangedEventArgs {OpenDoor = newStatus});
                _oldStatus = newStatus;
            }
        }

        protected virtual void OnDoorStatusChanged(DoorChangedEventArgs e)
        {
            DoorChangedEvents?.Invoke(this,e);
        }

    }
}
