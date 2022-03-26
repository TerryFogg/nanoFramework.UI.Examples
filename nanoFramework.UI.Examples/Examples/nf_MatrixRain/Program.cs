using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_MatrixRain
{
    public class Program
    {
        public static void Main()
        {
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
                
               // DisplayControl.FullScreen;
            fullScreenBitmap.Clear();

            MatrixRain bb = new MatrixRain(fullScreenBitmap);
            Thread.Sleep(Timeout.Infinite);


        }
    }
}
