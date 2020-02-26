/*
This file was created by Adrian Ferstera
Email: adrian@ferstera.com
Standard MIT License
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ArduinoConnector;
using HerkulexApi;
using HerkulexGuiMapper;
using Timer = System.Windows.Forms.Timer;

namespace Peristaltic_Haptic_Gui
{
    public partial class PeristalticHapticActuator : Form
    {
        private static double fc = 1;
        private double maxFc = 5;
        private double minFc = 0;
        private static double amplitude = 100;
        private static double maxAmplitude = 100;
        private static double minAmplitude = 0;
        private static int baudrate = 57600;
        private double amplitudeInDec => amplitude / 100;
        private double maxAmplitudeInDec => maxAmplitude / 100;


        // private static double phase = 0; //in radian
        private double servoMaxSpeed = 0.00274;

        private static double maxPhase = 360;
        private static double minPhase = -360;

        private static double period = 1;
        private static double maxPeriod = 100;
        private static double minPeriod = 0;

        private readonly double minDegree = -60;//only between -60 and 30, otherwise you are going to destroy the hardware
        private readonly double maxDegree = 30;
        private string[] selectedServoPorts => selectedServoPortsList.ToArray();
        private List<string> selectedServoPortsList;
        private bool spatialOnlyPattern = false;

        private double batteryLevel = -1;
        private int startServo = 1; //start servo between 1 and 8
        private Arduino arduinoBattery;
        private Timer myTimer = new Timer();

        //private static double spacing = 100;
        private System.Windows.Forms.DataVisualization.Charting.Series waveForm;
        private List<RadioButton> radioButtonList;
        private List<IHerkulexServo> myServos = new List<IHerkulexServo>();
        private HerkulexInterface myHerkulexInterface12;
        private HerkulexInterface myHerkulexInterface34;
        private HerkulexInterface myHerkulexInterface56;
        private HerkulexInterface myHerkulexInterface78;

        private List<HerkulexInterface> myConnectors;
        //private string[] availablePorts => HerkulexInterfaceConnector.AvailableSerialPorts();

        private static WaveformType waveformType = WaveformType.Sine;
        private HerkulexComPortSelection selectedComPorts;

        public PeristalticHapticActuator()
        {
            InitializeComponent();
            StartupValues();
            CalculateWaveform();
            DisableDependantButtons();
        }

        private void StartupValues()
        {
            BatteryUpdate();
            radioButtonList = new List<RadioButton>()
            {
                triangleRadioButton, sinRadioButton, sineTriangleRadioButton, triangleRadioButton,
                negativeSawtoothRadioButton, positiveSawtoothRadioButton
            };
            frequencyBox.Text = fc.ToString(CultureInfo.CurrentCulture);
            amplitudeBox.Text = amplitude.ToString(CultureInfo.CurrentCulture);
            //  phaseBox.Text = phase.ToString(CultureInfo.CurrentCulture);
            periodBox.Text = period.ToString(CultureInfo.CurrentCulture);
            sinRadioButton.Checked = true;
            Open.BackColor = Color.LightGreen;
            Kill.BackColor = Color.Tomato;
            selectedComPorts = new HerkulexComPortSelection("", "", "", "", "");

            startServoTrackBar.Maximum = 8;
            startServoTrackBar.Minimum = 1;
            startServoTrackBar.TickFrequency = 1;
            startServoTrackBar.Value = startServo;

        }

        private void EnableMainButtons()
        {
            Open.Enabled = true;
            connectingPortsButton.Enabled = true;
        }

        private void DisableMainButtons()
        {
            Open.Enabled = false;
            connectingPortsButton.Enabled = false;
        }

        private void EnableDependantButtons()
        {
            Kill.Enabled = true;
            Send.Enabled = true;
            Max.Enabled = true;
            Min.Enabled = true;
            peristalticMotion_Checkbox.Enabled = true;
            peristalticMotion_Checkbox.Checked = !spatialOnlyPattern;
            startServoTrackBar.Enabled = true;
            DisableMainButtons();
        }

        private void DisableDependantButtons()
        {
            Kill.Enabled = false;
            Send.Enabled = false;
            Max.Enabled = false;
            peristalticMotion_Checkbox.Enabled = false;
            Min.Enabled = false;
            startServoTrackBar.Enabled = false;
            EnableMainButtons();
        }

        private void CalculateWaveform()
        {
            ChartFirstServo.Series.Clear();
            waveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            waveForm.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            waveForm.BorderWidth = 2;
            var xAxisWaveForm = new System.Windows.Forms.DataVisualization.Charting.Series();
            for (int i = 0; i <= period * 10; i++)
            {
                xAxisWaveForm.Points.AddXY(Convert.ToDouble(i), 0);
            }

            var generatedWaveForm = WaveformGenerator.Generate(waveformType, fc, period, amplitude, maxAmplitude);
            foreach (var el in generatedWaveForm) waveForm.Points.AddXY(el.XValue, el.YValue);
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
            var replayer = new HerkulexAsyncReplayer(minDegree, maxDegree);
            try
            {
                replayer.StartSeries(waveformType, fc, maxAmplitudeInDec, amplitudeInDec, period, myServos, !spatialOnlyPattern, startServo);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (InitializeServos() && InitializeBattery())
            //if (InitializeBattery()) 
           // if (true)
            {
                EnableDependantButtons();
            }
        }

        private bool InitializeBattery()
        {
            if (selectedComPorts == null)
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
                arduinoBattery = new Arduino(selectedComPorts.batteryPort, baudrate);
            }
            catch (Exception e)
            {
                arduinoBattery?.Close();
                MessageBox.Show(e.Message);
                return false;
            }
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            // Sets the timer interval to 10 seconds.
            myTimer.Interval = 60000;
            myTimer.Start();
            TimerEventProcessor(this, new EventArgs()); //let it run once 
            return true;
        }
        private bool InitializeServos()
        {
            if (selectedComPorts == null)
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
                if (selectedComPorts != null)
                {
                    if (myHerkulexInterface12 == null || myHerkulexInterface34 == null ||
                        myHerkulexInterface56 == null || myHerkulexInterface78 == null)
                    {
                        myHerkulexInterface12 = new HerkulexInterface(selectedComPorts.port12, baudrate);
                        myHerkulexInterface34 = new HerkulexInterface(selectedComPorts.port34, baudrate);
                        myHerkulexInterface56 = new HerkulexInterface(selectedComPorts.port56, baudrate);
                        myHerkulexInterface78 = new HerkulexInterface(selectedComPorts.port78, baudrate);
                        myConnectors = new List<HerkulexInterface>()
                        {
                            myHerkulexInterface12, myHerkulexInterface34, myHerkulexInterface56, myHerkulexInterface78
                        };

                    }
                    else
                    {
                        foreach (var port in myConnectors)
                        {
                            port.Reopen();
                        }
                    }
                }
                else
                {
                    var exception = new InvalidOperationException("You did not selected all COM-ports.");
                    throw exception;
                }
            }
            catch (Exception e)
            {
                KillAllConnectors();
                MessageBox.Show(e.Message);
                return false;
            }

            myServos = new List<IHerkulexServo>()
            {
                new HerkulexDrs0602(1, myHerkulexInterface12), new HerkulexDrs0602(2, myHerkulexInterface12),
                new HerkulexDrs0602(3, myHerkulexInterface34), new HerkulexDrs0602(4, myHerkulexInterface34),
                new HerkulexDrs0602(5, myHerkulexInterface56), new HerkulexDrs0602(6, myHerkulexInterface56),
                new HerkulexDrs0602(7, myHerkulexInterface78), new HerkulexDrs0602(8, myHerkulexInterface78)
            };
            try
            {
                foreach (var myServo in myServos)
                {
                   /* var status = myServo.Status();
                    if (status)
                    {
                        myServo.SetColor(HerkulexColor.GREEN);
                    }
                    else myServo.SetColor(HerkulexColor.RED);*/
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

            var threadList = new List<Thread>();
            foreach (var servo in myServos)
            {
                var myServoTask = new Thread(() => servo.MoveToNeutralPosition());
                threadList.Add(myServoTask);
                myServoTask.Start();
            }

            foreach (var thread in threadList) thread.Join();
            return true;
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            var replayer = new HerkulexAsyncReplayer(minDegree, maxDegree);
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
            var replayer = new HerkulexAsyncReplayer(minDegree, maxDegree);
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

            KillAllConnectors();
            DisableDependantButtons();
        }

        private void KillAllConnectors()
        {
            foreach (var port in myConnectors)
            {
                if (port != null)
                {
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                }
            }
            KillBattery();
        }

        private void KillBattery()
        {
            if (arduinoBattery != null)
            {
                if (arduinoBattery.IsOpen)
                {
                    arduinoBattery.Close();
                    myTimer.Stop();
                    batteryLevel = -1;
                    BatteryUpdate();
                }
            }
        }

        private void PeristalticHapticActuator_Load(object sender, EventArgs e)
        {

        }

        private void SinRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sinRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(sinRadioButton);
                waveformType = WaveformType.Sine;
                CalculateWaveform();
            }

        }

        private void TriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (triangleRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(triangleRadioButton);
                waveformType = WaveformType.Triangle;
                CalculateWaveform();
            }
        }

        private void UncheckAllRadioButtonsExcept(RadioButton button)
        {
            foreach (var el in radioButtonList)
            {
                if (el != button) el.Checked = false;
            }
        }

        private void sineTriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sineTriangleRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(sineTriangleRadioButton);
                waveformType = WaveformType.SineTriangle;
                CalculateWaveform();
            }
        }

        private void triangleSineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (triangleSineRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(triangleSineRadioButton);
                waveformType = WaveformType.TriangleSine;
                CalculateWaveform();
            }
        }

        private void positiveSawtoothRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (positiveSawtoothRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(positiveSawtoothRadioButton);
                waveformType = WaveformType.PositiveSawtooth;
                CalculateWaveform();
            }
        }

        private void negativeSawtoothRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (negativeSawtoothRadioButton.Checked)
            {
                UncheckAllRadioButtonsExcept(negativeSawtoothRadioButton);
                waveformType = WaveformType.NegativeSawtooth;
                CalculateWaveform();
            }
        }

        private void connectingPortsButton_Click(object sender, EventArgs e)
        {
            var settingsWindow = new ConnectingSettings(selectedComPorts);
            settingsWindow.ShowDialog();
            selectedComPorts = settingsWindow.SelectedPorts;
            selectedServoPortsList = new List<string>()
            {
                selectedComPorts.port12, selectedComPorts.port34,
                selectedComPorts.port56, selectedComPorts.port78
            };
            com1.Text = selectedComPorts.port12;
            com2.Text = selectedComPorts.port34;
            com3.Text = selectedComPorts.port56;
            com4.Text = selectedComPorts.port78;
        }

        private void BatteryUpdate()
        {
            var displayString = "Battery: " + batteryLevel + "%"; ;
            if (batteryLevel >= 40)
            {
                BatteryProgressLabel.BackColor = Color.Green;
            }

            if (batteryLevel < 40 && batteryLevel > 20)
            {
                BatteryProgressLabel.BackColor = Color.Yellow;
            }

            if (batteryLevel <= 20)
            {
                BatteryProgressLabel.BackColor = Color.Red;
            }

            if (batteryLevel < 0)
            {
                displayString = "Battery: -- ";
                BatteryProgressLabel.BackColor = Color.Gray;
            }

            BatteryProgressLabel.Text = displayString;


        }

        private void TimerEventProcessor(Object myObject,
            EventArgs myEventArgs)
        {
            var batteryPercent = 0.0;
            var batteryThread = new Thread(() =>
                batteryPercent = arduinoBattery.GetBatteryPercentage() * 100);
            batteryThread.Start();
            batteryThread.Join();
            batteryLevel = Math.Round(batteryPercent, 0);
            BatteryUpdate();

        }

        private void startServo_trackBarScroll(object sender, EventArgs e)
        {
            var startServoValue = startServoTrackBar.Value;
            // if (startServoValue > myServos.Count || startServoValue < 1)
            if (startServoValue > 8 || startServoValue < 1)
            {
                throw new InvalidOperationException("The start servo you have selected is out of range." +
                                                    "You can choose servos between 1 and 8, you have" +
                                                    $" selected {startServoValue}. If you have any question, " +
                                                    $"you should ask Stejara or me (Adrian), but do not ask Mengjia. She has no clue");
            }
            startServo = startServoValue;
        }

        private void peristalticMotion_Checkbox_Click(object sender, EventArgs e)
        {
            if (peristalticMotion_Checkbox.Checked)
            {
                spatialOnlyPattern = false;
                startServoTrackBar.Enabled = true;
            }
            else if (!peristalticMotion_Checkbox.Checked)
            {
                spatialOnlyPattern = true;
                startServoTrackBar.Enabled = false;
            }

        }
    }
}
