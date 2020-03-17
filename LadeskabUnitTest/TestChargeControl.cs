using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger usbCharger = new UsbChargerSimulator();
        private IDisplay display = new Display();
        private CurrentEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;

            _uut = new ChargeControl(usbCharger, display);
            _uut.CurrentCurrent = 0.0;

            //Event listener to chech the event occurrence and event data 
            _uut.CurrentValueEvent += (o, args) => { _receivedEventArgs = args; };

        }

        [Test]
        public void CurrentCurrent_CurrentSetToNewValue_EventFired()
        {
            _uut.CurrentCurrent = 500.0;

            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void ChargeControl_Is_Connected()
        {
            _uut.IsConnected();
            Assert.That(_uut.IsConnected, Is.True);
        }


        [Test]
        public void CurrentCurrent_Is_Zero()
        {
            Assert.That(_uut.CurrentCurrent, Is.Zero);
        }

        [Test]
        public void ChargeControl_StopCharge_When_Current_Is_Equel_To_500()
        {
            _uut.CurrentCurrent = 500.0;

            _uut.StopCharge();

            Assert.That(_uut.CurrentCurrent, Is.EqualTo(0.0));
        }

        [Test]
        public void C()
        {
            _uut.CurrentCurrent = 499.0;

            _uut.StartCharge();
            Assert.That(_uut.CurrentCurrent, Is.EqualTo(500.0));
        }

        //[Test]
        //public void p()
        //{

        //    Assert.That(_uut.CurrentCurrent, Is.Zero);
        //}





    }
}
