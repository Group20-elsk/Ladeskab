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

        //Test af Door event
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


        //Test af Door event og Rfid event
        [TestCase(false, false,true)]
        [TestCase(false, true, true)]
        public void RaisedDoorChangeEvent_Available_IsConnected_isTrue_StartCharge_Called(bool doorstatus, bool rfidstatus, bool isConnected)
        {
            //Ønsker at gøre state = available
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus});

            _chargeControl.IsConnected().Returns(isConnected);

            //Problem: Rfidstatus spiller ingen rolle i koden??
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() {RfidSensed = rfidstatus});

            _chargeControl.Received().StartCharge();
        }

        [TestCase(false, false, false)]
        [TestCase(false, true, false)]
        public void RaisedDoorChangeEvent_Available_IsConnected_isFalse_StartCharge_NotCalled(bool doorstatus, bool rfidstatus, bool isConnected)
        {
            //Ønsker at gøre state = available
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            _chargeControl.IsConnected().Returns(isConnected);

            //Problem: Rfidstatus spiller ingen rolle i koden??
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus });

            _chargeControl.DidNotReceive().StartCharge();
        }
        

        [TestCase(true, false)]
        [TestCase(true, true)]
        public void RaisedDoorChangeEvent_DoorOpen_NotReceive_StartCharge(bool doorstatus, bool rfidstatus)
        {
            //Ønsker at gøre state = doorOpen
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            //Ønsker at se at der ikke sker noget
            //Problem: Rfidstatus spiller ingen rolle i koden??
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus });

            _chargeControl.DidNotReceive().StartCharge();
        }

        [TestCase(true, false)]
        [TestCase(true, true)]
        public void RaisedDoorChangeEvent_DoorOpen_NotReceive_StopCharge(bool doorstatus, bool rfidstatus)
        {
            //Ønsker at gøre state = doorOpen
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            //Ønsker at se at der ikke sker noget
            //Problem: Rfidstatus spiller ingen rolle i koden??
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus });

            _chargeControl.DidNotReceive().StopCharge();
        }


        [TestCase(false, false, false, true)]
        [TestCase(false, false, true, true)]
        [TestCase(false, true, false, true)]
        [TestCase(false, true, true, true)]
        public void RaisedDoorChangeEvent_Locked_id_equals_oldId_StopCharge_Called(bool doorstatus, bool rfidstatus1, bool rfidstatus2, bool isConnected)
        {
            //State = Available
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            _chargeControl.IsConnected().Returns(isConnected);

            //Problem: Rfidstatus spiller ingen rolle i koden??
            //State = Locked
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus1 });

            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus2 });

            _chargeControl.Received().StopCharge();
        }

        //[TestCase(false, false, false, true)]
        //[TestCase(false, false, true, true)]
        //[TestCase(false, true, false, true)]
        //[TestCase(false, true, true, true)]
        //public void RaisedDoorChangeEvent_Locked_id_Notequals_oldId_StopCharge_NotCalled(bool doorstatus, bool rfidstatus1, bool rfidstatus2, bool isConnected)
        //{
        //    //State = Available
        //    _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

        //    _chargeControl.IsConnected().Returns(isConnected);

        //    //Problem: Rfidstatus spiller ingen rolle i koden??
        //    //State = Locked
        //    _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus1 });

        //    //For at teste at dette scenarie skal Id være mulig at ændre, og det er det ikke i dette tilfælde
        //    //Koden vil derfor aldrig gå ind i linje 111 i StationControl
        //    _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus2 });

        //    _chargeControl.DidNotReceive().StopCharge();
        //}



        //Test af LogFile
        [TestCase(false, false, true, 10)]
        [TestCase(false, true, true, 10)]
        public void RaisedDoorChangeEvent_Available_IsConnected_isTrue_LogLadeskabAvailable_Called_Id10(bool doorstatus, bool rfidstatus, bool isConnected, int id)
        {
            //Ønsker at gøre state = available
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            _chargeControl.IsConnected().Returns(isConnected);

            //Problem: Rfidstatus spiller ingen rolle i koden??
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus });

            _log.Received().LogLadeskabAvailable(id);       
        }


        [TestCase(false, false, false, true, 10)]
        [TestCase(false, false, true, true, 10)]
        [TestCase(false, true, false, true, 10)]
        [TestCase(false, true, true, true, 10)]
        public void RaisedDoorChangeEvent_Locked_id_equals_oldId_LogLadeskabLocked_Called_Id10(bool doorstatus, bool rfidstatus1, bool rfidstatus2, bool isConnected, int id)
        {
            //State = Available
            _door.DoorChangedEvents += Raise.EventWith(new DoorChangedEventArgs() { DoorStatus = doorstatus });

            _chargeControl.IsConnected().Returns(isConnected);

            //Problem: Rfidstatus spiller ingen rolle i koden??
            //State = Locked
            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus1 });

            _rfidReader.RfidSensedEvents += Raise.EventWith(new RfidSensedEventArgs() { RfidSensed = rfidstatus2 });

            _log.Received().LogLadeskabLocked(id);
        }










        //Gammel test:

        //[TestCase(true)]
        //[TestCase(false)]
        //public void TestDoorStatus(bool doorStatus) //Interaction-based test
        //{
        //    _door.SetDoorStatus(doorStatus);
        //    Assert.That(_uut.CurrentDoorStatus, Is.EqualTo(doorStatus));
        //}

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
