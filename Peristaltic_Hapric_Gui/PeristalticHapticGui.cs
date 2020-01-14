using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HerkulexApi;
using HerkulexGuiMapper;

namespace Peristaltic_Haptic_Gui
{
    public partial class PeristalticHapticActuator : Form
    {
        private static double fc = 1;
        private double maxFc = 5;
        private double minFc = 0;

        private const int DefaultMinDegree = -60;
        private const int DefaultMaxDegree = 60;


        private static double amplitude = 100;
        private static double maxAmplitude = 100;
        private static double minAmplitude = 0;
        private static int baudrate = 57600;
        private double amplitudeInDec => amplitude / 100;
        private double maxAmplitudeInDec => maxAmplitude / 100;

        private static double phase = 0; //in radian
        private double servoMaxSpeed = 0.00274;

        private static double maxPhase = 360;
        private static double minPhase = -360;

        private static double period = 1;
        private static double maxPeriod = 100;
        private static double minPeriod = 0;

        private double minDegree;
        private double maxDegree;

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
            DisableDependantButtons();
        }

        private void StartupValues()
        {
            minDegree = -60; //only between -60 and 60, otherwise you are going to destroy the hardware
            maxDegree = -minDegree;
            frequencyBox.Text = fc.ToString(CultureInfo.CurrentCulture);
            amplitudeBox.Text = amplitude.ToString(CultureInfo.CurrentCulture);
            phaseBox.Text = phase.ToString(CultureInfo.CurrentCulture);
            periodBox.Text = period.ToString(CultureInfo.CurrentCulture);
            sinRadioButton.Checked = true;
            Open.BackColor = Color.LightGreen;
            Kill.BackColor = Color.Tomato;
            if (availablePorts.Length > 0)
            {
                comboBoxPort.Text = availablePorts[0];
            }

        }

        private void EnableMainButtons()
        {
            Open.Enabled = true;
        }

        private void DisableMainButtons()
        {
            Open.Enabled = false;
        }

        private void EnableDependantButtons()
        {
            Kill.Enabled = true;
            Send.Enabled = true;
            Max.Enabled = true;
            Min.Enabled = true;
            DisableMainButtons();
        }

        private void DisableDependantButtons()
        {
            Kill.Enabled = false;
            Send.Enabled = false;
            Max.Enabled = false;
            Min.Enabled = false;
            EnableMainButtons();
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
                var modifiedPoints = triangleWave.Points.ToList();
                foreach (var el in triangleWave.Points)
                {
                    if (el.XValue < 0 || el.XValue > period)
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
                    maxFc = Math.Ceiling(1 / (servoMaxSpeed * (Math.Abs(minDegree) + Math.Abs(maxDegree)) * 2));
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
                    maxDegree = DefaultMaxDegree * amplitude / 100;
                    minDegree = DefaultMinDegree * amplitude / 100;
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

        private void ChangeAccelerationAccordingToFrequency()
        {
            if (waveformType == WaveformTypes.Triangle)
            {
                foreach (var servo in myServos)
                {
                    try
                    {
                        servo.AccelerationRatio(servo.MinAccRatio);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    
                }
            }
            else if (waveformType == WaveformTypes.Sine)
            {
                foreach (var servo in myServos)
                {
                    var accRatio = Convert.ToInt32((Convert.ToDouble(servo.MinAccRatio + 30 - servo.MaxAccRatio) 
                                                    / maxFc) * fc + servo.MaxAccRatio); //a litle bit treshold to minAccRatio 
                    servo.AccelerationRatio(accRatio);
                }
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            var replayer = new Replayer(minDegree, maxDegree);
            ChangeAccelerationAccordingToFrequency();
            var dataPointValues = waveForm.Points.Select(el => new Datapoint(el.XValue, el.YValues.First()/100));
            try
            {
                replayer.StartSeries(dataPointValues, fc, maxAmplitudeInDec, amplitudeInDec, period, myServos);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            

        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (InitializeServos())
            {
                EnableDependantButtons();
            }
        }

        private bool InitializeServos()
        {
            var port = comboBoxPort.Text;
            if (port.Length == 0)
            {
                var exception = new InvalidOperationException("Did not find the connection port.\n" +
                                                              "If you have not connected the controller yet, please connect it.\n " +
                                                              "If its connected, please check, if you have installed the correct drivers.\n" +
                                                              $"If you have installed the drivers, please make sure that the baud rate is {baudrate} in the control panel.");
                MessageBox.Show(exception.Message);
                return false;
            }
            try
            {
                if (myHerkulexInterface == null)
                {
                    myHerkulexInterface = new HerkulexInterfaceConnector(port, baudrate);
                }
                else
                {
                    myHerkulexInterface.Reopen();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            myServos = new List<HerkulexServo>()
                {new HerkulexServo(219, myHerkulexInterface), new HerkulexServo(218, myHerkulexInterface)};
            try
            {
                foreach (var myServo in myServos)
                {
                    myServo.Status();
                }
            }
            catch (TimeoutException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            foreach (var servo in myServos)
            {
                servo.TorqueOn();
                servo.NeutralPosition = Convert.ToInt32(minDegree);
                servoMaxSpeed = servo.MaxSpeed;

            }

            var taskList = new List<Task>();
            foreach (var servo in myServos)
            {
                var myServoTask = new Task(() => servo.MoveToNeutralPosition());
                taskList.Add(myServoTask);
                myServoTask.Start();
            }

            Task.WaitAll(taskList.ToArray());
            return true;
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            var replayer = new Replayer(minDegree, maxDegree);
            try
            {
                replayer.Move2Position(amplitudeInDec, myServos);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
        private void MinButton_Click(object sender, EventArgs e)
        {
            var replayer = new Replayer(minDegree, maxDegree);
            try
            {
                replayer.Move2Position(maxAmplitudeInDec - amplitudeInDec, myServos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
           
        }
        private void KillButton_Click(object sender, EventArgs e)
        {
            foreach (var servo in myServos)
            {
                servo.TorqueOff();
                servo.Reboot();
            }
            myHerkulexInterface.Close();
            DisableDependantButtons();
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
