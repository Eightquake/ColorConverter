using System;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    internal static class ColorCalculator
    {
        static public Color CalculateWebsafeFromColor(Color color)
        {
            int red = color.R, green = color.G, blue = color.B, remainder = red % 51;
            if (remainder > 25)
            {
                remainder = red + 51 - remainder;
            }
            else
            {
                remainder = red - remainder;
            }
            red = remainder;
            remainder = green % 51;
            if (remainder > 25)
            {
                remainder = green + 51 - remainder;
            }
            else
            {
                remainder = green - remainder;
            }
            green = remainder;
            remainder = blue % 51;
            if (remainder > 25)
            {
                remainder = blue + 51 - remainder;
            }
            else
            {
                remainder = blue - remainder;
            }
            blue = remainder;

            return Color.FromArgb(255, (byte)red, (byte)green, (byte)blue);
        }

        static public Color CalculateComplementFromColor(Color color)
        {
            byte compR = (byte)(Math.Max(color.R, Math.Max(color.G, color.B)) + Math.Min(color.R, Math.Min(color.G, color.B)) - color.R);
            byte compG = (byte)(Math.Max(color.R, Math.Max(color.G, color.B)) + Math.Min(color.R, Math.Min(color.G, color.B)) - color.G);
            byte compB = (byte)(Math.Max(color.R, Math.Max(color.G, color.B)) + Math.Min(color.R, Math.Min(color.G, color.B)) - color.B);

            return Color.FromArgb(255, compR, compG, compB);
        }

        public static Color CalculateHarmonyColorFromColor(Color color, int index)
        {
            ColorConverter.GetHSLFromColor(color.R, color.G, color.B, out double baseHue, out double baseSat, out double baseLight);

            int thisIndex = index * 4;
            double thisHue = baseHue + thisIndex,
                   thisLight = baseLight + (thisIndex / 100.0);

            if (thisLight > 1.0) thisLight = 1.0;
            else if (thisLight < 0.0) thisLight = 0.0;

            return ColorConverter.CreateColorFromHSL(thisHue, baseSat, thisLight, 255);
        }
    }
}