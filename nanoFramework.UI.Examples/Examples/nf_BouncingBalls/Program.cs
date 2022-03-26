

using nanoFramework.UI;

namespace nf_BouncingBalls
{
    public class Program
    {
        public static void Main()
        {



            //string result = PiCalculationTests.CalculateTo(100);
            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
           // Bitmap fullScreenBitmap = new Bitmap(240, 135);
            //DisplayControl.FullScreen;
            fullScreenBitmap.Clear();


            Bitmap res24 = Resources.GetBitmap(Resources.BitmapResources.Res24);

            BouncingBalls bb = new BouncingBalls(fullScreenBitmap, DisplayFont);

        }
    }
}
