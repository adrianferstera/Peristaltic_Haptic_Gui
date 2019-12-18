namespace Peristaltic_Hapric_Gui
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeristalticHapticActuator));
            this.frequencyBox = new System.Windows.Forms.TextBox();
            this.amplitudeBox = new System.Windows.Forms.TextBox();
            this.phaseBox = new System.Windows.Forms.TextBox();
            this.numberCycles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Kill = new System.Windows.Forms.Button();
            this.Max = new System.Windows.Forms.Button();
            this.Min = new System.Windows.Forms.Button();
            this.ChartFirstServo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).BeginInit();
            this.SuspendLayout();
            // 
            // frequencyBox
            // 
            this.frequencyBox.Location = new System.Drawing.Point(78, 32);
            this.frequencyBox.Name = "frequencyBox";
            this.frequencyBox.Size = new System.Drawing.Size(38, 20);
            this.frequencyBox.TabIndex = 0;
            this.frequencyBox.TextChanged += new System.EventHandler(this.FrequencyBox_Click);
            // 
            // amplitudeBox
            // 
            this.amplitudeBox.Location = new System.Drawing.Point(78, 82);
            this.amplitudeBox.Name = "amplitudeBox";
            this.amplitudeBox.Size = new System.Drawing.Size(38, 20);
            this.amplitudeBox.TabIndex = 1;
            this.amplitudeBox.Click += new System.EventHandler(this.AmplitudeBox_Click);
            this.amplitudeBox.TextChanged += new System.EventHandler(this.AmplitudeBox_Click);
            // 
            // phaseBox
            // 
            this.phaseBox.Location = new System.Drawing.Point(78, 129);
            this.phaseBox.Name = "phaseBox";
            this.phaseBox.Size = new System.Drawing.Size(38, 20);
            this.phaseBox.TabIndex = 2;
            this.phaseBox.Click += new System.EventHandler(this.PhaseBox_Click);
            this.phaseBox.TextChanged += new System.EventHandler(this.PhaseBox_Click);
            // 
            // numberCycles
            // 
            this.numberCycles.Location = new System.Drawing.Point(78, 177);
            this.numberCycles.Name = "numberCycles";
            this.numberCycles.Size = new System.Drawing.Size(38, 20);
            this.numberCycles.TabIndex = 3;
            this.numberCycles.Click += new System.EventHandler(this.CycleNumBox_Click);
            this.numberCycles.TextChanged += new System.EventHandler(this.CycleNumBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amplitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "CyclNr";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(413, 199);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(137, 90);
            this.Send.TabIndex = 8;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(623, 199);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(113, 23);
            this.Open.TabIndex = 9;
            this.Open.Text = "OpenConnection";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Kill
            // 
            this.Kill.Location = new System.Drawing.Point(623, 266);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(113, 23);
            this.Kill.TabIndex = 10;
            this.Kill.Text = "Kill Connection";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.KillButton_Click);
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(235, 199);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(110, 23);
            this.Max.TabIndex = 11;
            this.Max.Text = "Donning Max";
            this.Max.UseVisualStyleBackColor = true;
            this.Max.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(235, 266);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(110, 23);
            this.Min.TabIndex = 12;
            this.Min.Text = "Donning Min";
            this.Min.UseVisualStyleBackColor = true;
            this.Min.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // ChartFirstServo
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartFirstServo.ChartAreas.Add(chartArea2);
            this.ChartFirstServo.Location = new System.Drawing.Point(163, -3);
            this.ChartFirstServo.Name = "ChartFirstServo";
            this.ChartFirstServo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ChartFirstServo.Series.Add(series2);
            this.ChartFirstServo.Size = new System.Drawing.Size(635, 196);
            this.ChartFirstServo.TabIndex = 13;
            this.ChartFirstServo.Text = "ChartFirstServo";
            // 
            // PeristalticHapticActuator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChartFirstServo);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Kill);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberCycles);
            this.Controls.Add(this.phaseBox);
            this.Controls.Add(this.amplitudeBox);
            this.Controls.Add(this.frequencyBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PeristalticHapticActuator";
            this.Text = "Peristaltic Haptic Actuator";
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstServo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox frequencyBox;
        private System.Windows.Forms.TextBox amplitudeBox;
        private System.Windows.Forms.TextBox phaseBox;
        private System.Windows.Forms.TextBox numberCycles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Button Max;
        private System.Windows.Forms.Button Min;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartFirstServo;
    }
}

