using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface IDoor
    {
        event EventHandler<DoorChangedEventArgs>DoorChangedEvents;

        void SetDoorStatus(bool newDoorStatus);
        void UnlockDoor(string message);
        void LockDoor(string message);


    }
}
