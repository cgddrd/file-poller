﻿using System;
using System.IO;
using System.Security.Permissions;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {

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

            var trackedFile = new TrackedFile(e.FullPath);
        }

    }
}
