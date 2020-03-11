using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class Display : IDisplay
    {
        public void DisplayNothing()
        {
            Console.WriteLine("Display nothing");
        }

        public void DisplayFullyCharge()
        {
            Console.WriteLine("Telefon er fuldt opladet");
        }

        public void DisplayCharging()
        {
            Console.WriteLine("Oplades...");
        }

        public void DisplayErrorCharging()
        {
            Console.WriteLine("Fejlmeddelelse - Opladning");
        }
    }
}
