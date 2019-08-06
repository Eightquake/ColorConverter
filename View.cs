using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorConverter
{
    public partial class View : Form
    {
        private Presenter presenter;
        public View(Presenter thePresenter)
        {
            this.presenter = thePresenter;
            InitializeComponent();
        }
        #region Windows Form methods for events
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Form1_Load does not happen when this.refresh() is called in changeColorBox - that's a good thing as this only needs to be run once */
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            /* If the Form is minimzed, hide it and show the notification icon */
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void Form1_GotFocus(object sender, EventArgs e)
        {
            /* Whenever the Form gets focused, check the clipboard if it contains a color */
            presenter.CheckClipBoard();
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
            Color color = presenter.GetInputColor();
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 200));
            brush.Dispose();
        }
        private void WebsafePictureBox_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetWebsafeColor();
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 235, 82));
            brush.Dispose();
        }
        private void CompPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetComplementColor();
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 157, 70));
            brush.Dispose();
        }
        private void AnalogousPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetHarmonyColors(0);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 70, 70));
            brush.Dispose();
        }
        private void AnalogousPictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetHarmonyColors(1);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 70, 70));
            brush.Dispose();
        }
        private void AnalogousPictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetHarmonyColors(2);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 70, 70));
            brush.Dispose();
        }
        private void AnalogousPictureBox4_Paint(object sender, PaintEventArgs e)
        {
            Color color = presenter.GetHarmonyColors(3);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(brush, new Rectangle(0, 0, 70, 70));
            brush.Dispose();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            presenter.TestRegex(colorInputBox.Text);
        }
        private void WebsafePictureBox_Click(object sender, EventArgs e)
        {
            colorInputBox.Text = "#" + presenter.GetWebsafeColor().Name.Remove(0, 2).ToUpper();
            presenter.TestRegex(colorInputBox.Text);
        }

        private void CompPictureBox1_Click(object sender, EventArgs e)
        {
            presenter.CompPicture_Click();
        }

        private void AnalogousPictureBox1_Click(object sender, EventArgs e)
        {
            colorInputBox.Text = "#" + presenter.GetHarmonyColors(0).Name.Remove(0, 2).ToUpper();
            presenter.TestRegex(colorInputBox.Text);
        }
        private void AnalogousPictureBox2_Click(object sender, EventArgs e)
        {
            colorInputBox.Text = "#" + presenter.GetHarmonyColors(1).Name.Remove(0, 2).ToUpper();
            presenter.TestRegex(colorInputBox.Text);
        }
        private void AnalogousPictureBox3_Click(object sender, EventArgs e)
        {
            colorInputBox.Text = "#" + presenter.GetHarmonyColors(2).Name.Remove(0, 2).ToUpper();
            presenter.TestRegex(colorInputBox.Text);
        }
        private void AnalogousPictureBox4_Click(object sender, EventArgs e)
        {
            colorInputBox.Text = "#" + presenter.GetHarmonyColors(3).Name.Remove(0, 2).ToUpper();
            presenter.TestRegex(colorInputBox.Text);
        }
        private void ShowWindowAgain()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        #endregion
        #region Getters and setters 
        public int GetColorHarmonyLength()
        {
            /* There's a picturebox and textbox for each color harmony, so return half of the amount of controls */
            return colorHarmonyGroup.Controls.Count / 2;
        }
        public void SetColorInputBoxText(string text)
        {
            colorInputBox.Text = text;
        }

        public void SetHexBoxText(string text)
        {
            hexBox.Text = text;
        }
        public void SetRGBBoxText(string text)
        {
            rgbBox.Text = text;
        }
        public void SetHSLBoxText(string text)
        {
            hslBox.Text = text;
        }
        public void SetWebsafeBoxText(string text)
        {
            websafeBox.Text = text;
        }
        public void SetCompBoxText(string text)
        {
            compTextBox.Text = text;
        }
        public bool SetHarmonyBoxText(int index, string text)
        {
            Control[] harmonyBoxArray = colorHarmonyGroup.Controls.Find("analogousTextBox" + index, false);
            if (harmonyBoxArray.Length > 0)
            {
                harmonyBoxArray[0].Text = text;
                return true;
            }
            else
            {
                /* No harmony textbox was found with the index provided */
                return false;
            }
        }
        #endregion
    }
}