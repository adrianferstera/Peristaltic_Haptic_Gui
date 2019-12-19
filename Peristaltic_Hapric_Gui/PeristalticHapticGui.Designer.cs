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
            this.phaseBox = new System.Windows.Forms.TextBox();
            this.periodBox = new System.Windows.Forms.TextBox();
            this.frequency = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.phaseLabel = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Kill = new System.Windows.Forms.Button();
            this.Max = new System.Windows.Forms.Button();
            this.Min = new System.Windows.Forms.Button();
            this.ChartFirstServo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Hz = new System.Windows.Forms.Label();
            this.amplitudeUnit = new System.Windows.Forms.Label();
            this.rad = new System.Windows.Forms.Label();
            this.periodUnit = new System.Windows.Forms.Label();
            this.sinRadioButton = new System.Windows.Forms.RadioButton();
            this.triangleRadioButton = new System.Windows.Forms.RadioButton();
            this.WaveformLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).BeginInit();
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
            // phaseBox
            // 
            this.phaseBox.Location = new System.Drawing.Point(78, 72);
            this.phaseBox.Name = "phaseBox";
            this.phaseBox.Size = new System.Drawing.Size(38, 20);
            this.phaseBox.TabIndex = 2;
            this.phaseBox.Click += new System.EventHandler(this.PhaseBox_Click);
            this.phaseBox.TextChanged += new System.EventHandler(this.PhaseBox_Click);
            // 
            // periodBox
            // 
            this.periodBox.Location = new System.Drawing.Point(78, 102);
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
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(19, 75);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(37, 13);
            this.phaseLabel.TabIndex = 6;
            this.phaseLabel.Text = "Phase";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(19, 105);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(37, 13);
            this.periodLabel.TabIndex = 7;
            this.periodLabel.Text = "Period";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(22, 308);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(120, 58);
            this.Send.TabIndex = 8;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(22, 250);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(120, 23);
            this.Open.TabIndex = 9;
            this.Open.Text = "OpenConnection";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Kill
            // 
            this.Kill.Location = new System.Drawing.Point(22, 279);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(120, 23);
            this.Kill.TabIndex = 10;
            this.Kill.Text = "Kill Connection";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.KillButton_Click);
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(22, 372);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(120, 23);
            this.Max.TabIndex = 11;
            this.Max.Text = "Donning Max";
            this.Max.UseVisualStyleBackColor = true;
            this.Max.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(22, 401);
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
            this.ChartFirstServo.Location = new System.Drawing.Point(150, 0);
            this.ChartFirstServo.Name = "ChartFirstServo";
            this.ChartFirstServo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartFirstServo.Series.Add(series1);
            this.ChartFirstServo.Size = new System.Drawing.Size(651, 450);
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
            // rad
            // 
            this.rad.AutoSize = true;
            this.rad.Location = new System.Drawing.Point(122, 75);
            this.rad.Name = "rad";
            this.rad.Size = new System.Drawing.Size(22, 13);
            this.rad.TabIndex = 16;
            this.rad.Text = "rad";
            // 
            // periodUnit
            // 
            this.periodUnit.AutoSize = true;
            this.periodUnit.Location = new System.Drawing.Point(122, 105);
            this.periodUnit.Name = "periodUnit";
            this.periodUnit.Size = new System.Drawing.Size(22, 13);
            this.periodUnit.TabIndex = 17;
            this.periodUnit.Text = "[   ]";
            // 
            // sinRadioButton
            // 
            this.sinRadioButton.AutoSize = true;
            this.sinRadioButton.Location = new System.Drawing.Point(32, 176);
            this.sinRadioButton.Name = "sinRadioButton";
            this.sinRadioButton.Size = new System.Drawing.Size(46, 17);
            this.sinRadioButton.TabIndex = 18;
            this.sinRadioButton.TabStop = true;
            this.sinRadioButton.Text = "Sine";
            this.sinRadioButton.UseVisualStyleBackColor = true;
            this.sinRadioButton.CheckedChanged += new System.EventHandler(this.sinRadioButton_CheckedChanged);
            // 
            // triangleRadioButton
            // 
            this.triangleRadioButton.AutoSize = true;
            this.triangleRadioButton.Location = new System.Drawing.Point(32, 199);
            this.triangleRadioButton.Name = "triangleRadioButton";
            this.triangleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.triangleRadioButton.TabIndex = 19;
            this.triangleRadioButton.TabStop = true;
            this.triangleRadioButton.Text = "Triangle";
            this.triangleRadioButton.UseVisualStyleBackColor = true;
            this.triangleRadioButton.CheckedChanged += new System.EventHandler(this.triangleRadioButton_CheckedChanged);
            // 
            // WaveformLabel
            // 
            this.WaveformLabel.AutoSize = true;
            this.WaveformLabel.Location = new System.Drawing.Point(19, 154);
            this.WaveformLabel.Name = "WaveformLabel";
            this.WaveformLabel.Size = new System.Drawing.Size(59, 13);
            this.WaveformLabel.TabIndex = 20;
            this.WaveformLabel.Text = "Waveform:";
            // 
            // PeristalticHapticActuator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WaveformLabel);
            this.Controls.Add(this.triangleRadioButton);
            this.Controls.Add(this.sinRadioButton);
            this.Controls.Add(this.periodUnit);
            this.Controls.Add(this.rad);
            this.Controls.Add(this.amplitudeUnit);
            this.Controls.Add(this.Hz);
            this.Controls.Add(this.ChartFirstServo);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Kill);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.periodLabel);
            this.Controls.Add(this.phaseLabel);
            this.Controls.Add(this.amplitudeLabel);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.periodBox);
            this.Controls.Add(this.phaseBox);
            this.Controls.Add(this.amplitudeBox);
            this.Controls.Add(this.frequencyBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PeristalticHapticActuator";
            this.Text = "Peristaltic Haptic Actuator";
            this.Load += new System.EventHandler(this.PeristalticHapticActuator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox frequencyBox;
        private System.Windows.Forms.TextBox amplitudeBox;
        private System.Windows.Forms.TextBox phaseBox;
        private System.Windows.Forms.TextBox periodBox;
        private System.Windows.Forms.Label frequency;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Button Max;
        private System.Windows.Forms.Button Min;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartFirstServo;
        private System.Windows.Forms.Label Hz;
        private System.Windows.Forms.Label amplitudeUnit;
        private System.Windows.Forms.Label rad;
        private System.Windows.Forms.Label periodUnit;
        private System.Windows.Forms.RadioButton sinRadioButton;
        private System.Windows.Forms.RadioButton triangleRadioButton;
        private System.Windows.Forms.Label WaveformLabel;
    }
}

