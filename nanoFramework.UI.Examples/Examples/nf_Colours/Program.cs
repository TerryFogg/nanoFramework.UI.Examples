using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_Colours
{
    public class Program
    {
        public static void Main()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
//            Bitmap fullScreenBitmap = DisplayControl.FullScreen;
            fullScreenBitmap.Clear();

            Colours bb = new Colours(fullScreenBitmap, DisplayFont);
        }
    }
}
