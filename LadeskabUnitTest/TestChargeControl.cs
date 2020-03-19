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
            _uut.CurrentCurrent = 0.0;
        }

        //Tests af HandleCurrentEvent-metoden i klassen ChargeControl 
        //Starter 

        // Tester om metoden DisplayNothing IKKE bliver kaldt med følgende værdier
        [TestCase(-0.1)]
        [TestCase(0.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayNothing(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.DidNotReceive().DisplayNothing();
            _display.DidNotReceive().writeDisplay("Display nothing");
        }

        // Tester om metoden DisplayNothing bliver kaldt med følgende værdi
        [TestCase(0.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayNothing(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.Received().DisplayNothing();
            _display.Received().writeDisplay("Display nothing");
        }


        // Tester om metoden DisplayFullyCharged IKKE bliver kaldt med følgende værdier
        [TestCase(0.0)]
        [TestCase(5.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayFullyCharge(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = current});

            //_display.DidNotReceive().DisplayFullyCharge();
            _display.DidNotReceive().writeDisplay("Telefon er fuldt opladet");
        }

        // Tester om metoden DisplayFullyCharged bliver kaldt med følgende værdier
        [TestCase(0.1)]
        [TestCase(4.9)]
        [TestCase(5.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayFullyCharge(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.Received().DisplayFullyCharge();
            _display.Received().writeDisplay("Telefon er fuldt opladet");
        }

        // Tester om metoden DisplayCharging IKKE bliver kaldt med følgende værdier
        [TestCase(5.0)]
        [TestCase(500.1)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.DidNotReceive().DisplayCharging();
            _display.DidNotReceive().writeDisplay("Oplades...");
        }

        // Tester om metoden DisplayCharging bliver kaldt med følgende værdier
        [TestCase(5.1)]
        [TestCase(6.7)]
        [TestCase(499.1)]
        [TestCase(500.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.Received().DisplayCharging();
            _display.Received().writeDisplay("Oplades...");
        }

        // Tester om metoden DisplayErrorCharging IKKE bliver kaldt med følgende værdier
        [TestCase(499.9)]
        [TestCase(500.0)]
        public void CurrentCurrentValues_DoNOTCallMethod_DisplayErrorCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.DidNotReceive().DisplayErrorCharging();
            _display.DidNotReceive().writeDisplay("Fejlmeddelelse - Opladning");
        }

        // Tester om metoden DisplayErrorCharging bliver kaldt med følgende værdier
        [TestCase(500.1)]
        [TestCase(750.0)]
        [TestCase(800.0)]
        public void CurrentCurrentValues_DoCallMethod_DisplayErrorCharging(double current)
        {
            _uut.StartCharge();

            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });

            //_display.Received().DisplayErrorCharging();
            _display.Received().writeDisplay("Fejlmeddelelse - Opladning");
        }

        //Slutter


        //Tester at uut modtager event og modtager currentvalue fra eventet og at currentcurrent bliver sat til cc. 
        [TestCase(0.0)]
        [TestCase(0.1)]
        [TestCase(0.4)]
        [TestCase(5.0)]
        [TestCase(5.1)]
        [TestCase(499.0)]
        [TestCase(500.0)] //Spørg Frank 
        public void CurrentChanged_CurrentCurrentIsCorrect(double cc)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = cc});
            Assert.That(_uut.CurrentCurrent, Is.EqualTo(cc));
        }

        //Tests af IsConnected-metoden i klassen ChargeControl
        //Starter 

        //Tester usbCharger som en stub. Ser på propertien "Connected" og at den IKKE er connected. 
        [Test]
        public void USBChargerIsNOTConnected_ConnectedErFalse_ReturnsEqualToFalse()
        {
            _usbCharger.Connected.Returns(false); 

            Assert.AreEqual(_usbCharger.Connected, false);
        }

        //Tester usbCharger som en stub. Ser på propertien "Connected" og at den ER connected. 
        [Test]
        public void USBChargerISConnected_ConnectedErTrue_Returns_NotEqualToFalse()
        {
            _usbCharger.Connected.Returns(true);

            Assert.AreNotEqual(_usbCharger.Connected, false);
        }

        //Tester usbCharger som en stub. Ser på propertien "Connected" og at den ER connected. 
        [Test]
        public void USBChargerISConnected_ConnectedErTrue_Returns_EqualToTrue()
        {
            _usbCharger.Connected.Returns(true);

            Assert.AreEqual(_usbCharger.Connected, true);
        }

        //Tester usbCharger som en stub. Ser på propertien "Connected" og at den IKKE er connected. 
        [Test]
        public void USBChargerISConnected_ConnectedErFalse_Returns_NotEqualToTrue()
        {
            _usbCharger.Connected.Returns(false);

            Assert.AreNotEqual(_usbCharger.Connected, true);
        }

        //Tests af StartCharge-metoden i klassen ChargeControl


        //Tests af StopCharge-metoden i klassen ChargeControl


        // Tests jeg lavede da jeg var forvirret...
        //Starter
        [Test]
        public void CurrentCurrent_CurrentSetToNewValue_NewCurrentValue_Is_500()
        {
            _uut.CurrentCurrent = 500.0;
            _uut.StartCharge();

            Assert.That(_uut.CurrentCurrent, Is.EqualTo(500.0));
        }


        [Test]
        public void CurrentCurrent_Is_Zero()
        {
            Assert.That(_uut.CurrentCurrent, Is.Zero);
        }

        //Slutter
    }
}
