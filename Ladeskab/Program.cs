using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;

namespace LadeskabAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To open the door, press o");
            Console.WriteLine("To close the door, press c");
            Console.WriteLine("To use RFID, press r");

            IConsoleWriter _consoleWriter=new ConsoleWriter();
            IDoor _door = new Door(_consoleWriter);
            IRfidReader _rfidReader = new RfidReader();
            ILog _log = new LogFile();
            IDisplay _display = new Display(_consoleWriter);
            IUsbCharger _usbCharger = new UsbChargerSimulator();
            IChargeControl _chargeControl = new ChargeControl(_usbCharger,_display);
            StationControl _stationControl = new StationControl(_door,_rfidReader,_log,_chargeControl,_display);

            while (true)
            {
                 var key = Console.ReadKey(true);//Skal altid læse hvad for en tast der bliver tastet på
                
                switch (key.KeyChar)
                {
                    case 'o':
                        _door.SetDoorStatus(true);
                        break;

                    case 'c':
                        _door.SetDoorStatus(false);
                        break;
                    case 'r':
                        _rfidReader.SetRfidReaderStatus(true);
                        break;
                   

                }
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
