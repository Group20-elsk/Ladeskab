using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface IDisplay
    {
        void DisplayNothing();

        void DisplayFullyCharge();

        void DisplayCharging();

        void DisplayErrorCharging();
    }
}
