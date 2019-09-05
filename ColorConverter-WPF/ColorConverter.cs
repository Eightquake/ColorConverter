using System;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    internal static class ColorConverter
    {
        private static byte ConvertAlphaStringToByte(string alphaString)
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
        public static Color ConvertFromHexString(string hexStringR, string hexStringG, string hexStringB, string hexStringA = "FF")
        {
            byte red = Convert.ToByte(hexStringR, 16),
            green = Convert.ToByte(hexStringG, 16),
            blue = Convert.ToByte(hexStringB, 16),
            alpha = Convert.ToByte(hexStringA, 16);

            return CreateColorFromRGB(red, green, blue, alpha);
        }

        public static Color ConvertFromRGBString(string rbgStringR, string rgbStringG, string rgbStringB, string rgbStringA)
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

        public static Color ConvertFromHSLString(string hslStringH, string hslStringS, string hslStringL, string hslStringA)
        {
            float hue = float.Parse(hslStringH.Replace("°", "")),
                        saturation = float.Parse(hslStringS.Replace("%", "")) / 100,
                        lightness = float.Parse(hslStringL.Replace("%", "")) / 100;

            byte alpha = ConvertAlphaStringToByte(hslStringA);

            return CreateColorFromHSL(hue, saturation, lightness, alpha);
        }

        public static Color ConvertFromRGBToHSL(byte red, byte green, byte blue, byte alpha)
        {
            double hue, saturation, lightness;
            double doubleR = red / 255.0,
                doubleG = green / 255.0,
                doubleB = blue / 255.0;

            double max = doubleR;
            if(max < doubleG)
            {
                max = doubleG;
            }
            if(max < doubleB)
            {
                max = doubleB;
            }

            double min = doubleR;
            if(min > doubleG)
            {
                min = doubleG;
            }
            if(min > doubleB)
            {
                min = doubleB;
            }

            double diff = max - min;
            lightness = (max + min) / 2;
            
            if(Math.Abs(diff) < 0.00001)
            {
                saturation = 0;
                hue = 0;
            }
            else
            {
                if(lightness <= 0.5)
                {
                    saturation = diff / (max + min);
                }
                else
                {
                    saturation = diff / (2 - max - min);
                }

                double RDist = (max - doubleR) / diff;
                double GDist = (max - doubleG) / diff;
                double BDist = (max - doubleB) / diff;

                if(doubleR == max)
                {
                    hue = BDist - GDist;
                }
                else if(doubleG == max)
                {
                    hue = 2 + RDist - BDist;
                }
                else
                {
                    hue = 4 + GDist - RDist;
                }

                hue = hue * 60;
                if(hue < 0)
                {
                    hue += 360;
                }
            }

            return CreateColorFromHSL(hue, saturation, lightness, alpha);
        }

        public static Color CreateColorFromRGB(byte red, byte green, byte blue, byte alpha)
        {
            /* Well I was going to add some exception checks here - but I realised I already use unsigned bytes so they can't be out of range. An exception would have been thrown already if that was the case */
            return Color.FromArgb(alpha, red, green, blue);
        }

        public static Color CreateColorFromHSL(double hue, double saturation, double lightness, byte alpha)
        {
            byte r, g, b;
            double p2;

            if(lightness <= 0.5)
            {
                p2 = lightness * (1 + saturation);
            }
            else
            {
                p2 = lightness + saturation - lightness * saturation;
            }

            double p1 = 2 * lightness - p2;

            double doubleR, doubleG, doubleB;
            if(saturation == 0)
            {
                doubleR = lightness;
                doubleG = lightness;
                doubleB = lightness;
            }
            else
            {
                doubleR = QqhToRGB(p1, p2, hue + 120);
                doubleG = QqhToRGB(p1, p2, hue);
                doubleB = QqhToRGB(p1, p2, hue - 120);
            }

            r = (byte)(doubleR * 255.0);
            g = (byte)(doubleG * 255.0);
            b = (byte)(doubleB * 255.0);

            return Color.FromArgb(alpha, r, g, b);
        }

        private static double QqhToRGB(double q1, double q2, double hue)
        {
            if (hue > 360)
            {
                hue -= 360;
            }
            else if (hue < 0)
            {
                hue += 360;
            }

            if (hue < 60)
            {
                return q1 + (q2 - q1) * hue / 60;
            }
            else if (hue < 180)
            {
                return q2;
            }
            else if (hue < 240)
            {
                return q1 + (q2 - q1) * (240 - hue) / 60;
            }
            else
            {
                return q1;
            }
        }

        public static void GetHSLFromColor(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness)
        {
            double doubleR = red / 255.0,
                doubleG = green / 255.0,
                doubleB = blue / 255.0;

            double max = doubleR;
            if (max < doubleG)
            {
                max = doubleG;
            }
            if (max < doubleB)
            {
                max = doubleB;
            }

            double min = doubleR;
            if (min > doubleG)
            {
                min = doubleG;
            }
            if (min > doubleB)
            {
                min = doubleB;
            }

            double diff = max - min;
            lightness = (max + min) / 2;

            if (Math.Abs(diff) < 0.00001)
            {
                saturation = 0;
                hue = 0;
            }
            else
            {
                if (lightness <= 0.5)
                {
                    saturation = diff / (max + min);
                }
                else
                {
                    saturation = diff / (2 - max - min);
                }

                double RDist = (max - doubleR) / diff;
                double GDist = (max - doubleG) / diff;
                double BDist = (max - doubleB) / diff;

                if (doubleR == max)
                {
                    hue = BDist - GDist;
                }
                else if (doubleG == max)
                {
                    hue = 2 + RDist - BDist;
                }
                else
                {
                    hue = 4 + GDist - RDist;
                }

                hue = hue * 60;
                if (hue < 0)
                {
                    hue += 360;
                }
            }
        }
    }
}