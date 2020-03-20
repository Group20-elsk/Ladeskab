using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public interface ILog
    {
         void LogLadeskabAvailable(int id);
         void LogLadeskabLocked(int id);
        
    }
}
