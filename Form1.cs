using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quetch_simulation
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(kITextBox.Text);
            double tmax = Convert.ToDouble(tmaxITextBox.Text);
            double lambda = Convert.ToDouble(lambdaITextBox.Text);
            double mu = Convert.ToDouble(muITextBox.Text);
            Quetch quetch = new Quetch(k);
            if (randomRButton.Checked)
                quetch.RandomAdd(tmax, lambda, mu);
            if (roundrobinRButton.Checked)
                quetch.RoundRobinAdd(tmax, lambda, mu);
            if (jsqRButton.Checked)
                quetch.JSQAdd(tmax, lambda, mu);
            countOfRequestsOTextBox.Text = Convert.ToString(quetch.GetCountOfProcessed());
            averageRequestsInQuetchOTextBox.Text = Convert.ToString(quetch.ReqCount);
            averageTimeInQuetchOTextBox.Text = quetch.AverageTimeRequestInQuetch().ToString("0.#####");
            averageTimeInQueueOTextBox.Text = quetch.AverageTimeRequestInQueue().ToString("0.#####");
            averageTimeOfProcessingOTextBox.Text = quetch.AverageTimeOfProcessing().ToString("0.#####");
            averageTimeOfIdleServerOTextBox.Text = quetch.AverageTimeOfServerIdle().ToString("0.#####");
            averageCountOfRequestsInQuetchOTextBox.Text = quetch.AverageCountOfRequestsInQuetch(tmax).ToString("0.#####");
            averageCountOfRequestsInQueueOTextBox.Text = quetch.AverageCountOfRequestsInQueue(tmax).ToString("0.#####");
        }
    }
}
