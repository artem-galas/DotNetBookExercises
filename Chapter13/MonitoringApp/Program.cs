using System;
using System.Linq;
using MonitoringLib;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Press ENTER to start the timer: ");
            ReadLine();
            Recorder.Start();
            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();
            Write("Press ENTER to stop the timer: ");
            ReadLine();
            Recorder.Stop();
            ReadLine();
        }
    }
}
