using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{

    public class Door : IDoor
    {
        private bool _oldDoorStatus;

        public event EventHandler<DoorChangedEventArgs> DoorChangedEvents;

        public void SetDoorStatus(bool newDoorStatus)
        {
            if (newDoorStatus != _oldDoorStatus)
            {
                OnDoorStatusChanged(new DoorChangedEventArgs {DoorStatus = newDoorStatus});
                _oldDoorStatus = newDoorStatus;
            }
        }


        protected virtual void OnDoorStatusChanged(DoorChangedEventArgs e)
        {
            DoorChangedEvents?.Invoke(this,e);//invoker alle dem som har 
        }

        public void UnlockDoor()
        {
            Console.WriteLine("Døren er åbnet");
        }

        public void LockDoor()
        {
            Console.WriteLine("Døren er lukket");
        }



    }
}
