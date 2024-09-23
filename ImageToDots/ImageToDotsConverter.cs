using System.Drawing;

namespace ImageToDots.ImageToDots
{
    public static class ImageToDotsConverter
    {
        ///<summary>
         ///  Image = it must be square. /\
         ///  Sections = the amount of the 'dots' per line. /\
         ///  Threshold = its a number between 0 and 100, nigga dont fuck it up with 101. /\
         ///  Threshold specifies which amount of brightness is required to put 'dot'. /\
         ///  Visca barca /\
        ///</summary>
        public static string Convret(Image image, int sections = 100, int Threshold = 10)
        {
            if (image.Width != image.Height)
            {
                return "Only squares allowed";
            }
            string result = string.Empty;
            Bitmap grayScale = GrayScaleFilter(new Bitmap(image));

            int sectionSize = (image.Width / sections);

            for (int y = 0; (y + sectionSize) < image.Width; y += sectionSize)
            {
                for (int x = 0; (x + sectionSize) < image.Width; x += sectionSize)
                {
                    result += (getAverageBrightness(x, y, sectionSize, grayScale) > ((float)Threshold / 100f)) ? "." : " ";
                }
                result += "\n";
            }

            return result;
        }

        static Bitmap GrayScaleFilter(Bitmap image)
        {
            Bitmap grayScale = new Bitmap(image.Width, image.Height);

            for (Int32 y = 0; y < grayScale.Height; y++)
                for (Int32 x = 0; x < grayScale.Width; x++)
                {
                    Color c = image.GetPixel(x, y);

                    Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
                }
            return grayScale;
        }

        static float getAverageBrightness(int xStart, int yStart, int expan, Bitmap image)
        {
            int sum = 0;
            int count = 0;
            for (int x = xStart; x < (xStart + expan); x++)
            {
                for (int y = yStart; y < (yStart + expan); y++)
                {
                    sum += (int)image.GetPixel(x, y).R;
                    count++;
                }
            }
            return ((float)(sum / count) / 255);
        }
    }
}
