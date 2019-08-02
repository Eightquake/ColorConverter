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
        private Regex allSupportedRegex;

        public Form1()
        {
            InitializeComponent();
            inputColor = Color.FromArgb(128, 255, 0, 0);
            /* Well, this took a while to find out. It captures any supported color system in the first group, and then the parameters in seperate groups. Optionally, for rgba, it captures the fractional as a parameter */
            allSupportedRegex = new Regex(@"^((#)|(HEX)|(RGBA)|(RGB)|(HSL))[\(\s]?(\d+|[0-9a-fA-F]{2}),?\s?(\d+|[0-9a-fA-F]{2}),?\s?(\d+|[0-9a-fA-F]{2}),?\s?(0?[\.|\,]?\d)?[\)\s]?$");

            checkerboardPictureBox.Paint += new PaintEventHandler(this.checkerboardPictureBox_Paint);

            updateColorTexts(inputColor);
        }
        
        private void checkerboardPictureBox_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(inputColor);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 200));
            brush.Dispose();
        }

        private void changeColorBox(Color color)
        {
            inputColor = color;
            this.Refresh();
        }

        private void updateColorTexts(Color color)
        {
            updateHexText(color);
            updateRGBText(color);
            updateHslText(color);
        }

        private void updateHexText(Color color)
        {
            hexBox.Text = String.Format("#RRGGBB\t#{0}{1}{2}{4}#RRGGBBAA\t#{0}{1}{2}{3}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"), color.A.ToString("X2"), Environment.NewLine);
        }

        private void updateRGBText(Color color)
        {
            rgbBox.Text = String.Format("RGB()\tRGB({0}, {1}, {2}){4}RGBA()\tRGBA({0}, {1}, {2}, {3}){4}ARGB()\tARGB({3}, {0}, {1}, {2})", color.R.ToString(), color.G.ToString(), color.B.ToString(), color.A.ToString(), Environment.NewLine);
        }

        private void updateHslText(Color color)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
  
            MatchCollection matches = allSupportedRegex.Matches(colorInputBox.Text);
            if (matches.Count > 0)
            {
                Match match = matches[0];
                if (match.Groups[1].Value == "#" || match.Groups[1].Value == "HEX")
                {
                    /* The user entered a color using either # or HEX(). ColorTranslator supports hex right out of the box so I don't need to convert it. I know that groups 7, 8, 9 are the ones that captured the parameters so let's use them */
                    Color convertedColor = System.Drawing.ColorTranslator.FromHtml("#" + match.Groups[7] + match.Groups[8] + match.Groups[9]);
                    changeColorBox(convertedColor);
                    updateColorTexts(convertedColor);
                }
                else if (match.Groups[1].Value == "RGB")
                {
                    /* The user entered a color using RGB, let's create a color using Color.FromArgb but set alpha as 255 */
                    int red = int.Parse(match.Groups[7].Value);
                    int green = int.Parse(match.Groups[8].Value);
                    int blue = int.Parse(match.Groups[9].Value);

                    Color convertedColor = Color.FromArgb(255, red, green, blue);
                    changeColorBox(convertedColor);
                    updateColorTexts(convertedColor);
                }
                else if (match.Groups[1].Value == "RGBA")
                {
                    int red = int.Parse(match.Groups[7].Value);
                    int green = int.Parse(match.Groups[8].Value);
                    int blue = int.Parse(match.Groups[9].Value);
                    decimal alpha = decimal.Parse(match.Groups[10].Value.Replace(".", ","));

                    Color convertedColor = Color.FromArgb((int)(alpha * 255), red, green, blue);
                    changeColorBox(convertedColor);
                    updateColorTexts(convertedColor);
                }
            }
            else
            {
                /* There was no match for the string provided - let the user know this. */
            }
        }
    }
}
