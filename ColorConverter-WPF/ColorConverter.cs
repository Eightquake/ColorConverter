using System;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    public static class ColorConverter
    {
        #region Helper methods for converters

        private static byte ConvertAlphaStringToByte(string alphaString)
        {
            byte alpha;
            if (alphaString.Length == 0)
            {
                alpha = 255;
            }
            else if (alphaString.EndsWith("%"))
            {
                alpha = (byte)(255 * (double.Parse(alphaString) / 100));
            }
            else if (alphaString.Contains(".") || alphaString.Contains(",") || alphaString == "1")
            {
                alpha = (byte)(255 * (double.Parse(alphaString.Replace(".", ","))));
            }
            else
            {
                alpha = (byte.Parse(alphaString));
            }

            return alpha;
        }

        #endregion Helper methods for converters

        #region Hex Color method to convert

        public static Color ConvertFromHexString(string hexStringR, string hexStringG, string hexStringB, string hexStringA)
        {
            byte red = Convert.ToByte(hexStringR, 16),
            green = Convert.ToByte(hexStringG, 16),
            blue = Convert.ToByte(hexStringB, 16),
            alpha;

            /* If the alpha string isn't defined, default to 255 alpha */
            if (hexStringA.Length == 0)
            {
                alpha = 255;
            }
            else
            {
                alpha = Convert.ToByte(hexStringA, 16);
            }

            return Color.FromArgb(alpha, red, green, blue);
        }

        #endregion Hex Color method to convert

        #region RGB Color method to convert

        public static Color ConvertFromRGBString(string rbgStringR, string rgbStringG, string rgbStringB, string rgbStringA)
        {
            byte red, green, blue;
            byte alpha = ConvertAlphaStringToByte(rgbStringA);

            if (rbgStringR.EndsWith("%"))
            {
                red = (byte)Math.Round(256.0D * double.Parse(rbgStringR.Replace("%", "")) / 100.0D, 0);
            }
            else
            {
                red = byte.Parse(rbgStringR);
            }

            if (rgbStringG.EndsWith("%"))
            {
                green = (byte)Math.Round(256.0D * double.Parse(rgbStringG.Replace("%", "")) / 100.0D, 0);
            }
            else
            {
                green = byte.Parse(rgbStringG);
            }

            if (rgbStringB.EndsWith("%"))
            {
                blue = (byte)Math.Round(256.0D * double.Parse(rgbStringB.Replace("%", "")) / 100.0D, 0);
            }
            else
            {
                blue = byte.Parse(rgbStringB);
            }

            return Color.FromArgb(alpha, red, green, blue);
        }

        #endregion RGB Color method to convert

        #region HSL Color methods to convert and create

        public static Color ConvertFromHSLString(string hslStringH, string hslStringS, string hslStringL, string hslStringA)
        {
            double hue = double.Parse(hslStringH.Replace("°", "")),
                        saturation = double.Parse(hslStringS.Replace("%", "")) / 100.0D,
                        lightness = double.Parse(hslStringL.Replace("%", "")) / 100.0D;

            byte alpha = ConvertAlphaStringToByte(hslStringA);

            return CreateColorFromHSL(hue, saturation, lightness, alpha);
        }

        public static Color CreateColorFromHSL(double hue, double saturation, double lightness, byte alpha)
        {
            byte red, green, blue;
            double p2;

            if (lightness <= 0.5D)
            {
                p2 = lightness * (1.0D + saturation);
            }
            else
            {
                p2 = lightness + saturation - (lightness * saturation);
            }

            double p1 = (2.0D * lightness) - p2;

            double doubleR, doubleG, doubleB;
            if (saturation == 0.0D)
            {
                doubleR = lightness;
                doubleG = lightness;
                doubleB = lightness;
            }
            else
            {
                doubleR = QqhToRGB(p1, p2, hue + 120.0D);
                doubleG = QqhToRGB(p1, p2, hue);
                doubleB = QqhToRGB(p1, p2, hue - 120.0D);
            }

            red = (byte)(doubleR * 255.0D);
            green = (byte)(doubleG * 255.0D);
            blue = (byte)(doubleB * 255.0D);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public static void GetHSLFromColor(byte red, byte green, byte blue, out double hue, out double saturation, out double lightness)
        {
            /* Code from an internet page about color theory */
            double doubleR = red / 255.0D,
                doubleG = green / 255.0D,
                doubleB = blue / 255.0D,
                max = Math.Max(doubleR, Math.Max(doubleG, doubleB)),
                min = Math.Min(doubleR, Math.Min(doubleG, doubleB));

            double diff = max - min;
            lightness = (max + min) / 2;

            if (Math.Abs(diff) < 0.00001D)
            {
                saturation = 0.0D;
                hue = 0.0D;
            }
            else
            {
                if (lightness <= 0.5D)
                {
                    saturation = diff / (max + min);
                }
                else
                {
                    saturation = diff / (2.0D - max - min);
                }

                double RMist = (max - doubleR) / diff;
                double GMist = (max - doubleG) / diff;
                double BMist = (max - doubleB) / diff;

                if (doubleR == max)
                {
                    hue = BMist - GMist;
                }
                else if (doubleG == max)
                {
                    hue = 2.0D + RMist - BMist;
                }
                else
                {
                    hue = 4.0D + GMist - RMist;
                }

                hue *= 60.0D;
                if (hue < 0.0D)
                {
                    hue += 360.0D;
                }
            }
        }

        private static double QqhToRGB(double q1, double q2, double hue)
        {
            if (hue > 360.0D)
            {
                hue -= 360.0D;
            }
            else if (hue < 0.0D)
            {
                hue += 360.0D;
            }

            if (hue < 60.0D)
            {
                return q1 + (q2 - q1) * hue / 60.0D;
            }
            else if (hue < 180.0D)
            {
                return q2;
            }
            else if (hue < 240.0D)
            {
                return q1 + (q2 - q1) * (240.0D - hue) / 60.0D;
            }
            else
            {
                return q1;
            }
        }

        #endregion HSL Color methods to convert and create

        #region HSV Color methods to convert and create

        public static Color ConvertFromHSVString(string hsvStringH, string hsvStringS, string hsvStringL, string hsvStringA)
        {
            double hue = double.Parse(hsvStringH.Replace("°", "")),
                        saturation = double.Parse(hsvStringS.Replace("%", "")) / 100.0D,
                        value = double.Parse(hsvStringL.Replace("%", "")) / 100.0D;

            byte alpha = ConvertAlphaStringToByte(hsvStringA);

            return CreateColorFromHSV(hue, saturation, value, alpha);
        }

        public static Color CreateColorFromHSV(double hue, double saturation, double value, byte alpha)
        {
            /* Code from a webpage about converting between different color systems */
            byte red, green, blue;
            double doubleR, doubleG, doubleB;
            double i, f, p, q, t;

            if (saturation == 0.0D)
            {
                doubleR = value;
                doubleG = value;
                doubleB = value;
            }
            else
            {
                hue /= 60.0D;
                i = Math.Floor(hue);
                f = hue - i;
                p = value * (1 - saturation);
                q = value * (1 - saturation * f);
                t = value * (1 - saturation * (1 - f));

                switch (i)
                {
                    case 0:
                        doubleR = value;
                        doubleG = t;
                        doubleB = p;
                        break;

                    case 1:
                        doubleR = q;
                        doubleG = value;
                        doubleB = p;
                        break;

                    case 2:
                        doubleR = p;
                        doubleG = value;
                        doubleB = t;
                        break;

                    case 3:
                        doubleR = p;
                        doubleG = q;
                        doubleB = value;
                        break;

                    case 4:
                        doubleR = t;
                        doubleG = p;
                        doubleB = value;
                        break;

                    default:
                        doubleR = value;
                        doubleG = p;
                        doubleB = q;
                        break;
                }
            }

            red = (byte)(doubleR * 255.0D);
            green = (byte)(doubleG * 255.0D);
            blue = (byte)(doubleB * 255.0D);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public static void GetHSVFromColor(byte red, byte green, byte blue, out double hue, out double saturation, out double value)
        {
            /* Code from a StackOverflow answer */
            double doubleR = red / 255.0D,
                doubleG = green / 255.0D,
                doubleB = blue / 255.0D,
                max = Math.Max(doubleR, Math.Max(doubleG, doubleB)),
                min = Math.Min(doubleR, Math.Min(doubleG, doubleB));

            value = max;
            double delta = max - min;

            if (Math.Abs(delta) < 0.00001D)
            {
                saturation = 0;
                hue = 0; /* Hue doesn't matter when saturation is 0 */
            }
            else
            {
                if (max > 0.0D)
                {
                    saturation = (delta / max);
                }
                else
                {
                    /* If max is 0 then all of the RGB channels are 0 */
                    saturation = 0;
                    hue = 0;
                    return;
                }

                if (doubleR >= max)
                {
                    hue = (doubleG - doubleB) / delta;
                }
                else
                {
                    if (doubleG >= max)
                    {
                        hue = 2.0D + (doubleB - doubleR) / delta;
                    }
                    else
                    {
                        hue = 4.0D + (doubleR - doubleG) / delta;
                    }
                }

                hue *= 60.0D;

                if (hue < 0.0D)
                {
                    hue += 360.0D;
                }
            }
        }

        #endregion HSV Color methods to convert and create
    }
}