using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace PingMeToLife
{
    public static class Start
    {
        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static string address = "www.google.com";

        private static int timeout = 1000;

        private static bool isDebugging = false;

        public static void Main()
        {
            if (isDebugging) ShowWindow(GetConsoleWindow(), 5);
            else ShowWindow(GetConsoleWindow(), 0);
            Ping();
        }

        private static void Ping()
        {
            Ping pingSender = new Ping();

            while (true)
            {
                Thread.Sleep(timeout);

                try
                {
                    if (isDebugging)
                    {
                        PingReply sender = pingSender.Send(address, timeout);
                        Console.WriteLine($"{sender.Address} / {sender.RoundtripTime}");
                    }
                    else pingSender.Send(address, timeout);
                }

                catch { continue; }
            }
        }
    }
}
