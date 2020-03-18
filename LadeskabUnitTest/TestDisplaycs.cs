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
    public class TestDisplaycs
    {
        private Display _uut;
        private IConsoleWriter _consoleWriter;


        [SetUp]
        public void Setup()
        {
            _consoleWriter = Substitute.For<IConsoleWriter>();
            _uut = new Display(_consoleWriter);
        }

        [Test]
        public void DisplayNothing_()
        {
            _uut.writeDisplay("TEST");
            _consoleWriter.Received(1).writeLine(Arg.Is<string>(s=>s.Contains($"TEST")));
        }

    }


}
