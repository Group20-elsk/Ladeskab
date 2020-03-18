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

        [SetUp]
        public void Setup()
        {
            _door= new Door();
            _rfidReader = new RfidReader();
            _uut = new StationControl(_door,_rfidReader);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestDoorStatus(bool doorStatus)
        {
            _door.SetDoorStatus(doorStatus);
            Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestRFIDreaderStatus(bool RFIDstatus)
        {
            _rfidReader.SetRfidReaderStatus(RFIDstatus);
            Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDstatus));
        }
    }
}
