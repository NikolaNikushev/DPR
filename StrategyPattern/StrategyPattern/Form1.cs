using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        RequestGenerator reqGen;
        int[] generatedRequest;
        int header;
        int totalCylinders;
        OS FCFS;
        OS SSTF;
        OS SCAN;

        Label[] labelsList = new Label[101];
        public Form1()
        {
            InitializeComponent();
            generatedRequest = new int[20];
            header = 50;
            totalCylinders = 99;
            reqGen = new RequestGenerator(generatedRequest.Length, 0, totalCylinders);

        }



        private void btnGnrtReq_Click(object sender, EventArgs e)
        {
            lbRequests.Items.Clear();
            generatedRequest = reqGen.GenerateRandom();
            foreach (int request in generatedRequest)
            {
                lbRequests.Items.Add(request.ToString());
                CreateLabel(request);
            }
            tbCurrentRequest.Text = lbRequests.Items[0].ToString();

        }

        private void CreateLabel(int value)
        {

            Label l = new Label();

            int y = 5 * value + 30;
            l.Location = new Point(250, y);
            l.Width = 100;
            l.Text = value.ToString();
            l.BringToFront();

            labelsList[value] = l;
            this.Controls.Add(l);
        }

        private void DeleteLabel(int value)
        {
            Label l = this.labelsList[value];
            if (l != null)
            {
                this.Controls.Remove(l);
                this.labelsList[value] = null;
            }
            lbRequests.Items.RemoveAt(0);
            tbCurrentRequest.Text = lbRequests.Items[0].ToString();

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            List<int> scheduledRequest = new List<int>();
            if (rbFCFS.Enabled == true)
            {
                FCFS = new OS(new FCFS(), header, generatedRequest);
                FCFS.scheduleRequest();

            }
            else if (rbSSTF.Enabled == true)
            {

            }
            else if (rbSCAN.Enabled == true)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBarRequest_Scroll(object sender, EventArgs e)
        {
            int currrentValue = int.Parse(tbCurrentRequest.Text);
            int selectedTrackValue = trackBarRequest.Value;
            if (selectedTrackValue == currrentValue)
            {
                DeleteLabel(selectedTrackValue);
            }
        }
    }
}
