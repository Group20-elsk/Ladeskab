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
        private ILog _log;
        private IChargeControl _chargeControl;
        private IDisplay _display;

        [SetUp]
        public void Setup() //Setup for fakes
        {
            _door = Substitute.For<IDoor>();
            _rfidReader = Substitute.For<IRfidReader>();
            _log = Substitute.For<ILog>();
            _chargeControl = Substitute.For<IChargeControl>();
            _display = Substitute.For<IDisplay>();

            _uut = new StationControl(_door,_rfidReader,_log,_chargeControl,_display);
        }

        [Test]
        public void RaisedDoorChangeEvent_True_DoorOpen_Received_tilslut_telefon()
        {
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs(){DoorStatus = true});
            _display.Received().writeDisplay("Tilslut telefon");
        }

        [Test]
        public void RaisedDoorChangeEvent_False_DoorOpen_NotReceived_tilslut_telefon()
        {
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = false });
            _display.DidNotReceive().writeDisplay("Tilslut telefon");
        }

        [Test]
        public void RaisedRfidSendesEvent()
        {
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() {RfidSensed = true});

        }



        [Test]
        public void RaisedDoorChangeEvent_False_Available_Received_Indlæs_RFID()
        {
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = false });
            _display.Received().writeDisplay("Indlæs RFID");
        }
        [Test]
        public void RaisedDoorChangeEvent_True_Available_NotReceived_Indlæs_RFID()
        {
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = true });
            _display.DidNotReceive().writeDisplay("Indlæs RFID");
        }


        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestDoorStatus(bool doorStatus) //Interaction-based test
        //{
        //    _door.SetDoorStatus(doorStatus);
        //    Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        //}

        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestCurrentDoorStatus(bool doorStatus) //Value-based test
        //{
        //    _uut.CurrentDoorStatus = doorStatus;
        //    Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        //}

        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestRFIDreaderStatus(bool RFIDstatus) //Interaction-based test
        //{
        //    _rfidReader.SetRfidReaderStatus(RFIDstatus);
        //    Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDstatus));
        //}

        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestCurrentRFIDStatus(bool RFIDStatus) //Value-based test
        //{
        //    _uut.CurrentRfidSensedStatus = RFIDStatus;
        //    Assert.That(_uut.CurrentRfidSensedStatus, Is.EqualTo(RFIDStatus));
        //}
    }
}
