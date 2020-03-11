using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;

namespace LadeskabAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To open the door, press O");
            Console.WriteLine("To close the door, press C");
            
           IDoor door = new Door();
           

            //var key = Console.ReadKey(true);//Skal altid læse hvad for en tast der bliver tastet på
            //bool doorOpen;
            //switch (key.KeyChar)
            //{
            //    case 'O':
            //        door.SetDoorStatus(doorOpen = true);
            //        break;

            //    case 'C':
            //        door.SetDoorStatus(doorOpen = false);
            //        break;

                
            //}

            UsbChargerSimulator ucs = new UsbChargerSimulator();
            Display d = new Display();
            ChargeControl cc = new ChargeControl(ucs,d);

            cc.StartCharge();

        }
    }
}
