using System;
using System.IO;
using System.Security.Permissions;

namespace FileWatcher
{
    class Program
    {

        private static Networking networkClient;
        private static Random random = new Random();

        static void Main(string[] args)
        {
            networkClient = new Networking("http://www.fakeresponse.com/api");
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\connorgoddard\Desktop\Logs";
            watcher.Filter = "*.txt";

            watcher.Created += new FileSystemEventHandler(OnCreated);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the application.");
            while (Console.Read() != 'q');

        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            var trackedFile = new PollingFileTracker(e.FullPath, 5000);

            trackedFile.FilePolled += SendNetwork;
        }

        public static void SendNetwork(string fileInfo, object test)
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
        }

    }
}
