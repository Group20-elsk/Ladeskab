using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestFixture]
    class TestDoor
    {
        private Door _uut;
        private DoorChangedEventArgs _recivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _recivedEventArgs = null;
            _uut = new Door();

            _uut.DoorChangedEvents += (o, args) => { _recivedEventArgs = args; };
        }

        [Test]
        public void test()
        {
            _uut.SetDoorStatus(false); //DoorStatus sættes til at være false
            _uut.SetDoorStatus(true); // DoorStatus sættes til at true, således der sker en ændring og dermed et event
            Assert.That(_recivedEventArgs.DoorStatus, Is.True);
        }

        [Test]
        public void test2()
        {
            _uut.SetDoorStatus(true); //DoorStatus sættes til at være true
            _uut.SetDoorStatus(false); // DoorStatus sættes til at være, således der sker en ændring og dermed et event
            Assert.That(_recivedEventArgs.DoorStatus, Is.False);
        }
    }
}
