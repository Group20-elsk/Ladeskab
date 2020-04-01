using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using LadeskabLogik;
using NUnit.Framework;
using NSubstitute;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestStationControl
    {
        private StationControl _uut;
        private IDoor _door;
        private IRfidReader _rfidReader;
        private IConsoleWriter _consoleWriter;
        private ILog _log;

        [SetUp]
        public void Setup() //Setup for fakes
        {
            _consoleWriter = Substitute.For<IConsoleWriter>();
            _door = Substitute.For<IDoor>();
            _rfidReader = Substitute.For<IRfidReader>();
            _log = Substitute.For<ILog>();
            _uut = new StationControl(_door,_rfidReader,_log);
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

        [TestCase(true)]
        [TestCase(false)]
        public void TestRFIDreaderStatus(bool RFIDstatus) //Interaction-based test
        {
            _rfidReader.SetRfidReaderStatus(RFIDstatus);
            Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDstatus));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestCurrentRFIDStatus(bool RFIDStatus) //Value-based test
        {
            _uut.CurrentRfidSensedStatus = RFIDStatus;
            Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDStatus));
        }
    }
}
