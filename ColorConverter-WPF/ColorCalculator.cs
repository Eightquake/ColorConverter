﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    static class ColorCalculator
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
    }
}
