using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColorConverter
{
    public class Presenter
    {
        private Model model;
        private View view;

        public Presenter(Model theModel)
        {
            model = theModel;
        }
        public void SetView(View theView)
        {
            view = theView;
        }
        #region My methods
        public void CheckClipBoard()
        {
            /* Try to read from clipboard and use that to check if it's a color */
            if (Clipboard.ContainsText())
            {
                string clipboard = Clipboard.GetText();
                if (model.Regex.IsMatch(clipboard))
                {
                    view.SetColorInputBoxText(clipboard);
                    TestRegex(clipboard);
                }
            }
        }
        public void CompPicture_Click()
        {
            /* Create a string in the format of #RRGGBB, remove the first two as the Color class uses #AARRGGBB */
            string colorstring = "#" + model.ComplementColor.Name.Remove(0, 2).ToUpper();
            view.SetColorInputBoxText(colorstring);
            TestRegex(colorstring);
        }
        /// <summary>
        /// Tests the regex and if a match is found it tries to create a color from the match
        /// </summary>
        /// <param name="enteredstring">the string to use as input</param>
        public void TestRegex(string enteredstring)
        {
            MatchCollection matches = model.Regex.Matches(enteredstring);
            if (matches.Count > 0)
            {
                int red = 0, green = 0, blue = 0;
                decimal alpha = 0;

                /* I only really care about the first Full match, maybe the user entered more than one supported color but currently the program doesn't support that */
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
                    /* The user entered a color using either # or HEX(). HEXA isn't supported right now. */
                    red = Convert.ToInt32(match.Groups[3].Value, 16);
                    green = Convert.ToInt32(match.Groups[4].Value, 16);
                    blue = Convert.ToInt32(match.Groups[5].Value, 16);
                }
                else if (colorSystem == "rgb" || colorSystem == "rgba")
                {
                    /* The user entered a color using RGB, let's create a color using Color.FromArgb but set alpha as 255 */
                    if (match.Groups[8].Value.EndsWith("%"))
                    {
                        red = 255 * (int.Parse(match.Groups[8].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        red = int.Parse(match.Groups[8].Value);
                    }

                    if (match.Groups[9].Value.EndsWith("%"))
                    {
                        green = 255 * (int.Parse(match.Groups[9].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        green = int.Parse(match.Groups[9].Value);
                    }

                    if (match.Groups[10].Value.EndsWith("%"))
                    {
                        blue = 255 * (int.Parse(match.Groups[10].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        blue = int.Parse(match.Groups[10].Value);
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
                        hslColor = CreateColorFromHsl(hue, saturation, lightness);
                        red = hslColor.R;
                        green = hslColor.G;
                        blue = hslColor.B;
                    }
                    catch (ArgumentException e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                    convertedColor = Color.FromArgb((int)alpha, red, green, blue);
                    UpdateAllColors(convertedColor);
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
        /// <summary>
        /// Creates a new Color based on the parameters as a HSL color system
        /// </summary>
        /// <param name="hue">the hue, between 0 and 255 (inclusive)</param>
        /// <param name="saturation">the saturation, between 0.0 and 1.0 (inclusive)</param>
        /// <param name="lightness">the lightness, between 0.0 and 1.0 (inclusive)</param>
        /// <returns>the new color</returns>
        private Color CreateColorFromHsl(float hue, float saturation, float lightness)
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
            else if (300 <= hue && hue < 360)
            {
                hslred = chroma;
                hslgreen = 0;
                hslblue = second;
            }

            int red = (int)Math.Round((hslred + matchlight) * 255.0f),
                green = (int)Math.Round((hslgreen + matchlight) * 255.0f),
                blue = (int)Math.Round((hslblue + matchlight) * 255.0f);

            return Color.FromArgb(red, green, blue);
        }
        /// <summary>
        /// Calculates the websafe version of a color in RGB.
        /// </summary>
        /// <param name="red">the red channel, between 0 and 255 (inclusive)</param>
        /// <param name="green">the green channel, between 0 and 255 (inclusive)</param>
        /// <param name="blue">the blue channel, between 0 and 255 (inclusive)</param>
        /// <returns>the websafe color calculated</returns>
        private Color CreateWebsafeFromRgb(int red, int green, int blue)
        {
            if (red < 0 || red > 255)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter red. Red needs to be between 0 and 255, inclusive.", red), "red");
            }
            if (green < 0 || green > 255)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter green. Green needs to be between 0 and 255, inclusive.", green), "green");
            }
            if (blue < 0 || blue > 255)
            {
                throw new ArgumentException(string.Format("The value {0} is not a valid value for parameter blue. Blue needs to be between 0 and 255, inclusive.", blue), "blue");
            }

            int remainder;
            remainder = red % 51;
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

            return Color.FromArgb(red, green, blue);
        }
        #region Methods for updating all of the texts and pictureboxes
        private void UpdateAllColors(Color color)
        {
            UpdateColorTexts(color);
            ChangeColorBox(color);
        }
        private void ChangeColorBox(Color color)
        {
            model.InputColor = color;
            view.Refresh();
        }
        private void UpdateColorTexts(Color color)
        {
            UpdateHexText(color);
            UpdateRGBText(color);
            UpdateHslText(color);
            UpdateWebsafeColor(color);
            UpdateComplementaryText(color);
            UpdateColorHarmonyText(color);
        }
        /// <summary>
        /// Updates the correct textbox based on the color supplied.
        /// </summary>
        /// <param name="color">the color to use</param>
        private void UpdateHexText(Color color)
        {
            string red = color.R.ToString("X2");
            string green = color.G.ToString("X2");
            string blue = color.B.ToString("X2");
            string alpha = color.A.ToString("X2");

            string text = string.Format("#RRGGBB\t#{0}{1}{2}", red, green, blue) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("#RRGGBBAA\t#{0}{1}{2}{3}", red, green, blue, alpha);

            view.SetHexBoxText(text);
        }
        /// <summary>
        /// Updates the correct textbox based on the color supplied.
        /// </summary>
        /// <param name="color">the color to use</param>
        private void UpdateRGBText(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            decimal alpha = Math.Round(Convert.ToDecimal(color.A / 255M), 1);

            int redpercentage = (color.R / 255 * 100);
            int greenpercentage = (color.G / 255 * 100);
            int bluepercentage = (color.B / 255 * 100);
            int alphapercentage = (color.A / 255 * 100);

            string text = string.Format("RGB({0}, {1}, {2})", red, green, blue) +
            string.Format("{0}", Environment.NewLine) +
            string.Format("RGB({0}%, {1}%, {2}%)", redpercentage, greenpercentage, bluepercentage) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("RGBA({0}, {1}, {2}, {3}){5}RGBA({0}, {1}, {2}, {4})", red, green, blue, color.A, alpha, Environment.NewLine) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("RGBA({0}%, {1}%, {2}%, {3}%){5}RGBA({0}%, {1}%, {2}%, {4})", redpercentage, greenpercentage, bluepercentage, alphapercentage, alpha, Environment.NewLine) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("ARGB({3}, {0}, {1}, {2}){5}ARGB({4}, {0}, {1}, {2})", red, green, blue, color.A, alpha, Environment.NewLine) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("ARGB({3}%, {0}%, {1}%, {2}%){5}ARGB({4}, {0}%, {1}%, {2})", redpercentage, greenpercentage, bluepercentage, alphapercentage, alpha, Environment.NewLine);

            view.SetRGBBoxText(text);

        }
        /// <summary>
        /// Updates the correct textbox based on the color supplied.
        /// </summary>
        /// <param name="color">the color to use</param>
        private void UpdateHslText(Color color)
        {
            /* Wait, Color has HSL/HSB values? I don't need to calculate them myself then */

            int hue = (int)color.GetHue();
            int saturation = (int)(color.GetSaturation() * 100);
            int lightness = (int)(color.GetBrightness() * 100);
            decimal alpha = Math.Round(Convert.ToDecimal(color.A / 255M), 1);

            string text = string.Format("HSL({0}, {1}, {2})", hue, saturation, lightness) +
            string.Format("{0}", Environment.NewLine) +
            string.Format("HSL({0}, {1}%, {2}%)", hue, saturation, lightness) +
            string.Format("{0}", Environment.NewLine) +
            string.Format("HSL({0}°, {1}%, {2}%)", hue, saturation, lightness) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("HSLA({0}, {1}, {2}, {3})", hue, saturation, lightness, alpha) +
            string.Format("{0}", Environment.NewLine) +
            string.Format("HSLA({0}, {1}%, {2}%, {3})", hue, saturation, lightness, alpha) +
            string.Format("{0}", Environment.NewLine) +
            string.Format("HSLA({0}°, {1}%, {2}%, {3})", hue, saturation, lightness, alpha);

            view.SetHSLBoxText(text);
        }
        /// <summary>
        /// Calculates the websafe color version of the supplied color and adds it to the textbox and picturebox.
        /// </summary>
        /// <param name="color">the color to calculate the websafe color from</param>
        private void UpdateWebsafeColor(Color color)
        {
            Color websafeColor = CreateWebsafeFromRgb(color.R, color.G, color.B);
            model.WebsafeColor = websafeColor;

            string text = string.Format("#{0}{1}{2}", websafeColor.R.ToString("X2"), websafeColor.G.ToString("X2"), websafeColor.B.ToString("X2")) +
            string.Format("{0}{0}", Environment.NewLine) +
            string.Format("RGB({0}, {1}, {2})", websafeColor.R, websafeColor.G, websafeColor.B);

            view.SetWebsafeBoxText(text);
        }
        /// <summary>
        /// Calculates the complementary color of the supplied color and adds it to the textbox and picturebox.
        /// </summary>
        /// <param name="color">the color to calculate the complementary color from</param>
        private void UpdateComplementaryText(Color color)
        {
            float hue = (color.GetHue() + 180.0f) % 360.0f;
            Color compColor = CreateColorFromHsl(hue, color.GetSaturation(), color.GetBrightness());

            model.ComplementColor = compColor;

            view.SetCompBoxText(string.Format("#{0}{1}{2}", compColor.R.ToString("X2"), compColor.G.ToString("X2"), compColor.B.ToString("X2")));
        }
        /// <summary>
        /// Creates an analogous color harmony based on a color and adds them to the textboxes and pictureboxes. The number of colors it creates is dependent on the amount of textboxes for the color harmony. 
        /// It creates the color by stepping an equal amount of way away from the original color or the color created before it, on the color wheel. It will wrap around if larger than 360 or smaller than 0.
        /// </summary>
        /// <param name="color">the color to base the color harmony on</param>
        private void UpdateColorHarmonyText(Color color)
        {
            int length = view.GetColorHarmonyLength();
            int distance = 6;
            int distanceIndex = -(distance / (length - 1));

            for (int i = 0; i < length; i++)
            {
                if (distanceIndex == 0) distanceIndex++;

                int thisDistance = distance * distanceIndex++;

                /* Well apparently modulo is not the same in C# as it usually is in programming, so here's the correct calculation */
                int thisHue = (int)Math.Round((color.GetHue() - thisDistance) - 360.0f * (float)Math.Floor((color.GetHue() - thisDistance) / 360.0f));

                Color thisColor = CreateColorFromHsl(thisHue, color.GetSaturation(), color.GetBrightness());

                model.HarmonyColors[i] = thisColor;

                view.SetHarmonyBoxText(i + 1, string.Format("#{0}{1}{2}", thisColor.R.ToString("X2"), thisColor.G.ToString("X2"), thisColor.B.ToString("X2")));
            }
        }
        #endregion
        #endregion
        #region Getters and setters
        public Color GetInputColor()
        {
            return model.InputColor;
        }
        public Color GetWebsafeColor()
        {
            return model.WebsafeColor;
        }
        public Color GetComplementColor()
        {
            return model.ComplementColor;
        }
        public Color[] GetHarmonyColors()
        {
            return model.HarmonyColors;
        }
        public Color GetHarmonyColors(int index)
        {
            return model.HarmonyColors[index];
        }
        #endregion
    }
}
