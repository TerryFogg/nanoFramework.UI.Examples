using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;

namespace nf_Shapes
{
    public class Shapes
    {
        public Shapes(Bitmap fullScreenBitmap,  Font DisplayFont)
        {
            Random random = new Random();
            fullScreenBitmap.Clear();
            fullScreenBitmap.Flush();
            int xCornerRadius;
            int yCornerRadius;
            bool DrawEllipse = false;
            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    Color fillColor = (nanoFramework.Presentation.Media.Color)random.Next(0xFFFFFF);

                    if (i % 2 == 0)
                    {
                        xCornerRadius = random.Next(2, 40);
                        yCornerRadius = random.Next(2, 40);
                    }
                    else
                    {
                        xCornerRadius = 0;
                        yCornerRadius = 0;
                    }

                    if (DrawEllipse)
                    {
                        fullScreenBitmap.DrawEllipse((nanoFramework.Presentation.Media.Color)random.Next(0xFFFFFF), random.Next(1),
                            random.Next(fullScreenBitmap.Width), random.Next(fullScreenBitmap.Height - 20), random.Next(fullScreenBitmap.Width/2), random.Next(fullScreenBitmap.Height - 20),  fillColor, 0, 0, fillColor, 0, 0, (ushort)random.Next(256));
                        InformationBar.DrawInformationBar(fullScreenBitmap, DisplayFont, InfoBarPosition.bottom, $"Ellispe Number {i}");
                    }
                    else
                    {
                        fullScreenBitmap.DrawRectangle((nanoFramework.Presentation.Media.Color)random.Next(0xFFFFFF), random.Next(1),
                            random.Next(fullScreenBitmap.Width), random.Next(fullScreenBitmap.Height - 20), random.Next(fullScreenBitmap.Width), random.Next(fullScreenBitmap.Height - 20), xCornerRadius, yCornerRadius, fillColor, 0, 0, fillColor, 0, 0, (ushort)random.Next(256));
                        InformationBar.DrawInformationBar(fullScreenBitmap, DisplayFont, InfoBarPosition.bottom, $"Rectangle Number {i}");
                    }
                    fullScreenBitmap.Flush();
                }
                fullScreenBitmap.Clear();
                DrawEllipse = !DrawEllipse;
            }
        }
    }
}

