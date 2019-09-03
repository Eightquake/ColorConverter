using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    class InputChecker
    {
        private readonly Regex Regex;
        public InputChecker()
        {
            Regex = new Regex(@"(^((?:(?:#)|(?:HEX)|(?:HEXA)))[\(\s]{0,2}([0-9A-F]{2})([0-9A-F]{2})([0-9A-F]{2})[\)\s]{0,2}$)|(^((?:(?:RGBA)|(?:RGB)|(?:HSL)|(?:HSLA)))[\(\s]{0,2}(\d+%?°?)[,\s]{0,2}(\d+%?)[,\s]{0,2}(\d+%?)[,\s]{0,2}([01]?[\.\,]?\d*)?[\)\s]{0,2}?$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        public Color TestRegex(string enteredstring)
        {
            MatchCollection matches = Regex.Matches(enteredstring);
            if (matches.Count > 0)
            {
                byte red = 0, green = 0, blue = 0;

                // I only really care about the first Full match, maybe the user entered more than one supported color but currently the program doesn't support that
                Match match = matches[0];

                string colorSystem = "";

                if (match.Groups[2].Value.Length > 0)
                {
                    colorSystem = match.Groups[2].Value.ToLower();
                }
                else if (match.Groups[7].Value.Length > 0)
                {
                    colorSystem = match.Groups[7].Value.ToLower();
                }

                if (colorSystem == "#" || colorSystem == "hex" || colorSystem == "hexa")
                {
                    // The user entered a color using either # or HEX(). HEXA isn't supported right now.
                    red = Convert.ToByte(match.Groups[3].Value, 16);
                    green = Convert.ToByte(match.Groups[4].Value, 16);
                    blue = Convert.ToByte(match.Groups[5].Value, 16);
                }
                else if (colorSystem == "rgb" || colorSystem == "rgba")
                {
                    // The user entered a color using RGB, let's create a color using Color.FromArgb but set alpha as 255
                    if (match.Groups[8].Value.EndsWith("%"))
                    {
                        red = (byte)(255 * int.Parse(match.Groups[8].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        red = byte.Parse(match.Groups[8].Value);
                    }

                    if (match.Groups[9].Value.EndsWith("%"))
                    {
                        green = (byte)(255 * int.Parse(match.Groups[9].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        green = byte.Parse(match.Groups[9].Value);
                    }

                    if (match.Groups[10].Value.EndsWith("%"))
                    {
                        blue = (byte)(255 * byte.Parse(match.Groups[10].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        blue = byte.Parse(match.Groups[10].Value);
                    }
                }
                else if (colorSystem == "hsl" || colorSystem == "hsla")
                {
                    float hue = float.Parse(match.Groups[8].Value.Replace("°", "")),
                        saturation = float.Parse(match.Groups[9].Value.Replace("%", "")) / 100,
                        lightness = float.Parse(match.Groups[10].Value.Replace("%", "")) / 100;

                    Color hslColor = new Color();
                    try
                    {
                        /*hslColor = CreateColorFromHsl(hue, saturation, lightness);
                        red = hslColor.R;
                        green = hslColor.G;
                        blue = hslColor.B;*/
                    }
                    catch (ArgumentException e)
                    {

                    }
                }
                decimal alpha;
                if (colorSystem == "rgba" || colorSystem == "hsla")
                {
                    if (match.Groups[11].Value.Length == 0)
                    {
                        alpha = 255.0M;
                    }
                    else if (match.Groups[11].Value.EndsWith("%"))
                    {
                        alpha = 255 * (decimal.Parse(match.Groups[11].Value) / 100);
                    }
                    else if (match.Groups[11].Value.Contains(".") || match.Groups[11].Value.Contains(",") || match.Groups[11].Value == "1")
                    {
                        alpha = 255 * (decimal.Parse(match.Groups[11].Value.Replace(".", ",")));
                    }
                    else
                    {
                        alpha = (decimal.Parse(match.Groups[11].Value));
                    }
                }
                else
                {
                    alpha = 255.0M;
                }

                Color convertedColor = new Color();

                try
                {
                    convertedColor = Color.FromArgb((byte)alpha, red, green, blue);
                    //UpdateAllColors(convertedColor);
                }
                catch (ArgumentException e)
                {

                    return new Color();
                }
                return convertedColor;

            }

            return new Color();
        }
    }
}
