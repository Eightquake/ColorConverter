namespace ColorConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorInputBox = new System.Windows.Forms.TextBox();
            this.introLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupColorInput = new System.Windows.Forms.Panel();
            this.subIntroLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkerboardPictureBox = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hexBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rgbBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hslBox = new System.Windows.Forms.TextBox();
            this.groupColorInput.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkerboardPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorInputBox
            // 
            this.colorInputBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorInputBox.Location = new System.Drawing.Point(3, 3);
            this.colorInputBox.Name = "colorInputBox";
            this.colorInputBox.Size = new System.Drawing.Size(200, 26);
            this.colorInputBox.TabIndex = 0;
            this.colorInputBox.WordWrap = false;
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.AutoSize = true;
            this.introLabel.BackColor = System.Drawing.Color.Transparent;
            this.introLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(133, 12);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(135, 26);
            this.introLabel.TabIndex = 1;
            this.introLabel.Text = "Enter a color";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(209, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupColorInput
            // 
            this.groupColorInput.Controls.Add(this.colorInputBox);
            this.groupColorInput.Controls.Add(this.button1);
            this.groupColorInput.Location = new System.Drawing.Point(70, 75);
            this.groupColorInput.Name = "groupColorInput";
            this.groupColorInput.Size = new System.Drawing.Size(287, 32);
            this.groupColorInput.TabIndex = 3;
            // 
            // subIntroLabel
            // 
            this.subIntroLabel.AutoSize = true;
            this.subIntroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subIntroLabel.Location = new System.Drawing.Point(101, 41);
            this.subIntroLabel.Name = "subIntroLabel";
            this.subIntroLabel.Size = new System.Drawing.Size(203, 17);
            this.subIntroLabel.TabIndex = 4;
            this.subIntroLabel.Text = "Using hex, RGB, RGBA or HSL";
            this.subIntroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.introLabel);
            this.panel1.Controls.Add(this.groupColorInput);
            this.panel1.Controls.Add(this.subIntroLabel);
            this.panel1.Location = new System.Drawing.Point(200, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 120);
            this.panel1.TabIndex = 6;
            // 
            // checkerboardPictureBox
            // 
            this.checkerboardPictureBox.Image = global::ColorConverter.Properties.Resources.checkerboard;
            this.checkerboardPictureBox.ImageLocation = "";
            this.checkerboardPictureBox.InitialImage = null;
            this.checkerboardPictureBox.Location = new System.Drawing.Point(2, 2);
            this.checkerboardPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.checkerboardPictureBox.Name = "checkerboardPictureBox";
            this.checkerboardPictureBox.Size = new System.Drawing.Size(780, 195);
            this.checkerboardPictureBox.TabIndex = 5;
            this.checkerboardPictureBox.TabStop = false;
            this.checkerboardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CheckerboardPictureBox_Paint);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Colorconverter - Ready to convert!";
            this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hexBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hex";
            // 
            // hexBox
            // 
            this.hexBox.BackColor = System.Drawing.SystemColors.Control;
            this.hexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.Location = new System.Drawing.Point(7, 20);
            this.hexBox.Multiline = true;
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.Size = new System.Drawing.Size(233, 55);
            this.hexBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rgbBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 259);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RGB";
            // 
            // rgbBox
            // 
            this.rgbBox.BackColor = System.Drawing.SystemColors.Control;
            this.rgbBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rgbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgbBox.Location = new System.Drawing.Point(7, 20);
            this.rgbBox.Multiline = true;
            this.rgbBox.Name = "rgbBox";
            this.rgbBox.ReadOnly = true;
            this.rgbBox.Size = new System.Drawing.Size(233, 233);
            this.rgbBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hslBox);
            this.groupBox3.Location = new System.Drawing.Point(268, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 200);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HSL";
            // 
            // hslBox
            // 
            this.hslBox.BackColor = System.Drawing.SystemColors.Control;
            this.hslBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hslBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hslBox.Location = new System.Drawing.Point(7, 20);
            this.hslBox.Multiline = true;
            this.hslBox.Name = "hslBox";
            this.hslBox.ReadOnly = true;
            this.hslBox.Size = new System.Drawing.Size(233, 160);
            this.hslBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkerboardPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Colorconverter";
            this.Activated += new System.EventHandler(this.Form1_GotFocus);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupColorInput.ResumeLayout(false);
            this.groupColorInput.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkerboardPictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox colorInputBox;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel groupColorInput;
        private System.Windows.Forms.Label subIntroLabel;
        private System.Windows.Forms.PictureBox checkerboardPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox hexBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox rgbBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox hslBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

