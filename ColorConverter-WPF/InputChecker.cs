using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    internal static class InputChecker
    {
        static private readonly Regex Regex = new Regex(@"(^((?:(?:#)|(?:HEX)|(?:HEXA)))[\(\s]{0,2}([0-9A-F]{2})([0-9A-F]{2})([0-9A-F]{2})[\)\s]{0,2}$)|(^((?:(?:RGBA)|(?:RGB)|(?:HSLA)|(?:HSL)|(?:HSVA)|(?:HSV)))[\(\s]{0,2}(\d+%?°?)[,\s]{0,2}(\d+%?)[,\s]{0,2}(\d+%?)[,\s]{0,2}([01]?[\.\,]?\d*)?[\)\s]{0,2}?$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        static public Color TestRegex(string enteredstring)
        {
            MatchCollection matches = Regex.Matches(enteredstring);
            if (matches.Count > 0)
            {
                // I only really care about the first Full match, maybe the user entered more than one supported color but currently the program doesn't support that
                Match match = matches[0];

                // Save the color system in the input as a string
                string colorSystem = "";
                // Save the input parameters as a string instead of using the match.Groups[x].Value over and over
                string inputParamter1 = "", inputParameter2 = "", inputParameter3 = "", inputParameter4 = "";

                if (match.Groups[2].Value.Length > 0)
                {
                    colorSystem = match.Groups[2].Value.ToLower();
                    inputParamter1 = match.Groups[3].Value;
                    inputParameter2 = match.Groups[4].Value;
                    inputParameter3 = match.Groups[5].Value;
                }
                else if (match.Groups[7].Value.Length > 0)
                {
                    colorSystem = match.Groups[7].Value.ToLower();
                    inputParamter1 = match.Groups[8].Value;
                    inputParameter2 = match.Groups[9].Value;
                    inputParameter3 = match.Groups[10].Value;
                    inputParameter4 = match.Groups[11].Value;
                }

                try
                {
                    if (colorSystem == "#" || colorSystem == "hex" || colorSystem == "hexa")
                    {
                        // The user entered a color using either # or HEX(). Alpha from HEXA isn't supported right now.
                        return ColorConverter.ConvertFromHexString(inputParamter1, inputParameter2, inputParameter3, inputParameter4);
                    }
                    else if (colorSystem == "rgb" || colorSystem == "rgba")
                    {
                        // The user entered a color using RGB
                        return ColorConverter.ConvertFromRGBString(inputParamter1, inputParameter2, inputParameter3, inputParameter4);
                    }
                    else if (colorSystem == "hsl" || colorSystem == "hsla")
                    {
                        // The user entered a color using HSL or HSLA
                        return ColorConverter.ConvertFromHSLString(inputParamter1, inputParameter2, inputParameter3, inputParameter4);
                    }
                    else if (colorSystem == "hsv" || colorSystem == "hsva")
                    {
                        // The user entered a color using HSV or HSVA
                        return ColorConverter.ConvertFromHSVString(inputParamter1, inputParameter2, inputParameter3, inputParameter4);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(String.Format("Caught exception while trying to convert string to color, error: {0}", e));
                }
            }

            return new Color();
        }
    }
}