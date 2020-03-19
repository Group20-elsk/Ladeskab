using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using LadeskabLogik;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestStationControl
    {
        private StationControl _uut;
        private Door _door;
        private RfidReader _rfidReader;
        private IConsoleWriter _consoleWriter;

        [SetUp]
        public void Setup() //Setup for fakes
        {
            _door= new Door(_consoleWriter);
            _rfidReader = new RfidReader();
            _uut = new StationControl(_door,_rfidReader);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestDoorStatus(bool doorStatus) //Interaction-based test
        {
            _door.SetDoorStatus(doorStatus);
            Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestCurrentDoorStatus(bool doorStatus) //Value-based test
        {
            _uut.CurrentDoorStatus = doorStatus;
            Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        }

        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestRFIDreaderStatus(bool RFIDstatus) //Interaction-based test
        //{
        //    _rfidReader.SetRfidReaderStatus(RFIDstatus);
        //    Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDstatus));
        //}

        [TestCase(true)]
        [TestCase(false)]
        public void TestCurrentRFIDStatus(bool RFIDStatus) //Value-based test
        {
            _uut.CurrentRfidSensedStatus = RFIDStatus;
            Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDStatus));
        }
    }
}
