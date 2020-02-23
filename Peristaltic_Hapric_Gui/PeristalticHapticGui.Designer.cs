namespace Peristaltic_Haptic_Gui
{
    partial class PeristalticHapticActuator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeristalticHapticActuator));
            this.frequencyBox = new System.Windows.Forms.TextBox();
            this.amplitudeBox = new System.Windows.Forms.TextBox();
            this.periodBox = new System.Windows.Forms.TextBox();
            this.frequency = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Kill = new System.Windows.Forms.Button();
            this.Max = new System.Windows.Forms.Button();
            this.Min = new System.Windows.Forms.Button();
            this.ChartFirstServo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Hz = new System.Windows.Forms.Label();
            this.amplitudeUnit = new System.Windows.Forms.Label();
            this.periodUnit = new System.Windows.Forms.Label();
            this.sinRadioButton = new System.Windows.Forms.RadioButton();
            this.triangleRadioButton = new System.Windows.Forms.RadioButton();
            this.WaveformLabel = new System.Windows.Forms.Label();
            this.sineTriangleRadioButton = new System.Windows.Forms.RadioButton();
            this.triangleSineRadioButton = new System.Windows.Forms.RadioButton();
            this.positiveSawtoothRadioButton = new System.Windows.Forms.RadioButton();
            this.negativeSawtoothRadioButton = new System.Windows.Forms.RadioButton();
            this.connectingPortsButton = new System.Windows.Forms.Button();
            this.servo12Label = new System.Windows.Forms.Label();
            this.com1 = new System.Windows.Forms.Label();
            this.com2 = new System.Windows.Forms.Label();
            this.servo34Label = new System.Windows.Forms.Label();
            this.com3 = new System.Windows.Forms.Label();
            this.servo56Label = new System.Windows.Forms.Label();
            this.com4 = new System.Windows.Forms.Label();
            this.servo78Label = new System.Windows.Forms.Label();
            this.BatteryProgressLabel = new System.Windows.Forms.Label();
            this.startServoTrackBar = new System.Windows.Forms.TrackBar();
            this.startServoSelection_Label = new System.Windows.Forms.Label();
            this.peristalticMotion_Checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startServoTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // frequencyBox
            // 
            this.frequencyBox.Location = new System.Drawing.Point(78, 12);
            this.frequencyBox.Name = "frequencyBox";
            this.frequencyBox.Size = new System.Drawing.Size(38, 20);
            this.frequencyBox.TabIndex = 0;
            this.frequencyBox.TextChanged += new System.EventHandler(this.FrequencyBox_Click);
            // 
            // amplitudeBox
            // 
            this.amplitudeBox.Location = new System.Drawing.Point(78, 42);
            this.amplitudeBox.Name = "amplitudeBox";
            this.amplitudeBox.Size = new System.Drawing.Size(38, 20);
            this.amplitudeBox.TabIndex = 1;
            this.amplitudeBox.Click += new System.EventHandler(this.AmplitudeBox_Click);
            this.amplitudeBox.TextChanged += new System.EventHandler(this.AmplitudeBox_Click);
            // 
            // periodBox
            // 
            this.periodBox.Location = new System.Drawing.Point(78, 73);
            this.periodBox.Name = "periodBox";
            this.periodBox.Size = new System.Drawing.Size(38, 20);
            this.periodBox.TabIndex = 3;
            this.periodBox.Click += new System.EventHandler(this.CycleNumBox_Click);
            this.periodBox.TextChanged += new System.EventHandler(this.CycleNumBox_Click);
            // 
            // frequency
            // 
            this.frequency.AutoSize = true;
            this.frequency.Location = new System.Drawing.Point(19, 15);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(57, 13);
            this.frequency.TabIndex = 4;
            this.frequency.Text = "Frequency";
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(19, 45);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(53, 13);
            this.amplitudeLabel.TabIndex = 5;
            this.amplitudeLabel.Text = "Amplitude";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(19, 76);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(37, 13);
            this.periodLabel.TabIndex = 7;
            this.periodLabel.Text = "Period";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(22, 409);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(120, 58);
            this.Send.TabIndex = 8;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(22, 322);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(120, 23);
            this.Open.TabIndex = 9;
            this.Open.Text = "Connect";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Kill
            // 
            this.Kill.Location = new System.Drawing.Point(22, 380);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(120, 23);
            this.Kill.TabIndex = 10;
            this.Kill.Text = "Disconnect";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.KillButton_Click);
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(22, 473);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(120, 23);
            this.Max.TabIndex = 11;
            this.Max.Text = "Donning Max";
            this.Max.UseVisualStyleBackColor = true;
            this.Max.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(22, 502);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(120, 23);
            this.Min.TabIndex = 12;
            this.Min.Text = "Donning Min";
            this.Min.UseVisualStyleBackColor = true;
            this.Min.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // ChartFirstServo
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartFirstServo.ChartAreas.Add(chartArea1);
            this.ChartFirstServo.Location = new System.Drawing.Point(150, -1);
            this.ChartFirstServo.Name = "ChartFirstServo";
            this.ChartFirstServo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartFirstServo.Series.Add(series1);
            this.ChartFirstServo.Size = new System.Drawing.Size(791, 532);
            this.ChartFirstServo.TabIndex = 13;
            this.ChartFirstServo.Text = "ChartFirstServo";
            // 
            // Hz
            // 
            this.Hz.AutoSize = true;
            this.Hz.Location = new System.Drawing.Point(122, 15);
            this.Hz.Name = "Hz";
            this.Hz.Size = new System.Drawing.Size(20, 13);
            this.Hz.TabIndex = 14;
            this.Hz.Text = "Hz";
            // 
            // amplitudeUnit
            // 
            this.amplitudeUnit.AutoSize = true;
            this.amplitudeUnit.Location = new System.Drawing.Point(122, 45);
            this.amplitudeUnit.Name = "amplitudeUnit";
            this.amplitudeUnit.Size = new System.Drawing.Size(15, 13);
            this.amplitudeUnit.TabIndex = 15;
            this.amplitudeUnit.Text = "%";
            // 
            // periodUnit
            // 
            this.periodUnit.AutoSize = true;
            this.periodUnit.Location = new System.Drawing.Point(122, 76);
            this.periodUnit.Name = "periodUnit";
            this.periodUnit.Size = new System.Drawing.Size(12, 13);
            this.periodUnit.TabIndex = 17;
            this.periodUnit.Text = "s";
            // 
            // sinRadioButton
            // 
            this.sinRadioButton.AutoSize = true;
            this.sinRadioButton.Location = new System.Drawing.Point(32, 128);
            this.sinRadioButton.Name = "sinRadioButton";
            this.sinRadioButton.Size = new System.Drawing.Size(46, 17);
            this.sinRadioButton.TabIndex = 18;
            this.sinRadioButton.TabStop = true;
            this.sinRadioButton.Text = "Sine";
            this.sinRadioButton.UseVisualStyleBackColor = true;
            this.sinRadioButton.CheckedChanged += new System.EventHandler(this.SinRadioButton_CheckedChanged);
            // 
            // triangleRadioButton
            // 
            this.triangleRadioButton.AutoSize = true;
            this.triangleRadioButton.Location = new System.Drawing.Point(32, 151);
            this.triangleRadioButton.Name = "triangleRadioButton";
            this.triangleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.triangleRadioButton.TabIndex = 19;
            this.triangleRadioButton.TabStop = true;
            this.triangleRadioButton.Text = "Triangle";
            this.triangleRadioButton.UseVisualStyleBackColor = true;
            this.triangleRadioButton.CheckedChanged += new System.EventHandler(this.TriangleRadioButton_CheckedChanged);
            // 
            // WaveformLabel
            // 
            this.WaveformLabel.AutoSize = true;
            this.WaveformLabel.Location = new System.Drawing.Point(19, 106);
            this.WaveformLabel.Name = "WaveformLabel";
            this.WaveformLabel.Size = new System.Drawing.Size(59, 13);
            this.WaveformLabel.TabIndex = 20;
            this.WaveformLabel.Text = "Waveform:";
            // 
            // sineTriangleRadioButton
            // 
            this.sineTriangleRadioButton.AutoSize = true;
            this.sineTriangleRadioButton.Location = new System.Drawing.Point(32, 174);
            this.sineTriangleRadioButton.Name = "sineTriangleRadioButton";
            this.sineTriangleRadioButton.Size = new System.Drawing.Size(87, 17);
            this.sineTriangleRadioButton.TabIndex = 23;
            this.sineTriangleRadioButton.TabStop = true;
            this.sineTriangleRadioButton.Text = "Sine Triangle";
            this.sineTriangleRadioButton.UseVisualStyleBackColor = true;
            this.sineTriangleRadioButton.CheckedChanged += new System.EventHandler(this.sineTriangleRadioButton_CheckedChanged);
            // 
            // triangleSineRadioButton
            // 
            this.triangleSineRadioButton.AutoSize = true;
            this.triangleSineRadioButton.Location = new System.Drawing.Point(32, 198);
            this.triangleSineRadioButton.Name = "triangleSineRadioButton";
            this.triangleSineRadioButton.Size = new System.Drawing.Size(87, 17);
            this.triangleSineRadioButton.TabIndex = 24;
            this.triangleSineRadioButton.TabStop = true;
            this.triangleSineRadioButton.Text = "Triangle Sine";
            this.triangleSineRadioButton.UseVisualStyleBackColor = true;
            this.triangleSineRadioButton.CheckedChanged += new System.EventHandler(this.triangleSineRadioButton_CheckedChanged);
            // 
            // positiveSawtoothRadioButton
            // 
            this.positiveSawtoothRadioButton.AutoSize = true;
            this.positiveSawtoothRadioButton.Location = new System.Drawing.Point(32, 222);
            this.positiveSawtoothRadioButton.Name = "positiveSawtoothRadioButton";
            this.positiveSawtoothRadioButton.Size = new System.Drawing.Size(110, 17);
            this.positiveSawtoothRadioButton.TabIndex = 25;
            this.positiveSawtoothRadioButton.TabStop = true;
            this.positiveSawtoothRadioButton.Text = "Positive Sawtooth";
            this.positiveSawtoothRadioButton.UseVisualStyleBackColor = true;
            this.positiveSawtoothRadioButton.CheckedChanged += new System.EventHandler(this.positiveSawtoothRadioButton_CheckedChanged);
            // 
            // negativeSawtoothRadioButton
            // 
            this.negativeSawtoothRadioButton.AutoSize = true;
            this.negativeSawtoothRadioButton.Location = new System.Drawing.Point(32, 246);
            this.negativeSawtoothRadioButton.Name = "negativeSawtoothRadioButton";
            this.negativeSawtoothRadioButton.Size = new System.Drawing.Size(116, 17);
            this.negativeSawtoothRadioButton.TabIndex = 26;
            this.negativeSawtoothRadioButton.TabStop = true;
            this.negativeSawtoothRadioButton.Text = "Negative Sawtooth";
            this.negativeSawtoothRadioButton.UseVisualStyleBackColor = true;
            this.negativeSawtoothRadioButton.CheckedChanged += new System.EventHandler(this.negativeSawtoothRadioButton_CheckedChanged);
            // 
            // connectingPortsButton
            // 
            this.connectingPortsButton.Location = new System.Drawing.Point(22, 293);
            this.connectingPortsButton.Name = "connectingPortsButton";
            this.connectingPortsButton.Size = new System.Drawing.Size(120, 23);
            this.connectingPortsButton.TabIndex = 27;
            this.connectingPortsButton.Text = "Connecting Ports";
            this.connectingPortsButton.UseVisualStyleBackColor = true;
            this.connectingPortsButton.Click += new System.EventHandler(this.connectingPortsButton_Click);
            // 
            // servo12Label
            // 
            this.servo12Label.AutoSize = true;
            this.servo12Label.Location = new System.Drawing.Point(23, 529);
            this.servo12Label.Name = "servo12Label";
            this.servo12Label.Size = new System.Drawing.Size(82, 13);
            this.servo12Label.TabIndex = 28;
            this.servo12Label.Text = "Servos 1 and 2:";
            // 
            // com1
            // 
            this.com1.AutoSize = true;
            this.com1.Location = new System.Drawing.Point(102, 529);
            this.com1.Name = "com1";
            this.com1.Size = new System.Drawing.Size(13, 13);
            this.com1.TabIndex = 29;
            this.com1.Text = "--";
            // 
            // com2
            // 
            this.com2.AutoSize = true;
            this.com2.Location = new System.Drawing.Point(102, 542);
            this.com2.Name = "com2";
            this.com2.Size = new System.Drawing.Size(13, 13);
            this.com2.TabIndex = 31;
            this.com2.Text = "--";
            // 
            // servo34Label
            // 
            this.servo34Label.AutoSize = true;
            this.servo34Label.Location = new System.Drawing.Point(23, 542);
            this.servo34Label.Name = "servo34Label";
            this.servo34Label.Size = new System.Drawing.Size(82, 13);
            this.servo34Label.TabIndex = 30;
            this.servo34Label.Text = "Servos 3 and 4:";
            // 
            // com3
            // 
            this.com3.AutoSize = true;
            this.com3.Location = new System.Drawing.Point(102, 555);
            this.com3.Name = "com3";
            this.com3.Size = new System.Drawing.Size(13, 13);
            this.com3.TabIndex = 33;
            this.com3.Text = "--";
            // 
            // servo56Label
            // 
            this.servo56Label.AutoSize = true;
            this.servo56Label.Location = new System.Drawing.Point(23, 555);
            this.servo56Label.Name = "servo56Label";
            this.servo56Label.Size = new System.Drawing.Size(82, 13);
            this.servo56Label.TabIndex = 32;
            this.servo56Label.Text = "Servos 5 and 6:";
            // 
            // com4
            // 
            this.com4.AutoSize = true;
            this.com4.Location = new System.Drawing.Point(102, 568);
            this.com4.Name = "com4";
            this.com4.Size = new System.Drawing.Size(13, 13);
            this.com4.TabIndex = 35;
            this.com4.Text = "--";
            // 
            // servo78Label
            // 
            this.servo78Label.AutoSize = true;
            this.servo78Label.Location = new System.Drawing.Point(23, 568);
            this.servo78Label.Name = "servo78Label";
            this.servo78Label.Size = new System.Drawing.Size(82, 13);
            this.servo78Label.TabIndex = 34;
            this.servo78Label.Text = "Servos 7 and 8:";
            // 
            // BatteryProgressLabel
            // 
            this.BatteryProgressLabel.AutoSize = true;
            this.BatteryProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.BatteryProgressLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.BatteryProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatteryProgressLabel.Location = new System.Drawing.Point(22, 348);
            this.BatteryProgressLabel.Name = "BatteryProgressLabel";
            this.BatteryProgressLabel.Size = new System.Drawing.Size(77, 20);
            this.BatteryProgressLabel.TabIndex = 37;
            this.BatteryProgressLabel.Text = "Battery: ";
            // 
            // startServoTrackBar
            // 
            this.startServoTrackBar.Location = new System.Drawing.Point(296, 529);
            this.startServoTrackBar.Name = "startServoTrackBar";
            this.startServoTrackBar.Size = new System.Drawing.Size(645, 45);
            this.startServoTrackBar.TabIndex = 38;
            this.startServoTrackBar.Scroll += new System.EventHandler(this.startServo_trackBarScroll);
            // 
            // startServoSelection_Label
            // 
            this.startServoSelection_Label.AutoSize = true;
            this.startServoSelection_Label.Location = new System.Drawing.Point(147, 534);
            this.startServoSelection_Label.Name = "startServoSelection_Label";
            this.startServoSelection_Label.Size = new System.Drawing.Size(143, 13);
            this.startServoSelection_Label.TabIndex = 44;
            this.startServoSelection_Label.Text = "Start of the peristaltic motion:";
            // 
            // peristalticMotion_Checkbox
            // 
            this.peristalticMotion_Checkbox.AutoSize = true;
            this.peristalticMotion_Checkbox.Location = new System.Drawing.Point(150, 550);
            this.peristalticMotion_Checkbox.Name = "peristalticMotion_Checkbox";
            this.peristalticMotion_Checkbox.Size = new System.Drawing.Size(106, 17);
            this.peristalticMotion_Checkbox.TabIndex = 45;
            this.peristalticMotion_Checkbox.Text = "Peristaltic Motion";
            this.peristalticMotion_Checkbox.UseVisualStyleBackColor = true;
            this.peristalticMotion_Checkbox.Click += new System.EventHandler(this.peristalticMotion_Checkbox_Click);
            // 
            // PeristalticHapticActuator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(942, 585);
            this.Controls.Add(this.peristalticMotion_Checkbox);
            this.Controls.Add(this.startServoSelection_Label);
            this.Controls.Add(this.startServoTrackBar);
            this.Controls.Add(this.BatteryProgressLabel);
            this.Controls.Add(this.com4);
            this.Controls.Add(this.servo78Label);
            this.Controls.Add(this.com3);
            this.Controls.Add(this.servo56Label);
            this.Controls.Add(this.com2);
            this.Controls.Add(this.servo34Label);
            this.Controls.Add(this.com1);
            this.Controls.Add(this.servo12Label);
            this.Controls.Add(this.connectingPortsButton);
            this.Controls.Add(this.negativeSawtoothRadioButton);
            this.Controls.Add(this.positiveSawtoothRadioButton);
            this.Controls.Add(this.triangleSineRadioButton);
            this.Controls.Add(this.sineTriangleRadioButton);
            this.Controls.Add(this.WaveformLabel);
            this.Controls.Add(this.triangleRadioButton);
            this.Controls.Add(this.sinRadioButton);
            this.Controls.Add(this.periodUnit);
            this.Controls.Add(this.amplitudeUnit);
            this.Controls.Add(this.Hz);
            this.Controls.Add(this.ChartFirstServo);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Kill);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.periodLabel);
            this.Controls.Add(this.amplitudeLabel);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.periodBox);
            this.Controls.Add(this.amplitudeBox);
            this.Controls.Add(this.frequencyBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PeristalticHapticActuator";
            this.Text = "Peristaltic Haptic Actuator";
            this.Load += new System.EventHandler(this.PeristalticHapticActuator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startServoTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox frequencyBox;
        private System.Windows.Forms.TextBox amplitudeBox;
        private System.Windows.Forms.TextBox periodBox;
        private System.Windows.Forms.Label frequency;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Button Max;
        private System.Windows.Forms.Button Min;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartFirstServo;
        private System.Windows.Forms.Label Hz;
        private System.Windows.Forms.Label amplitudeUnit;
        private System.Windows.Forms.Label periodUnit;
        private System.Windows.Forms.RadioButton sinRadioButton;
        private System.Windows.Forms.RadioButton triangleRadioButton;
        private System.Windows.Forms.Label WaveformLabel;
        private System.Windows.Forms.RadioButton sineTriangleRadioButton;
        private System.Windows.Forms.RadioButton triangleSineRadioButton;
        private System.Windows.Forms.RadioButton positiveSawtoothRadioButton;
        private System.Windows.Forms.RadioButton negativeSawtoothRadioButton;
        private System.Windows.Forms.Button connectingPortsButton;
        private System.Windows.Forms.Label servo12Label;
        private System.Windows.Forms.Label com1;
        private System.Windows.Forms.Label com2;
        private System.Windows.Forms.Label servo34Label;
        private System.Windows.Forms.Label com3;
        private System.Windows.Forms.Label servo56Label;
        private System.Windows.Forms.Label com4;
        private System.Windows.Forms.Label servo78Label;
        private System.Windows.Forms.Label BatteryProgressLabel;
        private System.Windows.Forms.TrackBar startServoTrackBar;
        private System.Windows.Forms.Label startServoSelection_Label;
        private System.Windows.Forms.CheckBox peristalticMotion_Checkbox;
    }
}

