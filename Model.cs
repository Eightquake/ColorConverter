using System.Drawing;
using System.Text.RegularExpressions;

namespace ColorConverter
{
    public class Model
    {
        public Color InputColor { get; set; }
        public Color WebsafeColor { get; set; }
        public Color ComplementColor { get; set; }
        public Color[] HarmonyColors { get; set; }
        public Regex Regex { get; }

        public Model()
        {
            /* Well, this RegEx took a while to find out. It captures any supported color system in the first group, and then the parameters in seperate groups. Optionally, for color systems with alpha channel, it captures the fractional as a parameter */
            Regex = new Regex(@"(^((?:(?:#)|(?:HEX)|(?:HEXA)))[\(\s]{0,2}([0-9A-F]{2})([0-9A-F]{2})([0-9A-F]{2})[\)\s]{0,2}$)|(^((?:(?:RGBA)|(?:RGB)|(?:HSL)|(?:HSLA)))[\(\s]{0,2}(\d+%?°?)[,\s]{0,2}(\d+%?)[,\s]{0,2}(\d+%?)[,\s]{0,2}([01]?[\.\,]?\d*)?[\)\s]{0,2}?$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            /* Let's assume the color harmony should be four colors */
            HarmonyColors = new Color[] { new Color(), new Color(), new Color(), new Color() };
        }
    }
}
