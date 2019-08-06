namespace ColorConverter
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
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
            this.groupbox4 = new System.Windows.Forms.GroupBox();
            this.websafePictureBox = new System.Windows.Forms.PictureBox();
            this.websafeBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.compTextBox = new System.Windows.Forms.TextBox();
            this.compPictureBox = new System.Windows.Forms.PictureBox();
            this.colorHarmonyGroup = new System.Windows.Forms.GroupBox();
            this.analogousTextBox4 = new System.Windows.Forms.TextBox();
            this.analogousPictureBox4 = new System.Windows.Forms.PictureBox();
            this.analogousTextBox3 = new System.Windows.Forms.TextBox();
            this.analogousPictureBox3 = new System.Windows.Forms.PictureBox();
            this.analogousTextBox2 = new System.Windows.Forms.TextBox();
            this.analogousPictureBox2 = new System.Windows.Forms.PictureBox();
            this.analogousTextBox1 = new System.Windows.Forms.TextBox();
            this.analogousPictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupColorInput.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkerboardPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupbox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.websafePictureBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compPictureBox)).BeginInit();
            this.colorHarmonyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // colorInputBox
            // 
            this.colorInputBox.AllowDrop = true;
            this.colorInputBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorInputBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.colorInputBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
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
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDown);
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
            this.hexBox.Size = new System.Drawing.Size(237, 55);
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
            this.rgbBox.Size = new System.Drawing.Size(237, 233);
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
            this.hslBox.Size = new System.Drawing.Size(237, 174);
            this.hslBox.TabIndex = 0;
            // 
            // groupbox4
            // 
            this.groupbox4.Controls.Add(this.websafePictureBox);
            this.groupbox4.Controls.Add(this.websafeBox);
            this.groupbox4.Location = new System.Drawing.Point(525, 203);
            this.groupbox4.Name = "groupbox4";
            this.groupbox4.Size = new System.Drawing.Size(247, 200);
            this.groupbox4.TabIndex = 10;
            this.groupbox4.TabStop = false;
            this.groupbox4.Text = "Websafe";
            // 
            // websafePictureBox
            // 
            this.websafePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.websafePictureBox.Location = new System.Drawing.Point(7, 20);
            this.websafePictureBox.Name = "websafePictureBox";
            this.websafePictureBox.Size = new System.Drawing.Size(234, 81);
            this.websafePictureBox.TabIndex = 1;
            this.websafePictureBox.TabStop = false;
            this.websafePictureBox.Click += new System.EventHandler(this.WebsafePictureBox_Click);
            this.websafePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WebsafePictureBox_Paint);
            // 
            // websafeBox
            // 
            this.websafeBox.BackColor = System.Drawing.SystemColors.Control;
            this.websafeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.websafeBox.Location = new System.Drawing.Point(7, 107);
            this.websafeBox.Multiline = true;
            this.websafeBox.Name = "websafeBox";
            this.websafeBox.ReadOnly = true;
            this.websafeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.websafeBox.Size = new System.Drawing.Size(234, 87);
            this.websafeBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.compTextBox);
            this.groupBox5.Controls.Add(this.compPictureBox);
            this.groupBox5.Location = new System.Drawing.Point(603, 410);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 139);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Complementary";
            // 
            // compTextBox
            // 
            this.compTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.compTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compTextBox.Location = new System.Drawing.Point(6, 97);
            this.compTextBox.Multiline = true;
            this.compTextBox.Name = "compTextBox";
            this.compTextBox.ReadOnly = true;
            this.compTextBox.Size = new System.Drawing.Size(157, 36);
            this.compTextBox.TabIndex = 1;
            // 
            // compPictureBox
            // 
            this.compPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compPictureBox.Location = new System.Drawing.Point(6, 19);
            this.compPictureBox.Name = "compPictureBox";
            this.compPictureBox.Size = new System.Drawing.Size(157, 70);
            this.compPictureBox.TabIndex = 0;
            this.compPictureBox.TabStop = false;
            this.compPictureBox.Click += new System.EventHandler(this.CompPictureBox1_Click);
            this.compPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CompPictureBox1_Paint);
            // 
            // colorHarmonyGroup
            // 
            this.colorHarmonyGroup.Controls.Add(this.analogousTextBox4);
            this.colorHarmonyGroup.Controls.Add(this.analogousPictureBox4);
            this.colorHarmonyGroup.Controls.Add(this.analogousTextBox3);
            this.colorHarmonyGroup.Controls.Add(this.analogousPictureBox3);
            this.colorHarmonyGroup.Controls.Add(this.analogousTextBox2);
            this.colorHarmonyGroup.Controls.Add(this.analogousPictureBox2);
            this.colorHarmonyGroup.Controls.Add(this.analogousTextBox1);
            this.colorHarmonyGroup.Controls.Add(this.analogousPictureBox1);
            this.colorHarmonyGroup.Location = new System.Drawing.Point(268, 410);
            this.colorHarmonyGroup.Name = "colorHarmonyGroup";
            this.colorHarmonyGroup.Size = new System.Drawing.Size(329, 139);
            this.colorHarmonyGroup.TabIndex = 12;
            this.colorHarmonyGroup.TabStop = false;
            this.colorHarmonyGroup.Text = "Analogous color harmony";
            // 
            // analogousTextBox4
            // 
            this.analogousTextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.analogousTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analogousTextBox4.Location = new System.Drawing.Point(244, 97);
            this.analogousTextBox4.Multiline = true;
            this.analogousTextBox4.Name = "analogousTextBox4";
            this.analogousTextBox4.ReadOnly = true;
            this.analogousTextBox4.Size = new System.Drawing.Size(70, 30);
            this.analogousTextBox4.TabIndex = 7;
            // 
            // analogousPictureBox4
            // 
            this.analogousPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analogousPictureBox4.Location = new System.Drawing.Point(244, 19);
            this.analogousPictureBox4.Name = "analogousPictureBox4";
            this.analogousPictureBox4.Size = new System.Drawing.Size(70, 70);
            this.analogousPictureBox4.TabIndex = 6;
            this.analogousPictureBox4.TabStop = false;
            this.analogousPictureBox4.Click += new System.EventHandler(this.AnalogousPictureBox4_Click);
            this.analogousPictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogousPictureBox4_Paint);
            // 
            // analogousTextBox3
            // 
            this.analogousTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.analogousTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analogousTextBox3.Location = new System.Drawing.Point(168, 97);
            this.analogousTextBox3.Multiline = true;
            this.analogousTextBox3.Name = "analogousTextBox3";
            this.analogousTextBox3.ReadOnly = true;
            this.analogousTextBox3.Size = new System.Drawing.Size(70, 30);
            this.analogousTextBox3.TabIndex = 5;
            // 
            // analogousPictureBox3
            // 
            this.analogousPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analogousPictureBox3.Location = new System.Drawing.Point(168, 19);
            this.analogousPictureBox3.Name = "analogousPictureBox3";
            this.analogousPictureBox3.Size = new System.Drawing.Size(70, 70);
            this.analogousPictureBox3.TabIndex = 4;
            this.analogousPictureBox3.TabStop = false;
            this.analogousPictureBox3.Click += new System.EventHandler(this.AnalogousPictureBox3_Click);
            this.analogousPictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogousPictureBox3_Paint);
            // 
            // analogousTextBox2
            // 
            this.analogousTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.analogousTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analogousTextBox2.Location = new System.Drawing.Point(92, 97);
            this.analogousTextBox2.Multiline = true;
            this.analogousTextBox2.Name = "analogousTextBox2";
            this.analogousTextBox2.ReadOnly = true;
            this.analogousTextBox2.Size = new System.Drawing.Size(70, 30);
            this.analogousTextBox2.TabIndex = 3;
            // 
            // analogousPictureBox2
            // 
            this.analogousPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analogousPictureBox2.Location = new System.Drawing.Point(92, 19);
            this.analogousPictureBox2.Name = "analogousPictureBox2";
            this.analogousPictureBox2.Size = new System.Drawing.Size(70, 70);
            this.analogousPictureBox2.TabIndex = 2;
            this.analogousPictureBox2.TabStop = false;
            this.analogousPictureBox2.Click += new System.EventHandler(this.AnalogousPictureBox2_Click);
            this.analogousPictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogousPictureBox2_Paint);
            // 
            // analogousTextBox1
            // 
            this.analogousTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.analogousTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analogousTextBox1.Location = new System.Drawing.Point(16, 99);
            this.analogousTextBox1.Multiline = true;
            this.analogousTextBox1.Name = "analogousTextBox1";
            this.analogousTextBox1.ReadOnly = true;
            this.analogousTextBox1.Size = new System.Drawing.Size(70, 30);
            this.analogousTextBox1.TabIndex = 1;
            // 
            // analogousPictureBox1
            // 
            this.analogousPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analogousPictureBox1.Location = new System.Drawing.Point(16, 19);
            this.analogousPictureBox1.Name = "analogousPictureBox1";
            this.analogousPictureBox1.Size = new System.Drawing.Size(70, 70);
            this.analogousPictureBox1.TabIndex = 0;
            this.analogousPictureBox1.TabStop = false;
            this.analogousPictureBox1.Click += new System.EventHandler(this.AnalogousPictureBox1_Click);
            this.analogousPictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogousPictureBox1_Paint);
            // 
            // View
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.colorHarmonyGroup);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupbox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkerboardPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "View";
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
            this.groupbox4.ResumeLayout(false);
            this.groupbox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.websafePictureBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compPictureBox)).EndInit();
            this.colorHarmonyGroup.ResumeLayout(false);
            this.colorHarmonyGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analogousPictureBox1)).EndInit();
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
        private System.Windows.Forms.GroupBox groupbox4;
        private System.Windows.Forms.TextBox websafeBox;
        private System.Windows.Forms.PictureBox websafePictureBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox compTextBox;
        private System.Windows.Forms.PictureBox compPictureBox;
        private System.Windows.Forms.GroupBox colorHarmonyGroup;
        private System.Windows.Forms.TextBox analogousTextBox3;
        private System.Windows.Forms.PictureBox analogousPictureBox3;
        private System.Windows.Forms.TextBox analogousTextBox2;
        private System.Windows.Forms.PictureBox analogousPictureBox2;
        private System.Windows.Forms.TextBox analogousTextBox1;
        private System.Windows.Forms.PictureBox analogousPictureBox1;
        private System.Windows.Forms.TextBox analogousTextBox4;
        private System.Windows.Forms.PictureBox analogousPictureBox4;
    }
}

