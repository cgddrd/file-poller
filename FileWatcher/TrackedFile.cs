using System;
using System.Threading;

namespace FileWatcher
{
    class TrackedFile
    {
        private string filePath;
        private Timer timer;
        private Random random = new Random();
        private Networking networkClient;

        public TrackedFile(string filePath)
        {
            this.filePath = filePath;
            this.timer = new Timer(CheckForChanges, null, 1000, Timeout.Infinite);
            this.networkClient = new Networking("http://www.fakeresponse.com/api");
        }

        public void CheckForChanges(object stateInfo)
        {
            Console.WriteLine($"Checking for file changes via timer... - {DateTime.UtcNow}");

            var sleepTime = random.Next(0, 2) == 1 ? random.Next(0, 20) : 0;

            Console.WriteLine($"Network timeout for {sleepTime} secs");
            //Thread.Sleep(randTimeout);

            networkClient.GetRequestAsync($"?data={{%22name%22:%22upload%22}}&sleep={sleepTime}&status=200")
                                    .ContinueWith(callback =>
                                    {
                                        Console.WriteLine($"Completed historical upload.");
                                    });

            timer.Change(1000, Timeout.Infinite);
        }
    }
}
