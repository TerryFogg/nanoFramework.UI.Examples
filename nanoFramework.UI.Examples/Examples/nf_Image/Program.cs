using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System.Threading;

namespace nf_Image
{
    public class Program
    {
        public static void Main()
        {
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
      //          DisplayControl.FullScreen;
            fullScreenBitmap.Clear();

            byte[] nf_touchgfx = Resources.GetBytes(Resources.BinaryResources.touchgfx);

            // -- JPEGS
            int posx = 0;
            int posy = 25;
            Font fontHeading = Resources.GetFont(Resources.FontResources.ninab);
            fullScreenBitmap.DrawText($"JPEG-2Kb", fontHeading, Color.Beige, posx, posy);
            fullScreenBitmap.Flush();

            Bitmap image = Resources.GetBitmap(Resources.BitmapResources.BestCompressionLowQuality);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"JPEG-9kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.BestCompression);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"JPEG-12kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.BestQuality);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            // -- GIFS
            posx = 122;
            posy = 26;
            fullScreenBitmap.DrawText($"GIF 9kb,dith=8", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.One);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"GIF 9kb,dith=0", fontHeading, Color.Beige, posx, posy);
            posy += 15;
            image = Resources.GetBitmap(Resources.BitmapResources.Two);
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            // -- Bitmaps
            posx = 242;
            posy = 25;
            fullScreenBitmap.DrawText($"Bmp(1bit)2kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.Res1);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"Bmp(4bit)5kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.Res4);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"Bmp(8bit)10kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.Res8);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posx = 364;
            posy = 25;
            fullScreenBitmap.DrawText($"Bmp(24bit)24kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.Res8);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            posy += 68;
            fullScreenBitmap.DrawText($"Bmp(32bit)33kb", fontHeading, Color.Beige, posx, posy);
            image = Resources.GetBitmap(Resources.BitmapResources.Res8);
            posy += 15;
            fullScreenBitmap.DrawImage(posx, posy, image, 0, 0, image.Width, image.Height, 256);
            fullScreenBitmap.Flush();

            //Bitmap nanoFrameworkIcons = Resources.GetBitmap(Resources.BitmapResources.nanoframeworkingicons);
            //Bitmap classfield = Resources.GetBitmap(Resources.BitmapResources.classfield);
            Thread.Sleep(Timeout.Infinite);

        }
    }
}
