using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peristaltic_Hapric_Gui
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
        private static double minPhase = 0;

        private static double cyclNum = 1;
        private static double maxCyclNum = 100;
        private static double minCyclNum = 0;

        private static double yAxisShift = amplitude / 2; 
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
            periodBox.Text = cyclNum.ToString(); 
        }

        private void CalculateWaveform()
        {
            var sinData = new System.Windows.Forms.DataVisualization.Charting.Series();
            sinData.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartFirstServo.Series.Clear();
            for (int i = 0; i <= cyclNum*1000; i++)
            {
                var doubleCounter = Convert.ToDouble(i)/1000;
                sinData.Points.AddXY(doubleCounter, ((amplitude/2) * Math.Sin(2 * Math.PI * fc * doubleCounter + phase)+ (amplitude/2))); 
                
            }
            ChartFirstServo.Series.Add(sinData);
            ChartFirstServo.ChartAreas[0].AxisX.Minimum = 0;
            ChartFirstServo.ChartAreas[0].AxisX.Maximum = cyclNum;
            ChartFirstServo.ChartAreas[0].AxisY.Maximum = 100;
            ChartFirstServo.ChartAreas[0].AxisY.Minimum = 0;
            ChartFirstServo.ChartAreas[0].AxisY.LabelStyle.Format = "{###}%"; 


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
                if (result && newCyc <= maxCyclNum && newCyc >= minCyclNum)
                {
                    cyclNum = newCyc;
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
    }
}
