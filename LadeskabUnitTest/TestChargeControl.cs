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
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger usbCharger;
        private IDisplay display; 

        [SetUp]
        public void Setup()
        {
            _uut = new ChargeControl(usbCharger, display); 
        }

        [Test]
        public void USBCharger_IsConnected()
        {

            Assert.That(usbCharger.Connected, Is.True);
        }

    }
}
