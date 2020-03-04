using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class DoorChangedEventArgs : EventArgs
    {
        public bool OpenDoor { get; set; }
    }
}
