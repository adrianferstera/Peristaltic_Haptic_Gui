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

namespace Peristaltic_Hapric_Gui
{
    public partial class ConnectingSettings : Form
    {
        public HerkulexComPortSelection SelectedPorts;
        private HerkulexComPortSelection selectedPorts;
        private string[] availablePorts => HerkulexInterfaceConnector.AvailableSerialPorts();
        private HerkulexInterfaceConnector myConnector;
        public ConnectingSettings(HerkulexComPortSelection selectedPorts)
        {
            InitializeComponent();
            SelectedPorts = selectedPorts;
            comboServo12.Text= selectedPorts.port12;
            comboServo34.Text = selectedPorts.port34;
            comboServo56.Text = selectedPorts.port56;
            comboServo78.Text = selectedPorts.port78;
            comboBattery.Text = selectedPorts.batteryPort; 
        }

        private void comboServo12_DropDown(object sender, EventArgs e)
        {
            comboServo12.Items.Clear();
            var ports = availablePorts;
            foreach (var port in ports)
            {
                comboServo12.Items.Add(port);
            }
        }

        private void comboServo34_DropDown(object sender, EventArgs e)
        {
            comboServo34.Items.Clear();
            var ports = availablePorts;
            foreach (var port in ports)
            {
                comboServo34.Items.Add(port);
            }
        }

        private void comboServo56_DropDown(object sender, EventArgs e)
        {
            comboServo56.Items.Clear();
            var ports = availablePorts;
            foreach (var port in ports)
            {
                comboServo56.Items.Add(port);
            }
        }

        private void comboServo78_DropDown(object sender, EventArgs e)
        {
            comboServo78.Items.Clear();
            var ports = availablePorts;
            foreach (var port in ports)
            {
                comboServo78.Items.Add(port);
            }
        }

        private void comboBattery_DropDown(object sender, EventArgs e)
        {

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedPortList = new List<string>()
                {
                    comboServo12.Text, comboServo34.Text,
                    comboServo56.Text, comboServo78.Text, comboBattery.Text
                };

                for (int i = 0; i < selectedPortList.Count; i++)
                {
                    var selectedPortsMinusOne = selectedPortList.ToList();
                    selectedPortsMinusOne.RemoveAt(i);
                    if (selectedPortsMinusOne.Contains(selectedPortList[i]))
                    {
                        var exception = new InvalidOperationException("You have selected one port multiple times or have not selected all ports.");
                        throw exception;
                    }
                }
                selectedPorts = new HerkulexComPortSelection(comboServo12.Text, comboServo34.Text,
                    comboServo56.Text, comboServo78.Text, comboBattery.Text);
                SelectedPorts = selectedPorts;
                this.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
