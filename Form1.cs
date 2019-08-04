using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ColorConverter
{
    public partial class Form1 : Form
    {
        private Color inputColor;
        private Color createdwebsafeColor;
        private Color createdComplementColor;
        private static Regex allSupportedRegex;

        public Form1()
        {
            InitializeComponent();
        }
        /** Form events here **/
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Form1_Load does not happen when this.refresh() is called in changeColorBox - that's a good thing as this only needs to be run once */

            /* Well, this RegEx took a while to find out. It captures any supported color system in the first group, and then the parameters in seperate groups. Optionally, for color systems with alpha channel, it captures the fractional as a parameter */
            allSupportedRegex = new Regex(@"^((?:#)|(?:HEX)|(?:RGBA)|(?:RGB)|(?:HSL))[\(\s]?((?:\d+%?)|[0-9A-F]{2}),?\s?((?:\d+%?)|[0-9A-F]{2}),?\s?((?:\d+%?)|[0-9A-F]{2}),?\s?(0?[\.\,]?\d*)?[\)\s]?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void Form1_GotFocus(object sender, EventArgs e)
        {
            CheckClipBoard();
        }
        private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowWindowAgain();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindowAgain();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckerboardPictureBox_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(inputColor);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 200));
            brush.Dispose();
        }

        private void WebsafePictureBox_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(createdwebsafeColor);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 235, 82));
            brush.Dispose();
        }

        private void CompPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(createdComplementColor);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 100, 50));
            brush.Dispose();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            TestRegex(colorInputBox.Text);
        }

        /** Private methods here **/
        private void ShowWindowAgain()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void CheckClipBoard()
        {
            String clipboard;
            /* Try to read from clipboard and use that to check if it's a color */
            if (Clipboard.ContainsText())
            {
                clipboard = Clipboard.GetText();
                if (allSupportedRegex.IsMatch(clipboard))
                {
                    colorInputBox.Text = clipboard;
                    TestRegex(clipboard);
                }
            }
            
        }

        private void TestRegex(String enteredString)
        {
            MatchCollection matches = allSupportedRegex.Matches(enteredString);
            if (matches.Count > 0)
            {
                int red = 0, green = 0, blue = 0;
                decimal alpha = 0;

                /* I only really care about the first Full match */
                Match match = matches[0];
                String colorSystem = match.Groups[1].Value.ToLowerInvariant();
                int count = 0;
                foreach(Group group in match.Groups)
                {
                    Debug.WriteLine("Group: {0}  Match: {1}", count++, group);
                }

                if (colorSystem == "#" || colorSystem == "hex")
                {
                    /* The user entered a color using either # or HEX(). ColorTranslator supports hex right out of the box so I don't need to convert it. I know that groups 7, 8, 9 are the ones that captured the parameters so let's use them */
                    //convertedColor = System.Drawing.ColorTranslator.FromHtml("#" + match.Groups[2] + match.Groups[3] + match.Groups[4]);
                    red = Convert.ToInt32(match.Groups[2].Value, 16);
                    green = Convert.ToInt32(match.Groups[3].Value, 16);
                    blue = Convert.ToInt32(match.Groups[4].Value, 16);
                }
                else if (colorSystem == "rgb" || colorSystem == "rgba")
                {
                    /* The user entered a color using RGB, let's create a color using Color.FromArgb but set alpha as 255 */
                    if(match.Groups[2].Value.EndsWith("%"))
                    {
                        red = 255 * (int.Parse(match.Groups[2].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        red = int.Parse(match.Groups[2].Value);
                    }

                    if (match.Groups[3].Value.EndsWith("%"))
                    {
                        green = 255 * (int.Parse(match.Groups[3].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        green = int.Parse(match.Groups[3].Value);
                    }

                    if (match.Groups[4].Value.EndsWith("%"))
                    {
                        blue = 255 * (int.Parse(match.Groups[4].Value.Replace("%", "")) / 100);
                    }
                    else
                    {
                        blue = int.Parse(match.Groups[4].Value);
                    }
                }
                else if (colorSystem == "hsl" || colorSystem == "hsla")
                {
                    float hue = float.Parse(match.Groups[2].Value);
                    float saturation = float.Parse(match.Groups[3].Value) / 100;
                    float lightness = float.Parse(match.Groups[4].Value) / 100;

                    Color hslColor = CreateColorFromHsl(hue, saturation, lightness);
                    red = hslColor.R;
                    green = hslColor.G;
                    blue = hslColor.B;
                }
                if(colorSystem == "rgba" || colorSystem == "hsla")
                {
                    if (match.Groups[5].Value.EndsWith("%"))
                    {
                        alpha = 255 * (decimal.Parse(match.Groups[5].Value) / 100);
                    }
                    else if (match.Groups[5].Value.Contains(".") || match.Groups[5].Value.Contains(","))
                    {
                        alpha = 255 * (decimal.Parse(match.Groups[5].Value.Replace(".", ",")));
                    }
                    else
                    {
                        alpha = (decimal.Parse(match.Groups[5].Value));
                    }
                }
                else
                {
                    alpha = 255.0M;
                }


                Color convertedColor = Color.FromArgb((int)alpha, red, green, blue);
                Color websafeColor = createWebsafeFromRgb(red, green, blue);

                UpdateAllColors(convertedColor, websafeColor);
            }
            else
            {
                /* There was no match for the string provided - let the user know this. */
            }
        }

        private Color CreateColorFromHsl(float hue, float saturation, float lightness)
        {
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
        private Color createWebsafeFromRgb(int red, int green, int blue)
        {
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

        private void UpdateAllColors(Color color, Color websafeColor)
        {
            UpdateColorTexts(color, websafeColor);
            ChangeColorBox(color, websafeColor);
        }

        private void ChangeColorBox(Color color, Color websafeColor)
        {
            inputColor = color;
            this.Refresh();
        }

        private void UpdateColorTexts(Color color, Color websafeColor)
        {
            UpdateHexText(color);
            UpdateRGBText(color);
            UpdateHslText(color);
            UpdateWebsafeColor(websafeColor);
            UpdateComplementaryText(color);
        }

        private void UpdateHexText(Color color)
        {
            String red = color.R.ToString("X2");
            String green = color.G.ToString("X2");
            String blue = color.B.ToString("X2");
            String alpha = color.A.ToString("X2");

            hexBox.Text = "";
            hexBox.AppendText(String.Format("#RRGGBB\t#{0}{1}{2}", red, green, blue));
            hexBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            hexBox.AppendText(String.Format("#RRGGBBAA\t#{0}{1}{2}{3}", red, green, blue, alpha));
        }

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

            rgbBox.Text = "";
            rgbBox.AppendText(String.Format("RGB({0}, {1}, {2})", red, green, blue));
            rgbBox.AppendText(String.Format("{0}", Environment.NewLine));
            rgbBox.AppendText(String.Format("RGB({0}%, {1}%, {2}%)", redpercentage, greenpercentage, bluepercentage));
            rgbBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            rgbBox.AppendText(String.Format("RGBA({0}, {1}, {2}, {3}){5}RGBA({0}, {1}, {2}, {4})", red, green, blue, color.A, alpha, Environment.NewLine));
            rgbBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            rgbBox.AppendText(String.Format("RGBA({0}%, {1}%, {2}%, {3}%){5}RGBA({0}%, {1}%, {2}%, {4})", redpercentage, greenpercentage, bluepercentage, alphapercentage, alpha, Environment.NewLine));
            rgbBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            rgbBox.AppendText(String.Format("ARGB({3}, {0}, {1}, {2}){5}ARGB({4}, {0}, {1}, {2})", red, green, blue, color.A, alpha, Environment.NewLine));
            rgbBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            rgbBox.AppendText(String.Format("ARGB({3}%, {0}%, {1}%, {2}%){5}ARGB({4}, {0}%, {1}%, {2})", redpercentage, greenpercentage, bluepercentage, alphapercentage, alpha, Environment.NewLine));

        }

        private void UpdateHslText(Color color)
        {
            /* Wait, Color has HSL/HSB values? I don't need to calculate them myself then */
            int hue = (int)color.GetHue();
            int saturation = (int)(color.GetSaturation() * 100);
            int lightness = (int)(color.GetBrightness() * 100);
            decimal alpha = Math.Round(Convert.ToDecimal(color.A / 255M), 1);

            hslBox.Text = "";
            hslBox.AppendText(String.Format("HSL({0}, {1}, {2})", hue, saturation, lightness));
            hslBox.AppendText(String.Format("{0}", Environment.NewLine));
            hslBox.AppendText(String.Format("HSL({0}, {1}%, {2}%)", hue, saturation, lightness));
            hslBox.AppendText(String.Format("{0}", Environment.NewLine));
            hslBox.AppendText(String.Format("HSL({0}°, {1}%, {2}%)", hue, saturation, lightness));
            hslBox.AppendText(String.Format("{0}{0}", Environment.NewLine));
            hslBox.AppendText(String.Format("HSLA({0}, {1}, {2}, {3})", hue, saturation, lightness, alpha));
            hslBox.AppendText(String.Format("{0}", Environment.NewLine));
            hslBox.AppendText(String.Format("HSLA({0}, {1}%, {2}%, {3})", hue, saturation, lightness, alpha));
            hslBox.AppendText(String.Format("{0}", Environment.NewLine));
            hslBox.AppendText(String.Format("HSLA({0}°, {1}%, {2}%, {3})", hue, saturation, lightness, alpha));
        }
        private void UpdateWebsafeColor(Color color)
        {
            websafeBox.Text = "";
            createdwebsafeColor = color;

            websafeBox.AppendText(String.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2")));
            websafeBox.AppendText(String.Format("{0}", Environment.NewLine));
            websafeBox.AppendText(String.Format("RGB({0}, {1}, {2})", color.R, color.G, color.B));
        }
        private void UpdateComplementaryText(Color color)
        {
            float hue = (color.GetHue() + 180.0f) % 360.0f;

            Color compColor = CreateColorFromHsl(hue, color.GetSaturation(), color.GetBrightness());

            compTextBox1.Text = "";
            createdComplementColor = compColor;

            compTextBox1.AppendText(String.Format("#{0}{1}{2}", compColor.R.ToString("X2"), compColor.G.ToString("X2"), compColor.B.ToString("X2")));
            compTextBox1.AppendText(String.Format("{0}", Environment.NewLine));
            compTextBox1.AppendText(String.Format("RGB({0}, {1}, {2})", compColor.R, compColor.G, compColor.B));
            
        }
    }
}
