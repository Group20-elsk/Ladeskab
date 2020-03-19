using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;
using NUnit.Framework;
using NSubstitute;

namespace LadeskabUnitTest
{
    [TestFixture]
    class TestDoor
    {
        private Door _uut;
        private DoorChangedEventArgs _recivedEventArgs;
        private IConsoleWriter _consoleWriter;

        [SetUp]
        public void Setup()
        {
            _consoleWriter = Substitute.For<IConsoleWriter>();
            _uut = new Door(_consoleWriter);

            _recivedEventArgs = null;
            _uut.DoorChangedEvents += (o, args) => { _recivedEventArgs = args; };
        }

        [Test]
        public void SetDoorStatus_DoorStatusChangesToTrue_DoorStatusIsTrue()
        {
            _uut.SetDoorStatus(false); //DoorStatus sættes til at være false
            _uut.SetDoorStatus(true); // DoorStatus sættes til at true, således der sker en ændring og dermed et event
            Assert.That(_recivedEventArgs.DoorStatus, Is.True);
        }

        [Test]
        public void SetDoorStatus_DoorStatusChangesToFalse_DoorStatusIsFalse()
        {
            _uut.SetDoorStatus(true); //DoorStatus sættes til at være true
            _uut.SetDoorStatus(false); // DoorStatus sættes til at være, således der sker en ændring og dermed et event
            Assert.That(_recivedEventArgs.DoorStatus, Is.False);
        }

        [Test]
        public void LockDoor_printTESTLOCKDOOR_recieved1callWithStringContainingTESTLOCKDOOR()
        {
            _uut.LockDoor("TEST LOCK DOOR");
            _consoleWriter.Received(1).writeLine(Arg.Is<string>(s => s.Contains($"TEST LOCK DOOR")));
        }

        [Test]
        public void writeDisplay_printTESTUNLOCKDOOR_recieved1callWithStringContainingTESTUNLOCKDOOR()
        {
            _uut.UnlockDoor("TEST UNLOCK DOOR");
            _consoleWriter.Received(1).writeLine(Arg.Is<string>(s => s.Contains($"TEST UNLOCK DOOR")));
        }
    }
}
