using System;
using System.Threading;

namespace FileWatcher
{
    class PollingFileTracker : IPollingFileTracker
    {
        private string filePath;
        private Timer timer;
        private int pollDelay;

        public event MyEventHandler FilePolled;

        public string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                this.filePath = value;
            }
        }

        public PollingFileTracker(string filePath, int pollDelay)
        {
            this.filePath = filePath;
            this.pollDelay = pollDelay;
            this.timer = new Timer(CheckForChanges, null, pollDelay, Timeout.Infinite);
        }

        public void CheckForChanges(object stateInfo)
        {
            FilePolled(filePath, stateInfo);
            timer.Change(pollDelay, Timeout.Infinite);
        }
        
    }
}
