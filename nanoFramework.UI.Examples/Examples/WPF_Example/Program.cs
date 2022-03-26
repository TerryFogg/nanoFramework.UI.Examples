using System;
using System.Diagnostics;
using System.Threading;

namespace WPF_Example
{
    public class Program
    {
        public static void Main()
        {
            ApplicationMain.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
