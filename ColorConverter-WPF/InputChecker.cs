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
    static class InputChecker
    {
        static private readonly Regex Regex = new Regex(@"(^((?:(?:#)|(?:HEX)|(?:HEXA)))[\(\s]{0,2}([0-9A-F]{2})([0-9A-F]{2})([0-9A-F]{2})[\)\s]{0,2}$)|(^((?:(?:RGBA)|(?:RGB)|(?:HSL)|(?:HSLA)))[\(\s]{0,2}(\d+%?°?)[,\s]{0,2}(\d+%?)[,\s]{0,2}(\d+%?)[,\s]{0,2}([01]?[\.\,]?\d*)?[\)\s]{0,2}?$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static public Color TestRegex(string enteredstring)
        {
            MatchCollection matches = Regex.Matches(enteredstring);
            if (matches.Count > 0)
            {
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

                try
                {
                    if (colorSystem == "#" || colorSystem == "hex" || colorSystem == "hexa")
                    {
                        // The user entered a color using either # or HEX(). Alpha from HEXA isn't supported right now.
                        return ColorConverter.ConvertFromHexString(match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value);
                    }
                    else if (colorSystem == "rgb" || colorSystem == "rgba")
                    {
                        // The user entered a color using RGB
                        return ColorConverter.ConvertFromRGBString(match.Groups[8].Value, match.Groups[9].Value, match.Groups[10].Value, match.Groups[11].Value);
                    }
                    else if (colorSystem == "hsl" || colorSystem == "hsla")
                    {
                        // The user entered a color using HSL or HSLA
                        return ColorConverter.ConvertFromHSLString(match.Groups[8].Value, match.Groups[9].Value, match.Groups[10].Value, match.Groups[11].Value);
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine(String.Format("Caught exception while trying to convert string to color, error: {0}", e));
                }
            }

            return new Color();
        }
    }
}
