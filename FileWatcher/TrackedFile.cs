using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcher
{
    class TrackedFile
    {
        private string filePath;
        private Timer timer;
        private Random rand = new Random();

        public TrackedFile(string filePath)
        {
            this.filePath = filePath;
            this.timer = new Timer(CheckForChanges, null, 1000, Timeout.Infinite);
        }

        public void CheckForChanges(object stateInfo)
        {
            Console.WriteLine($"Checking for file changes via timer... - {DateTime.UtcNow}");

            var randTimeout = rand.Next(0, 10) * 1000;

            Console.WriteLine($"Timeout for {randTimeout} secs");
            Thread.Sleep(randTimeout);

            timer.Change(1000, Timeout.Infinite);
        }
    }
}
