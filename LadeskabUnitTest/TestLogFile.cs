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
    class TestLogFile
    {
        private LogFile _logFile;

        [SetUp]
        public void Setup()
        {
            _logFile = new LogFile();
        }

        //[TestCase(1)]
        //[TestCase(10)]
        //public void Test1(int id)
        //{
        //    _logFile.LogLadeskabAvailable(id);

        //    //Ved ikke hvad jeg skal asserte på. Der er ikke noget at asserte på?
        //}
    }
}
