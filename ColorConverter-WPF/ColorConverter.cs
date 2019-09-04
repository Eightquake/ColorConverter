using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    static class ColorConverter
    {
        static public Color ConvertFromHexString(string hexStringR, string hexStringG, string hexStringB, string hexStringA = "FF")
        {
            byte red = Convert.ToByte(hexStringR, 16),
            green = Convert.ToByte(hexStringG, 16),
            blue = Convert.ToByte(hexStringB, 16),
            alpha = Convert.ToByte(hexStringA, 16);

            return CreateColorFromRGB(red, green, blue, alpha);
        }
        static public Color ConvertFromRGBString(string rbgStringR, string rgbStringG, string rgbStringB, string rgbStringA)
        {
            byte red, green, blue;
            byte alpha = ConvertAlphaStringToByte(rgbStringA);

            if (rbgStringR.EndsWith("%"))
            {
                red = (byte)(255 * int.Parse(rbgStringR.Replace("%", "")) / 100);
            }
            else
            {
                red = byte.Parse(rbgStringR);
            }

            if (rgbStringG.EndsWith("%"))
            {
                green = (byte)(255 * int.Parse(rgbStringG.Replace("%", "")) / 100);
            }
            else
            {
                green = byte.Parse(rgbStringG);
            }

            if (rgbStringB.EndsWith("%"))
            {
                blue = (byte)(255 * int.Parse(rgbStringB.Replace("%", "")) / 100);
            }
            else
            {
                blue = byte.Parse(rgbStringB);
            }

            return CreateColorFromRGB(red, green, blue, alpha);
        }
        static public Color ConvertFromHSLString(string hslStringH, string hslStringS, string hslStringL, string hslStringA)
        {
            float hue = float.Parse(hslStringH.Replace("°", "")),
                        saturation = float.Parse(hslStringS.Replace("%", "")) / 100,
                        lightness = float.Parse(hslStringL.Replace("%", "")) / 100;

            byte alpha = ConvertAlphaStringToByte(hslStringA);

            return CreateColorFromHSL(hue, saturation, lightness, alpha);
        }
        static public Color CreateColorFromRGB(byte red, byte green, byte blue, byte alpha)
        {
            /* Well I was going to add some exception checks here - but I realised I already use unsigned bytes so they can't be out of range. An exception would have been thrown already if that was the case */
            return Color.FromArgb(alpha, red, green, blue);
        }
        static public Color CreateColorFromHSL(float hue, float saturation, float lightness, byte alpha)
        {
            if (hue < 0 || hue > 360)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter hue. Hue needs to be between 0 and 360, inclusive.", hue), "hue");
            }
            if (saturation < 0.0f || saturation > 1.0f)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter saturation. Saturation needs to be between 0 and 1, inclusive.", saturation), "saturation");
            }
            if (lightness < 0.0f || lightness > 1.0f)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter lightness. Lightness needs to be between 0 and 1, inclusive.", lightness), "lightness");
            }

            float hslred = 0,
                hslgreen = 0,
                hslblue = 0;

            /* I found this code online in a post for converting between color systems. */
            float chroma = (1 - Math.Abs(2 * lightness - 1)) * saturation,
                second = chroma * (1 - Math.Abs((hue / 60) % 2 - 1)),
                matchlight = lightness - chroma / 2;
            if (0 <= hue && hue < 60)
            {
                hslred = chroma;
                hslgreen = second;
                hslblue = 0;
            }
            else if (60 <= hue && hue < 120)
            {
                hslred = second;
                hslgreen = chroma;
                hslblue = 0;
            }
            else if (120 <= hue && hue < 180)
            {
                hslred = 0;
                hslgreen = chroma;
                hslblue = second;
            }
            else if (180 <= hue && hue < 240)
            {
                hslred = 0;
                hslgreen = second;
                hslblue = chroma;
            }
            else if (240 <= hue && hue < 300)
            {
                hslred = second;
                hslgreen = 0;
                hslblue = chroma;
            }
            else if (300 <= hue && hue <= 360)
            {
                hslred = chroma;
                hslgreen = 0;
                hslblue = second;
            }

            byte red = (byte)Math.Round((hslred + matchlight) * 255.0f),
                green = (byte)Math.Round((hslgreen + matchlight) * 255.0f),
                blue = (byte)Math.Round((hslblue + matchlight) * 255.0f);

            return CreateColorFromRGB(red, green, blue, alpha);
        }
        static private byte ConvertAlphaStringToByte(string alphaString)
        {
            byte alpha;
            if (alphaString.Length == 0)
            {
                alpha = 255;
            }
            else if (alphaString.EndsWith("%"))
            {
                alpha = (byte)(255 * (decimal.Parse(alphaString) / 100));
            }
            else if (alphaString.Contains(".") || alphaString.Contains(",") || alphaString == "1")
            {
                alpha = (byte)(255 * (decimal.Parse(alphaString.Replace(".", ","))));
            }
            else
            {
                alpha = (byte.Parse(alphaString));
            }

            return alpha;
        }
    }
}
