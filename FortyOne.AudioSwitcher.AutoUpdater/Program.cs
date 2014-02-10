using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace FortyOne.AudioSwitcher.AutoUpdater
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                return -1;
            }

            int pid = int.Parse(args[0]);
            string audioSwitcherPath = args[1];
            string audioSwitcherOldPath = audioSwitcherPath + "_old";

            int x = 0;

            Console.Write("Waiting for Audio Switcher to exit");

            try
            {
                while (Process.GetProcessById(pid) != null)
                {
                    Console.Write(".");
                    Thread.Sleep(500);

                    if (x > 30)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Audio Switcher process has not ended");
                        return Exit();
                    }
                }
            }
            catch
            {
            }

            try
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Updating...");

                if (File.Exists(audioSwitcherOldPath))
                    File.Delete(audioSwitcherOldPath);

                File.Move(audioSwitcherPath, audioSwitcherOldPath);

                using (var wc = new WebClient())
                using (var client = new AudioSwitcherService.AudioSwitcher())
                {
                    string url = client.CheckForUpdate("0.0.0.0").Replace(".zip", ".exe");

                    wc.DownloadFile(url, audioSwitcherPath);
                }
            }
            catch
            {
                if (File.Exists(audioSwitcherPath))
                    File.Delete(audioSwitcherPath);
                File.Move(audioSwitcherOldPath, audioSwitcherPath);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Error while updating");
            }

            Process.Start(audioSwitcherPath);

            if (File.Exists(audioSwitcherOldPath))
                File.Delete(audioSwitcherOldPath);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Updating Complete");

            return Exit();
        }

        private static int Exit()
        {
            Console.WriteLine("Exiting...");
            return 1;
        }
    }
}