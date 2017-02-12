using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcher
{
    delegate void MyEventHandler(string filePath, object stateInfo);

    interface IPollingFileTracker : IFileTracker
    {
        event MyEventHandler FilePolled;
    }
}
