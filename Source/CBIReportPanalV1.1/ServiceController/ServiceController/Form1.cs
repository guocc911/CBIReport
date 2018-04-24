using System;
using System.Windows.Forms;

namespace ServiceController
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The WindowsServiceMonitor class
        /// </summary>
        private WindowsServiceMonitor _windowsServiceMonitor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _windowsServiceMonitor = new WindowsServiceMonitor(ServiceTextBox.Text);
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (_windowsServiceMonitor.IsRunning)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is started");
            else if (_windowsServiceMonitor.IsStopped)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is stopped");
            else if (_windowsServiceMonitor.IsDisabled)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is disabled");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_windowsServiceMonitor.IsRunning)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is already running");
            else if (_windowsServiceMonitor.IsDisabled)
                MessageBox.Show("Can't start the '" + ServiceTextBox.Text + "' because it is disabled");
            else
            {
                try
                {
                    _windowsServiceMonitor.Start();
                    StatusButton_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (_windowsServiceMonitor.IsStopped)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is already stopped");
            else if (_windowsServiceMonitor.IsDisabled)
                MessageBox.Show("Can't stop the '" + ServiceTextBox.Text + "' because it is disabled");
            else
            {
                try
                {
                    _windowsServiceMonitor.Stop();
                    StatusButton_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisableButton_Click(object sender, EventArgs e)
        {
            if (_windowsServiceMonitor.IsDisabled)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is already disabled");
            else
            {
                try
                {
                    _windowsServiceMonitor.Disable();
                    StatusButton_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EnableButton_Click(object sender, EventArgs e)
        {
            if (!_windowsServiceMonitor.IsDisabled)
                MessageBox.Show("The '" + ServiceTextBox.Text + "' is already enabled");
            else
            {
                try
                {
                    _windowsServiceMonitor.Enable();
                    StatusButton_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
