using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace JA_Neon
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_run = new System.Windows.Forms.Button();
            this.checkbox_autorun = new System.Windows.Forms.CheckBox();
            this.select_Library = new System.Windows.Forms.ComboBox();
            this.label_Library = new System.Windows.Forms.Label();
            this.slider_cores = new System.Windows.Forms.TrackBar();
            this.label_Cores = new System.Windows.Forms.Label();
            this.label_Cores_1 = new System.Windows.Forms.Label();
            this.label_Cores_8 = new System.Windows.Forms.Label();
            this.label_Cores_32 = new System.Windows.Forms.Label();
            this.label_Cores_64 = new System.Windows.Forms.Label();
            this.button_Cores_autodetect = new System.Windows.Forms.Button();
            this.reading_time = new System.Windows.Forms.Label();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.slider_MaskBlur = new System.Windows.Forms.TrackBar();
            this.label_MaskBlur_20 = new System.Windows.Forms.Label();
            this.label_MaskBlur_0 = new System.Windows.Forms.Label();
            this.label_MaskBlur = new System.Windows.Forms.Label();
            this.slider_NeonIntensity = new System.Windows.Forms.TrackBar();
            this.label_NeonIntensity = new System.Windows.Forms.Label();
            this.label_NeonIntensity_0 = new System.Windows.Forms.Label();
            this.label_NeonIntensity_200 = new System.Windows.Forms.Label();
            this.peeker_MaskBlur = new System.Windows.Forms.Label();
            this.peeker_NeonIntensity = new System.Windows.Forms.Label();
            this.label_ClickToOpen = new System.Windows.Forms.Label();
            this.label_ClickToSave = new System.Windows.Forms.Label();
            this.label_Input = new System.Windows.Forms.Label();
            this.label_Output = new System.Windows.Forms.Label();
            this.label_MaskIntensity_200 = new System.Windows.Forms.Label();
            this.label_MaskIntensity_0 = new System.Windows.Forms.Label();
            this.label_MaskIntensity = new System.Windows.Forms.Label();
            this.slider_MaskIntensity = new System.Windows.Forms.TrackBar();
            this.label_MaskIntensity_100 = new System.Windows.Forms.Label();
            this.peeker_MaskIntensity = new System.Windows.Forms.Label();
            this.peeker_Cores = new System.Windows.Forms.Label();
            this.label_Cores_16 = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label_ProgressBar = new System.Windows.Forms.Label();
            this.Console = new System.Windows.Forms.TextBox();
            this.InputPictureBox = new System.Windows.Forms.PictureBox();
            this.OutputPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.slider_cores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_MaskBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_NeonIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_MaskIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_run
            // 
            this.button_run.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_run.Location = new System.Drawing.Point(657, 614);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(75, 23);
            this.button_run.TabIndex = 0;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.Run);
            // 
            // checkbox_autorun
            // 
            this.checkbox_autorun.AutoSize = true;
            this.checkbox_autorun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkbox_autorun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkbox_autorun.Location = new System.Drawing.Point(738, 617);
            this.checkbox_autorun.Name = "checkbox_autorun";
            this.checkbox_autorun.Size = new System.Drawing.Size(86, 18);
            this.checkbox_autorun.TabIndex = 3;
            this.checkbox_autorun.Text = "Auto Rerun";
            this.checkbox_autorun.UseVisualStyleBackColor = true;
            this.checkbox_autorun.Click += new System.EventHandler(this.CheckBox_AutoRun_ValueChanged);
            // 
            // select_Library
            // 
            this.select_Library.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_Library.FormattingEnabled = true;
            this.select_Library.Items.AddRange(new object[] {
            "Assembly",
            "C++"});
            this.select_Library.Location = new System.Drawing.Point(59, 418);
            this.select_Library.Name = "select_Library";
            this.select_Library.Size = new System.Drawing.Size(121, 21);
            this.select_Library.TabIndex = 4;
            this.select_Library.SelectedIndexChanged += new System.EventHandler(this.Select_Library_ValueChanged);
            // 
            // label_Library
            // 
            this.label_Library.AutoSize = true;
            this.label_Library.Location = new System.Drawing.Point(12, 421);
            this.label_Library.Name = "label_Library";
            this.label_Library.Size = new System.Drawing.Size(41, 13);
            this.label_Library.TabIndex = 5;
            this.label_Library.Text = "Library:";
            this.label_Library.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // slider_cores
            // 
            this.slider_cores.AutoSize = false;
            this.slider_cores.LargeChange = 10;
            this.slider_cores.Location = new System.Drawing.Point(58, 445);
            this.slider_cores.Maximum = 64;
            this.slider_cores.Minimum = 1;
            this.slider_cores.Name = "slider_cores";
            this.slider_cores.Size = new System.Drawing.Size(276, 45);
            this.slider_cores.TabIndex = 6;
            this.slider_cores.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_cores.Value = 16;
            this.slider_cores.ValueChanged += new System.EventHandler(this.Slider_Cores_ValueChange);
            this.slider_cores.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_Cores_MouseUp);
            // 
            // label_Cores
            // 
            this.label_Cores.AutoSize = true;
            this.label_Cores.Location = new System.Drawing.Point(12, 449);
            this.label_Cores.Name = "label_Cores";
            this.label_Cores.Size = new System.Drawing.Size(37, 13);
            this.label_Cores.TabIndex = 7;
            this.label_Cores.Text = "Cores:";
            this.label_Cores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Cores_1
            // 
            this.label_Cores_1.AutoSize = true;
            this.label_Cores_1.Location = new System.Drawing.Point(67, 469);
            this.label_Cores_1.Name = "label_Cores_1";
            this.label_Cores_1.Size = new System.Drawing.Size(13, 13);
            this.label_Cores_1.TabIndex = 8;
            this.label_Cores_1.Text = "1";
            this.label_Cores_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Cores_8
            // 
            this.label_Cores_8.AutoSize = true;
            this.label_Cores_8.Location = new System.Drawing.Point(93, 469);
            this.label_Cores_8.Name = "label_Cores_8";
            this.label_Cores_8.Size = new System.Drawing.Size(13, 13);
            this.label_Cores_8.TabIndex = 9;
            this.label_Cores_8.Text = "8";
            this.label_Cores_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Cores_32
            // 
            this.label_Cores_32.AutoSize = true;
            this.label_Cores_32.Location = new System.Drawing.Point(186, 469);
            this.label_Cores_32.Name = "label_Cores_32";
            this.label_Cores_32.Size = new System.Drawing.Size(19, 13);
            this.label_Cores_32.TabIndex = 11;
            this.label_Cores_32.Text = "32";
            this.label_Cores_32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Cores_64
            // 
            this.label_Cores_64.AutoSize = true;
            this.label_Cores_64.Location = new System.Drawing.Point(312, 469);
            this.label_Cores_64.Name = "label_Cores_64";
            this.label_Cores_64.Size = new System.Drawing.Size(19, 13);
            this.label_Cores_64.TabIndex = 14;
            this.label_Cores_64.Text = "64";
            this.label_Cores_64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Cores_autodetect
            // 
            this.button_Cores_autodetect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Cores_autodetect.Location = new System.Drawing.Point(337, 444);
            this.button_Cores_autodetect.Name = "button_Cores_autodetect";
            this.button_Cores_autodetect.Size = new System.Drawing.Size(75, 23);
            this.button_Cores_autodetect.TabIndex = 15;
            this.button_Cores_autodetect.Text = "Auto detect";
            this.button_Cores_autodetect.UseVisualStyleBackColor = true;
            this.button_Cores_autodetect.Click += new System.EventHandler(this.DetectCoresCount);
            // 
            // reading_time
            // 
            this.reading_time.AutoSize = true;
            this.reading_time.Location = new System.Drawing.Point(657, 597);
            this.reading_time.Name = "reading_time";
            this.reading_time.Size = new System.Drawing.Size(0, 13);
            this.reading_time.TabIndex = 16;
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openFileDialog1";
            // 
            // slider_MaskBlur
            // 
            this.slider_MaskBlur.AutoSize = false;
            this.slider_MaskBlur.LargeChange = 0;
            this.slider_MaskBlur.Location = new System.Drawing.Point(495, 444);
            this.slider_MaskBlur.Maximum = 200;
            this.slider_MaskBlur.Name = "slider_MaskBlur";
            this.slider_MaskBlur.Size = new System.Drawing.Size(322, 45);
            this.slider_MaskBlur.TabIndex = 17;
            this.slider_MaskBlur.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_MaskBlur.Value = 1;
            this.slider_MaskBlur.ValueChanged += new System.EventHandler(this.Slider_MaskBlur_ValueChange);
            this.slider_MaskBlur.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_MaskBlur_MouseUp);
            // 
            // label_MaskBlur_20
            // 
            this.label_MaskBlur_20.AutoSize = true;
            this.label_MaskBlur_20.Location = new System.Drawing.Point(790, 470);
            this.label_MaskBlur_20.Name = "label_MaskBlur_20";
            this.label_MaskBlur_20.Size = new System.Drawing.Size(30, 13);
            this.label_MaskBlur_20.TabIndex = 19;
            this.label_MaskBlur_20.Text = "20px";
            // 
            // label_MaskBlur_0
            // 
            this.label_MaskBlur_0.AutoSize = true;
            this.label_MaskBlur_0.Location = new System.Drawing.Point(498, 470);
            this.label_MaskBlur_0.Name = "label_MaskBlur_0";
            this.label_MaskBlur_0.Size = new System.Drawing.Size(24, 13);
            this.label_MaskBlur_0.TabIndex = 18;
            this.label_MaskBlur_0.Text = "0px";
            // 
            // label_MaskBlur
            // 
            this.label_MaskBlur.AutoSize = true;
            this.label_MaskBlur.Location = new System.Drawing.Point(441, 449);
            this.label_MaskBlur.Name = "label_MaskBlur";
            this.label_MaskBlur.Size = new System.Drawing.Size(57, 13);
            this.label_MaskBlur.TabIndex = 20;
            this.label_MaskBlur.Text = "Mask Blur:";
            // 
            // slider_NeonIntensity
            // 
            this.slider_NeonIntensity.AutoSize = false;
            this.slider_NeonIntensity.LargeChange = 0;
            this.slider_NeonIntensity.Location = new System.Drawing.Point(496, 549);
            this.slider_NeonIntensity.Maximum = 200;
            this.slider_NeonIntensity.Name = "slider_NeonIntensity";
            this.slider_NeonIntensity.Size = new System.Drawing.Size(322, 45);
            this.slider_NeonIntensity.TabIndex = 21;
            this.slider_NeonIntensity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_NeonIntensity.Value = 75;
            this.slider_NeonIntensity.ValueChanged += new System.EventHandler(this.Slider_NeonIntensity_ValueChange);
            this.slider_NeonIntensity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_NeonIntensity_MouseUp);
            // 
            // label_NeonIntensity
            // 
            this.label_NeonIntensity.AutoSize = true;
            this.label_NeonIntensity.Location = new System.Drawing.Point(422, 551);
            this.label_NeonIntensity.Name = "label_NeonIntensity";
            this.label_NeonIntensity.Size = new System.Drawing.Size(78, 13);
            this.label_NeonIntensity.TabIndex = 22;
            this.label_NeonIntensity.Text = "Neon Intensity:";
            // 
            // label_NeonIntensity_0
            // 
            this.label_NeonIntensity_0.AutoSize = true;
            this.label_NeonIntensity_0.Location = new System.Drawing.Point(499, 570);
            this.label_NeonIntensity_0.Name = "label_NeonIntensity_0";
            this.label_NeonIntensity_0.Size = new System.Drawing.Size(25, 13);
            this.label_NeonIntensity_0.TabIndex = 23;
            this.label_NeonIntensity_0.Text = "nah";
            // 
            // label_NeonIntensity_200
            // 
            this.label_NeonIntensity_200.AutoSize = true;
            this.label_NeonIntensity_200.Location = new System.Drawing.Point(777, 571);
            this.label_NeonIntensity_200.Name = "label_NeonIntensity_200";
            this.label_NeonIntensity_200.Size = new System.Drawing.Size(44, 13);
            this.label_NeonIntensity_200.TabIndex = 24;
            this.label_NeonIntensity_200.Text = "rainbow";
            // 
            // peeker_MaskBlur
            // 
            this.peeker_MaskBlur.AutoSize = true;
            this.peeker_MaskBlur.Location = new System.Drawing.Point(455, 469);
            this.peeker_MaskBlur.Name = "peeker_MaskBlur";
            this.peeker_MaskBlur.Size = new System.Drawing.Size(36, 13);
            this.peeker_MaskBlur.TabIndex = 25;
            this.peeker_MaskBlur.Text = "1.0 px";
            // 
            // peeker_NeonIntensity
            // 
            this.peeker_NeonIntensity.AutoSize = true;
            this.peeker_NeonIntensity.Location = new System.Drawing.Point(461, 571);
            this.peeker_NeonIntensity.Name = "peeker_NeonIntensity";
            this.peeker_NeonIntensity.Size = new System.Drawing.Size(30, 13);
            this.peeker_NeonIntensity.TabIndex = 26;
            this.peeker_NeonIntensity.Text = "75 %";
            // 
            // label_ClickToOpen
            // 
            this.label_ClickToOpen.AutoSize = true;
            this.label_ClickToOpen.BackColor = System.Drawing.Color.Transparent;
            this.label_ClickToOpen.Location = new System.Drawing.Point(149, 206);
            this.label_ClickToOpen.Name = "label_ClickToOpen";
            this.label_ClickToOpen.Size = new System.Drawing.Size(124, 13);
            this.label_ClickToOpen.TabIndex = 1;
            this.label_ClickToOpen.Text = "Click here to open image";
            this.label_ClickToOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ClickToSave
            // 
            this.label_ClickToSave.AutoSize = true;
            this.label_ClickToSave.BackColor = System.Drawing.Color.Transparent;
            this.label_ClickToSave.Location = new System.Drawing.Point(561, 209);
            this.label_ClickToSave.Name = "label_ClickToSave";
            this.label_ClickToSave.Size = new System.Drawing.Size(123, 26);
            this.label_ClickToSave.TabIndex = 1;
            this.label_ClickToSave.Text = "Click here to save image\r\n(once there is one)";
            this.label_ClickToSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Input
            // 
            this.label_Input.AutoSize = true;
            this.label_Input.BackColor = System.Drawing.Color.Transparent;
            this.label_Input.Location = new System.Drawing.Point(28, 25);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(40, 13);
            this.label_Input.TabIndex = 31;
            this.label_Input.Text = "INPUT";
            // 
            // label_Output
            // 
            this.label_Output.AutoSize = true;
            this.label_Output.BackColor = System.Drawing.Color.Transparent;
            this.label_Output.Location = new System.Drawing.Point(432, 26);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(52, 13);
            this.label_Output.TabIndex = 30;
            this.label_Output.Text = "OUTPUT";
            // 
            // label_MaskIntensity_200
            // 
            this.label_MaskIntensity_200.AutoSize = true;
            this.label_MaskIntensity_200.Location = new System.Drawing.Point(784, 523);
            this.label_MaskIntensity_200.Name = "label_MaskIntensity_200";
            this.label_MaskIntensity_200.Size = new System.Drawing.Size(33, 13);
            this.label_MaskIntensity_200.TabIndex = 34;
            this.label_MaskIntensity_200.Text = "200%";
            // 
            // label_MaskIntensity_0
            // 
            this.label_MaskIntensity_0.AutoSize = true;
            this.label_MaskIntensity_0.Location = new System.Drawing.Point(498, 521);
            this.label_MaskIntensity_0.Name = "label_MaskIntensity_0";
            this.label_MaskIntensity_0.Size = new System.Drawing.Size(21, 13);
            this.label_MaskIntensity_0.TabIndex = 33;
            this.label_MaskIntensity_0.Text = "0%";
            // 
            // label_MaskIntensity
            // 
            this.label_MaskIntensity.AutoSize = true;
            this.label_MaskIntensity.Location = new System.Drawing.Point(421, 500);
            this.label_MaskIntensity.Name = "label_MaskIntensity";
            this.label_MaskIntensity.Size = new System.Drawing.Size(78, 13);
            this.label_MaskIntensity.TabIndex = 32;
            this.label_MaskIntensity.Text = "Mask Intensity:";
            // 
            // slider_MaskIntensity
            // 
            this.slider_MaskIntensity.AutoSize = false;
            this.slider_MaskIntensity.LargeChange = 0;
            this.slider_MaskIntensity.Location = new System.Drawing.Point(495, 498);
            this.slider_MaskIntensity.Maximum = 200;
            this.slider_MaskIntensity.Name = "slider_MaskIntensity";
            this.slider_MaskIntensity.Size = new System.Drawing.Size(322, 45);
            this.slider_MaskIntensity.TabIndex = 100;
            this.slider_MaskIntensity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_MaskIntensity.Value = 100;
            this.slider_MaskIntensity.ValueChanged += new System.EventHandler(this.Slider_MaskIntensity_ValueChange);
            this.slider_MaskIntensity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_MaskIntensity_MouseUp);
            // 
            // label_MaskIntensity_100
            // 
            this.label_MaskIntensity_100.AutoSize = true;
            this.label_MaskIntensity_100.Location = new System.Drawing.Point(641, 522);
            this.label_MaskIntensity_100.Name = "label_MaskIntensity_100";
            this.label_MaskIntensity_100.Size = new System.Drawing.Size(33, 13);
            this.label_MaskIntensity_100.TabIndex = 35;
            this.label_MaskIntensity_100.Text = "100%";
            // 
            // peeker_MaskIntensity
            // 
            this.peeker_MaskIntensity.AutoSize = true;
            this.peeker_MaskIntensity.Location = new System.Drawing.Point(461, 523);
            this.peeker_MaskIntensity.Name = "peeker_MaskIntensity";
            this.peeker_MaskIntensity.Size = new System.Drawing.Size(36, 13);
            this.peeker_MaskIntensity.TabIndex = 101;
            this.peeker_MaskIntensity.Text = "100 %";
            // 
            // peeker_Cores
            // 
            this.peeker_Cores.AutoSize = true;
            this.peeker_Cores.Location = new System.Drawing.Point(28, 470);
            this.peeker_Cores.Name = "peeker_Cores";
            this.peeker_Cores.Size = new System.Drawing.Size(13, 13);
            this.peeker_Cores.TabIndex = 102;
            this.peeker_Cores.Text = "1";
            this.peeker_Cores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Cores_16
            // 
            this.label_Cores_16.AutoSize = true;
            this.label_Cores_16.Location = new System.Drawing.Point(121, 470);
            this.label_Cores_16.Name = "label_Cores_16";
            this.label_Cores_16.Size = new System.Drawing.Size(19, 13);
            this.label_Cores_16.TabIndex = 103;
            this.label_Cores_16.Text = "16";
            this.label_Cores_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(15, 614);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(636, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 104;
            // 
            // label_ProgressBar
            // 
            this.label_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProgressBar.AutoSize = true;
            this.label_ProgressBar.Location = new System.Drawing.Point(312, 618);
            this.label_ProgressBar.Name = "label_ProgressBar";
            this.label_ProgressBar.Size = new System.Drawing.Size(49, 13);
            this.label_ProgressBar.TabIndex = 105;
            this.label_ProgressBar.Text = "waiting...";
            this.label_ProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(15, 496);
            this.Console.Multiline = true;
            this.Console.Name = "Console";
            this.Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console.Size = new System.Drawing.Size(397, 112);
            this.Console.TabIndex = 106;
            // 
            // InputPictureBox
            // 
            this.InputPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.InputPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.InputPictureBox.Location = new System.Drawing.Point(12, 12);
            this.InputPictureBox.Name = "InputPictureBox";
            this.InputPictureBox.Size = new System.Drawing.Size(400, 400);
            this.InputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputPictureBox.TabIndex = 1;
            this.InputPictureBox.TabStop = false;
            this.InputPictureBox.Click += new System.EventHandler(this.inputImageClick);
            // 
            // OutputPictureBox
            // 
            this.OutputPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.OutputPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OutputPictureBox.Location = new System.Drawing.Point(417, 12);
            this.OutputPictureBox.Name = "OutputPictureBox";
            this.OutputPictureBox.Size = new System.Drawing.Size(400, 400);
            this.OutputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OutputPictureBox.TabIndex = 2;
            this.OutputPictureBox.TabStop = false;
            this.OutputPictureBox.Click += new System.EventHandler(this.outputImageClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 656);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.label_ProgressBar);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label_Cores_16);
            this.Controls.Add(this.peeker_Cores);
            this.Controls.Add(this.peeker_MaskIntensity);
            this.Controls.Add(this.label_MaskIntensity_100);
            this.Controls.Add(this.label_MaskIntensity_200);
            this.Controls.Add(this.label_MaskIntensity_0);
            this.Controls.Add(this.label_MaskIntensity);
            this.Controls.Add(this.slider_MaskIntensity);
            this.Controls.Add(this.label_Output);
            this.Controls.Add(this.label_Input);
            this.Controls.Add(this.label_ClickToSave);
            this.Controls.Add(this.label_ClickToOpen);
            this.Controls.Add(this.peeker_NeonIntensity);
            this.Controls.Add(this.peeker_MaskBlur);
            this.Controls.Add(this.label_NeonIntensity_200);
            this.Controls.Add(this.label_NeonIntensity_0);
            this.Controls.Add(this.label_NeonIntensity);
            this.Controls.Add(this.slider_NeonIntensity);
            this.Controls.Add(this.label_MaskBlur);
            this.Controls.Add(this.label_MaskBlur_20);
            this.Controls.Add(this.label_MaskBlur_0);
            this.Controls.Add(this.slider_MaskBlur);
            this.Controls.Add(this.reading_time);
            this.Controls.Add(this.button_Cores_autodetect);
            this.Controls.Add(this.label_Cores_64);
            this.Controls.Add(this.label_Cores_32);
            this.Controls.Add(this.label_Cores_8);
            this.Controls.Add(this.label_Cores_1);
            this.Controls.Add(this.label_Cores);
            this.Controls.Add(this.slider_cores);
            this.Controls.Add(this.label_Library);
            this.Controls.Add(this.select_Library);
            this.Controls.Add(this.checkbox_autorun);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.InputPictureBox);
            this.Controls.Add(this.OutputPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Neonify";
            this.Load += new System.EventHandler(this.Constructor);
            ((System.ComponentModel.ISupportInitialize)(this.slider_cores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_MaskBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_NeonIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_MaskIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        // image input-output

        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.PictureBox InputPictureBox;
        private System.Windows.Forms.Label label_ClickToOpen;
        private System.Windows.Forms.OpenFileDialog openImageDialog;


        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.PictureBox OutputPictureBox;
        private System.Windows.Forms.Label label_ClickToSave;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;


        // select library

        private System.Windows.Forms.ComboBox select_Library;
        private System.Windows.Forms.Label label_Library;

        // cores

        private System.Windows.Forms.Label label_Cores;
        private System.Windows.Forms.TrackBar slider_cores;
        private System.Windows.Forms.Label label_Cores_1;
        private System.Windows.Forms.Label label_Cores_8;
        private System.Windows.Forms.Label label_Cores_16;
        private System.Windows.Forms.Label label_Cores_32;
        private System.Windows.Forms.Label label_Cores_64;
        private System.Windows.Forms.Label peeker_Cores;
        private System.Windows.Forms.Button button_Cores_autodetect;

        // mask blur

        private System.Windows.Forms.Label label_MaskBlur;
        private System.Windows.Forms.TrackBar slider_MaskBlur;
        private System.Windows.Forms.Label label_MaskBlur_0;
        private System.Windows.Forms.Label label_MaskBlur_20;
        private System.Windows.Forms.Label peeker_MaskBlur;

        // mask intensity

        private System.Windows.Forms.Label label_MaskIntensity;
        private System.Windows.Forms.TrackBar slider_MaskIntensity;
        private System.Windows.Forms.Label label_MaskIntensity_0;
        private System.Windows.Forms.Label label_MaskIntensity_100;
        private System.Windows.Forms.Label label_MaskIntensity_200;
        private System.Windows.Forms.Label peeker_MaskIntensity;

        // neon intensity

        private System.Windows.Forms.Label label_NeonIntensity;
        private System.Windows.Forms.TrackBar slider_NeonIntensity;
        private System.Windows.Forms.Label label_NeonIntensity_0;
        private System.Windows.Forms.Label label_NeonIntensity_200;
        private System.Windows.Forms.Label peeker_NeonIntensity;

        // run

        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.CheckBox checkbox_autorun;
        private System.Windows.Forms.Label reading_time;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label_ProgressBar;
        private System.Windows.Forms.TextBox Console;
    }
}