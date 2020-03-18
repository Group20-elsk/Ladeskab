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

            _uut = new ChargeControl(_usbCharger, _display); //ChargeControl skal have en usbCharger og et Display. 
            //_uut.CurrentCurrent = 0.0;
        }

        // Tester om metoden DisplayNothing IKKE bliver kaldt med følgende værdier
        [TestCase(-0.1)]
        [TestCase(0.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayNothing(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            _display.DidNotReceive().DisplayNothing();
        }

        // Tester om metoden DisplayNothing IKKE bliver kaldt med følgende værdi
        [TestCase(0.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayNothing(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            _display.Received().DisplayNothing();
        }


        // Tester om metoden DisplayFullyCharged IKKE bliver kaldt med følgende værdier
        [TestCase(0.0)]
        [TestCase(5.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayFullyCharge(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = current});

            _display.DidNotReceive().DisplayFullyCharge();
        }

        // Tester om metoden DisplayFullyCharged bliver kaldt med følgende værdier
        [TestCase(0.1)]
        [TestCase(4.9)]
        [TestCase(5.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayFullyCharge(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            _display.Received().DisplayFullyCharge();
        }

        // Tester om metoden DisplayCharging IKKE bliver kaldt med følgende værdier
        [TestCase(5.0)]
        [TestCase(500.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            _display.DidNotReceive().DisplayCharging();
        }

        // Tester om metoden DisplayCharging bliver kaldt med følgende værdier
        [TestCase(5.1)]
        [TestCase(499.1)]
        [TestCase(500.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            _display.Received().DisplayCharging();
        }


        //Tester at uut modtager event og modtager currentvalue fra eventet og at currentcurrent bliver sat til cc. 
        [TestCase(0.0)]
        [TestCase(0.1)]
        [TestCase(0.4)]
        [TestCase(5.0)]
        [TestCase(0.6)]
        [TestCase(499.0)]
        [TestCase(500.0)] //Spørg Frank 
        public void CurrentChanged_CurrentCurrentIsCorrect(double cc)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = cc});
            Assert.That(_uut.CurrentCurrent, Is.EqualTo(cc));
        }








        //[Test]
        //public void CurrentCurrent_CurrentSetToNewValue_NewCurrentValue_Is_500()
        //{
        //    _uut.CurrentCurrent = 500.0;
        //    _uut.StartCharge();

        //    Assert.That(_uut.CurrentCurrent, Is.EqualTo(500.0));
        //}


        //[Test]
        //public void CurrentCurrent_Is_Zero()
        //{
        //    Assert.That(_uut.CurrentCurrent, Is.Zero);
        //}

        //[Test]
        //public void ChargeControl_StopCharge_NewCurrentValue_IsEqualTo_0()
        //{
        //    _uut.CurrentCurrent = 500.0;

        //    _uut.StopCharge();

        //    Assert.That(_uut.CurrentCurrent, Is.EqualTo(0.0));
        //}



    }
}
