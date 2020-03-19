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
        private static IConsoleWriter _consoleWriter;
        public event EventHandler<DoorChangedEventArgs> DoorChangedEvents;

        public Door(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

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

        public void UnlockDoor(string message)
        {
            //Console.WriteLine("Døren er åbnet");
            _consoleWriter.writeLine(message);
        }

        public void LockDoor(string message)
        {
            //Console.WriteLine("Døren er lukket");
            _consoleWriter.writeLine(message);
        }
    }
}
