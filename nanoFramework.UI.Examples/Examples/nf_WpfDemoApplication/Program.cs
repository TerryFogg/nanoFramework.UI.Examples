using nanoFramework.UI;
using System.Threading;

namespace nf_WpfDemoApplication
{
    public class Program
    {
        /// <summary>
        /// The executable entry point.
        /// </summary>
        public static void Main()
        {

            MySimpleWPFApplication msWPF = new MySimpleWPFApplication();
            msWPF.Start();

            Thread.Sleep(Timeout.Infinite);

        }
    }
}
