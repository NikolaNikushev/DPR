using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        RequestGenerator reqGen;
        List<int> generatedRequest;
        int header;
        int totalCylinders;
        OS currentOs;
        OS FCFS;
        OS SSTF;
        OS SCAN;

        Label[] labelsList = new Label[101];
        public Form1()
        {
            InitializeComponent();
            generatedRequest = new List<int>();
            header = 50;
            totalCylinders = 99;
            reqGen = new RequestGenerator(20, 0, totalCylinders);

        }



        private void btnGnrtReq_Click(object sender, EventArgs e)
        {
            FillRandomRequests();

        }

        private void FillRandomRequests()
        {
            lbRequests.Items.Clear();
            generatedRequest = reqGen.GenerateRandom().ToList();
            foreach (int request in generatedRequest)
            {
                lbRequests.Items.Add(request.ToString());

            }

        }

        private void AddRandomRequest()
        {
            reqGen.GenerateRandomRequest(ref generatedRequest);

        }

        private void CreateLabel(int value)
        {

            Label l = new Label();

            int y = 500 - (5 * value) + 30;
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

                l.Dispose();
                this.labelsList[value] = null;
            }
            
            lbRequests.Items.RemoveAt(0);
           

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            FillRandomRequests();

           
            if (rbFCFS.Enabled == true)
            {
                currentOs = new OS(new FCFS(), header, generatedRequest.ToArray());
                currentOs.scheduleRequest();
                tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString();
                foreach (int item in currentOs.ScheduledRequests)
                {
                    CreateLabel(item);
                }
                Thread t = new Thread(new ThreadStart(this.TrackBarChangeValue));

                t.Start();

            }
            else if (rbSSTF.Enabled == true)
            {

            }
            else if (rbSCAN.Enabled == true)
            {

            }
        }

        private void TrackBarChangeValue()
        {
            while (currentOs.ScheduledRequests.Count > 0)
            {
                Thread.Sleep(1);
                int currrentValue = int.Parse(tbCurrentRequest.Text);
                int selectedTrackValue = trackBarRequest.Value;

                int elementZero = currentOs.ScheduledRequests.ElementAt(0);

                if (selectedTrackValue < elementZero)
                    trackBarRequest.Value++;
                else if (selectedTrackValue == elementZero)
                {
                    DeleteLabel(selectedTrackValue);
                    currentOs.ScheduledRequests.RemoveAt(0);
                    if (currentOs.ScheduledRequests.Count == 0)
                    {
                        tbCurrentRequest.Text = "";
                        break;

                    }
                    else
                    {
                        tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString();

                    }
                }
                else
                {

                    trackBarRequest.Value--;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBarRequest_Scroll(object sender, EventArgs e)
        {


        }

        private void btnRunForEver_Click(object sender, EventArgs e)
        {

        }
    }
}
