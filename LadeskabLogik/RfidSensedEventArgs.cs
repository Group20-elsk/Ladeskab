using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class RfidSensedEventArgs : EventArgs
    {
        public bool RfidSensed { get; set; }
        public int Id { get; set; }
    }
}
