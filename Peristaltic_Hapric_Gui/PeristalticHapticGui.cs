using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HerkulexApi;

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

        private static double phase = 0; //in radian

        private static double maxPhase = 360;
        private static double minPhase = -360;

        private static double period = 1;
        private static double maxPeriod = 100;
        private static double minPeriod = 0;

        private static double spacing = 100;
        private System.Windows.Forms.DataVisualization.Charting.Series waveForm;
        private List<HerkulexServo> myServos = new List<HerkulexServo>();
        private HerkulexInterfaceConnector myHerkulexInterface;
        private string[] availablePorts => HerkulexInterfaceConnector.AvailableSerialPorts();

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
            Open.BackColor = Color.LightGreen;
            Kill.BackColor = Color.OrangeRed;
            if (availablePorts.Length > 0)
            {
                comboBoxPort.Text = availablePorts[0];
            }

        }

        private void CalculateWaveform()
        {
            ChartFirstServo.Series.Clear();
            waveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            var xAxisWaveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            for (int i = 0; i <= period * 10; i++)
            {
                xAxisWaveForm.Points.AddXY(Convert.ToDouble(i), 0);
            }
            if (waveformType == WaveformTypes.Sine)
            {
                waveForm = CalculateSineWave();
            }
            else if (waveformType == WaveformTypes.Triangle)
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
            ChartFirstServo.ChartAreas[0].AxisX.LabelStyle.Format = "{0.##}s";
            ChartFirstServo.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
        }

        private System.Windows.Forms.DataVisualization.Charting.Series CalculateSineWave()
        {
            var sinData = new System.Windows.Forms.DataVisualization.Charting.Series();
            sinData.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i <= period * 1000; i++)
            {
                var doubleCounter = Convert.ToDouble(i) / 1000;
                sinData.Points.AddXY(doubleCounter, ((yAxisShift) * Math.Sin(2 * Math.PI * fc * doubleCounter + phase - Math.PI / 2) + (yAxisShift)));
            }
            return sinData;
        }
        private System.Windows.Forms.DataVisualization.Charting.Series calculateTriangleWave()
        {

            var triangleWave = new System.Windows.Forms.DataVisualization.Charting.Series();
            triangleWave.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            var phaseInSec = phase * 0.5 / Math.PI;
            triangleWave.Points.AddXY(0 - phaseInSec, 0);
            for (int i = 0; i < 2 * period * fc; i++)
            {
                var gabs = 1.0 / fc;
                var counterDouble = Convert.ToDouble(i);
                for (int j = 1; j <= spacing; j++)
                {
                    triangleWave.Points.AddXY(counterDouble / fc - phaseInSec + (gabs / 2) / spacing * j, amplitude / spacing * j);
                }
                for (int j = 1; j <= spacing; j++)
                {
                    triangleWave.Points.AddXY(counterDouble / fc + gabs / 2 - phaseInSec + gabs / 2 / spacing * j, amplitude - amplitude / spacing * j);
                }
                // triangleWave.Points.AddXY(counterDouble/fc + gabs/2- phaseInSec, amplitude);
                //triangleWave.Points.AddXY(counterDouble/fc + gabs- phaseInSec, 0);
                var modifiedPoints = triangleWave.Points.ToList(); 
                foreach (var el in triangleWave.Points)
                {
                    if (el.XValue<0 || el.XValue>period)
                    {
                        modifiedPoints.Remove(el); 
                    }
                }
                triangleWave.Points.Clear();
                foreach (var el in modifiedPoints)
                {
                    triangleWave.Points.Add(el); 
                }
            }
            return triangleWave;
        }
        private void FrequencyBox_Click(object sender, EventArgs e)
        {
            var value = frequencyBox.Text;
            if (value.Length > 0)
            {
                var result = double.TryParse(value, out var newFc);
                if (result && newFc <= maxFc && newFc >= minFc)
                {
                    fc = newFc;
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
                    var convertedValue = newPhase * Math.PI / 180;//phase has to be in radians
                    if (convertedValue < 0) phase = convertedValue + 2 * Math.PI;
                    else phase = convertedValue;
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
            var yPoints = waveForm.Points.Select(el => el.YValues[0]).ToList();
            var xPoints = waveForm.Points.Select(el => el.XValue);
            var yMax = yPoints.Max();
            var yMin = xPoints.Min();
            var yMaxValueIndex = yPoints.IndexOf(yMax);
            var yMinValueIndex = yPoints.IndexOf(yMin);
            var pointsList = new List<double>();
            if (yMinValueIndex > yMaxValueIndex)
            {
                pointsList.Add(yMin);
                pointsList.Add(yMax);
            }
            else
            {
                pointsList.Add(yMax);
                pointsList.Add(yMin);
            }
            var playListServos = new List<double>();
            for (int i = 0; i < period; i++)
            {
                playListServos.AddRange(pointsList);
            }
            if (Math.Abs(yPoints.First() - playListServos.First()) > 0.01)
            {
                playListServos.Insert(0, yPoints.First());
            }

            if (Math.Abs(yPoints.Last() - playListServos.Last()) > 0.01)
            {
                playListServos.Add(yPoints.Last());
            }

            playListServos = playListServos.Select(el => el / 100).ToList(); 
            var replayer = new Replayer(-60, 60);
            replayer.Start(new List<double>(){playListServos.First()}, 100, myServos);
            replayer.Start(playListServos, 400, myServos);

        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            var port = comboBoxPort.Text;
            if (port.Length == 0)
            {
                throw new InvalidOperationException("You have not selected a COM port yet or it was not found.");
            }
            myHerkulexInterface = new HerkulexInterfaceConnector(port, 57600);
            myServos.Add(new HerkulexServo(219, myHerkulexInterface));
            myServos.Add(new HerkulexServo(218, myHerkulexInterface));
            foreach (var servo in myServos)
            {
                servo.TorqueOn();
                servo.NeutralPosition = 60; 
                servo.MoveToNeutralPosition();
            }
        }
        private void MaxButton_Click(object sender, EventArgs e)
        {

        }
        private void MinButton_Click(object sender, EventArgs e)
        {

        }
        private void KillButton_Click(object sender, EventArgs e)
        {
            myHerkulexInterface.Close();
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

        private void comboBoxPort_DropDown(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            var ports = availablePorts;
            foreach (var port in ports)
            {
                comboBoxPort.Items.Add(port);
            }
        }
    }
}
