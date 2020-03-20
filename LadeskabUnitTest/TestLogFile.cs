using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestLogFile
    {
        private ILog _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void Test_LogLadeskabAvailable(int id)
        {
            _uut.LogLadeskabAvailable(id);
            
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void Test_LogLadeskabLocked(int id)
        {
            _uut.LogLadeskabAvailable(id);

        }
    }
}
