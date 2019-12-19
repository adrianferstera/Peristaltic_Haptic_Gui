using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peristaltic_Haptic_Gui
{
    public partial class PeristalticHapticActuator : Form
    {
        private static double fc = 1;
        private static double maxFc = 5;
        private static double minFc = 0;

        private static double amplitude = 100;
        private static double maxAmplitude = 100;
        private static double minAmplitude = 0;

        private static double phase = 0;
        private static double maxPhase = 2*Math.PI;
        private static double minPhase = -2 * Math.PI;

        private static double period = 1;
        private static double maxPeriod = 100;
        private static double minPeriod = 0;

        private static WaveformTypes waveformType = WaveformTypes.Sine; 

        private double yAxisShift => amplitude / 2; 
        public PeristalticHapticActuator()
        {
            InitializeComponent();
            CalculateWaveform();
            StartupValues();
        }

        private void StartupValues()
        {
            frequencyBox.Text = fc.ToString();
            amplitudeBox.Text = amplitude.ToString();
            phaseBox.Text = phase.ToString();
            periodBox.Text = period.ToString();
            sinRadioButton.Checked = true; 
        }

        private void CalculateWaveform()
        {
           
            
            ChartFirstServo.Series.Clear();
            var waveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            var xAxisWaveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            for (int i = 0; i < period * 10; i++)
            {
                xAxisWaveForm.Points.AddXY(Convert.ToDouble(i) / 100, 0); 
            }
            if (waveformType == WaveformTypes.Sine)
            {
                waveForm = CalculateSineWave();
            }else if (waveformType == WaveformTypes.Triangle)
            {
                waveForm = calculateTriangleWave(); 
            }
            ChartFirstServo.Series.Add(waveForm);
            ChartFirstServo.Series.Add(xAxisWaveForm); 
            ChartFirstServo.ChartAreas[0].AxisX.Minimum = 0;
            ChartFirstServo.ChartAreas[0].AxisX.Maximum = period;
            ChartFirstServo.ChartAreas[0].AxisY.Maximum = maxAmplitude;
            ChartFirstServo.ChartAreas[0].AxisY.Minimum = minAmplitude;
            ChartFirstServo.ChartAreas[0].AxisY.LabelStyle.Format = "{###}%";
            ChartFirstServo.ChartAreas[0].AxisX.LabelStyle.Format = "{0.00}s";
            ChartFirstServo.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            ChartFirstServo.ChartAreas[0].AxisX.MajorGrid.Interval = 0.1;
        }

        private System.Windows.Forms.DataVisualization.Charting.Series CalculateSineWave()
        {
            var sinData = new System.Windows.Forms.DataVisualization.Charting.Series();
            sinData.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i <= period * 1000; i++)
            {
                var doubleCounter = Convert.ToDouble(i) / 1000;
                sinData.Points.AddXY(doubleCounter, ((yAxisShift) * Math.Sin(2 * Math.PI * fc * doubleCounter + phase-Math.PI/2) + (yAxisShift)));
            }

            return sinData; 
        }
        private System.Windows.Forms.DataVisualization.Charting.Series calculateTriangleWave()
        {
            var slope = amplitude*fc*2;
            var triangleWave = new System.Windows.Forms.DataVisualization.Charting.Series();
            triangleWave.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            triangleWave.Points.AddXY(0, 0);
            for (int i = 0; i < period*fc; i++)
            {
                var gabs = 1.0/fc;
                var counterDouble = Convert.ToDouble(i); 
                triangleWave.Points.AddXY(counterDouble/fc + gabs/2, amplitude);
                triangleWave.Points.AddXY(counterDouble/fc + gabs, 0);
            }
            return triangleWave; 
        }
        private void FrequencyBox_Click(object sender, EventArgs e)
        {
            var value = frequencyBox.Text;
           if (value.Length > 0)
            {
                var result = double.TryParse(value, out var newfc);
                if (result && newfc <= maxFc && newfc >= minFc)
                {
                    fc = newfc;
                    CalculateWaveform();
                }
            }
        }
        private void PhaseBox_Click(object sender, EventArgs e)
        {
            var value = phaseBox.Text;
            if (value.Length > 0)
            {
                var result = double.TryParse(value, out var newPhase);
                if (result && newPhase <= maxPhase && newPhase >= minPhase)
                {
                    phase = newPhase;
                    CalculateWaveform();
                }
            }
        }
        private void AmplitudeBox_Click(object sender, EventArgs e)
        {
            var value = amplitudeBox.Text;
            if (value.Length > 0)
            {
                var result = double.TryParse(value, out var newAmplitude);
                if (result && newAmplitude <= maxAmplitude && newAmplitude >= minAmplitude)
                {
                    amplitude = newAmplitude;
                    CalculateWaveform();
                }
                
            }
        }
        private void CycleNumBox_Click(object sender, EventArgs e)
        {
            var value = periodBox.Text;
            if (value.Length > 0)
            {
                var result = double.TryParse(value, out var newCyc);
                if (result && newCyc <= maxPeriod && newCyc >= minPeriod)
                {
                    period = newCyc;
                    CalculateWaveform();
                }
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {

            
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {

        }
        private void MaxButton_Click(object sender, EventArgs e)
        {

        }
        private void MinButton_Click(object sender, EventArgs e)
        {

        }
        private void KillButton_Click(object sender, EventArgs e)
        {

        }

        private void PeristalticHapticActuator_Load(object sender, EventArgs e)
        {

        }

        private void SinRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sinRadioButton.Checked)
            {
                triangleRadioButton.Checked = false;
                waveformType = WaveformTypes.Sine; 
                CalculateWaveform();
            }

        }

        private void TriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (triangleRadioButton.Checked)
            {
                sinRadioButton.Checked = false;
                waveformType = WaveformTypes.Triangle;
                CalculateWaveform();
            }
        }
    }
}
