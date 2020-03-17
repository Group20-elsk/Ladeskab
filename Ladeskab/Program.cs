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
            Console.WriteLine("To use RFID, press R");
            IDoor _door = new Door();
            IRfidReader _rfidReader = new RfidReader();

            var key = Console.ReadKey(true);//Skal altid læse hvad for en tast der bliver tastet på
            
            bool doorOpen;
            bool rfidRead;

            switch (key.KeyChar)
            {
                case 'O':
                    _door.SetDoorStatus(doorOpen = true);
                    break;

                case 'C':
                    _door.SetDoorStatus(doorOpen = false);
                    break;
                case 'R':
                    _rfidReader.SetRfidReaderStatus(rfidRead=true);
                    break;

            }

            
           
            //Test
            //UsbChargerSimulator ucs = new UsbChargerSimulator();
            //Display d = new Display();
            //ChargeControl cc = new ChargeControl(ucs,d);

            //cc.StopCharge();

            //Console.WriteLine("Tryk på en tast for at lukke programmet");
            //Console.ReadKey();
        }
    }
}
