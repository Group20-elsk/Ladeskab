using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger _usbCharger;
        private IDisplay _display;


        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>(); //Lavet fake af UsbChargerSimulator. 
            _display = Substitute.For<IDisplay>(); //Lavet fake af Display. 

            _uut = new ChargeControl(_usbCharger, _display);
            _uut.CurrentCurrent = 0.0;
        }

        //Lav nye tests!! 

        [Test]
        public void CurrentCurrent_CurrentSetToNewValue_NewCurrentValue_Is_500()
        {
            _uut.CurrentCurrent = 500.0;
            _uut.StartCharge();

            Assert.That(_uut.CurrentCurrent, Is.EqualTo(500.0));
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
        public void ChargeControl_StopCharge_NewCurrentValue_IsEqualTo_0()
        {
            _uut.CurrentCurrent = 500.0;

            _uut.StopCharge();

            Assert.That(_uut.CurrentCurrent, Is.EqualTo(0.0));
        }



    }
}
