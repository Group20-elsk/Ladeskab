using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class Display : IDisplay
    {
        private static IConsoleWriter _consoleWriter;

        public Display(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public void writeDisplay(string message)
        {
            _consoleWriter.writeLine(message);
        }
        //public void DisplayNothing()
        //{
        //    Console.WriteLine("Display nothing");
        //}

        //public void DisplayFullyCharge()
        //{
        //    Console.WriteLine("Telefon er fuldt opladet");
        //}

        //public void DisplayCharging()
        //{
        //    Console.WriteLine("Oplades...");
        //}


        //public void DisplayErrorCharging()
        //{
        //    Console.WriteLine("Fejlmeddelelse - Opladning");
        //}

        //public void DisplayDoorClosed()
        //{
        //    Console.WriteLine("Indlæs RFID");
        //}

        //public void DisplayDoorOpen()
        //{
        //    Console.WriteLine("Tilslut telefon");
        //}

       
    }
}
