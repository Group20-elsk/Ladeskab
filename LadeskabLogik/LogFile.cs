using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class LogFile : ILog
    {
        private string _logFile = "logfile.txt"; // Navnet på systemets log-fil

        public void LogLadeskabAvailable(int id)
        {
            using (var writer = File.AppendText(_logFile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
            }
        }

        public void LogLadeskabLocked(int id)
        {
            using (var writer = File.AppendText(_logFile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
            }
        }
    }
}
