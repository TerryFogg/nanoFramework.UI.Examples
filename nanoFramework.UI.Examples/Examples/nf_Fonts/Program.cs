using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_Fonts
{
    public class Program
    {
        public static void Main()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
            fullScreenBitmap.Clear();

            FontExample fe = new FontExample(fullScreenBitmap, DisplayFont);
        }
    }
}
