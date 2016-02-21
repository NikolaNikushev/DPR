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
        private bool runOnce = true;
        private int seekTimeTracker;
        OS currentOs; //Used to specify the current operational system that is being used 
                      // OS FCFS;
                      // OS SSTF;
                      // OS SCAN;

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
            if (lbRequests.Items.Count > 0)
                if (lbRequests.Items.IndexOf(value.ToString()) != -1)
                    lbRequests.Items.RemoveAt(lbRequests.Items.IndexOf(value.ToString()));


        }

        private void ClearLabels()
        {
            foreach (Label l in this.labelsList)
            {
                if (l != null)
                {

                    l.Dispose();

                }
            }
        }

        Thread t;
        private void btnRun_Click(object sender, EventArgs e)
        {
            runOnce = true;

            InitializeSystem();
            InitializeFormRequestElements();

            if (t != null) t.Abort();
            t = new Thread(new ThreadStart(this.ThreadWorker));

            t.Start();
        }

        private void ThreadWorker()
        {


            while (currentOs.ScheduledRequests.Count > 0)
            {

                Thread.Sleep(30);
                TrackbarChange();


            }

        }

        private void RemoveLabelAndUpdateCurrentRequest(int selectedTrackValue)
        {
            seekTimeTracker += currentOs.CalculateNextSeek();
            this.Invoke(new Action(() => labCurrentSeek.Text = "Current seek time: " + seekTimeTracker.ToString()));
            currentOs.UpdateHeader(header);
            List<int> requests = currentOs.ScheduledRequests;
            if (currentOs.ScheduleType is SCAN)
            {
                SCAN curOS = currentOs.ScheduleType as SCAN;
                if (header == requests.Max() && curOS.CurrentDirection == 1 || header == requests.Min() && curOS.CurrentDirection == 0)
                    curOS.ChangeDirection();
            }
            this.Invoke(new Action(() => DeleteLabel(selectedTrackValue)));

            currentOs.ScheduledRequests.RemoveAt(0);



        }



        private void TrackbarChange()
        {

            int currrentValue = int.Parse(tbCurrentRequest.Text);

            this.Invoke(new Action(() => header = trackBarRequest.Value));

            int elementZero = currentOs.ScheduledRequests.ElementAt(0);

            if (header < elementZero)
                this.Invoke(new Action(() => trackBarRequest.Value++));
            else if (header == elementZero)
            {
                RemoveLabelAndUpdateCurrentRequest(header);
                this.Invoke(new Action(() => labSeekTime.Text = "Total seek time: " + currentOs.LastSeekTime.ToString()));
                if (!runOnce)
                    GenerateNewRequest();
                if (currentOs.ScheduledRequests.Count == 0)
                {
                    this.Invoke(new Action(() => tbCurrentRequest.Text = ""));


                }
                else
                {
                    this.Invoke(new Action(() => tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString()));

                }
            }
            else
            {

                this.Invoke(new Action(() => trackBarRequest.Value--));
            }

        }

        private void GenerateNewRequest()
        {
           
            List<int> requests = currentOs.ScheduledRequests;

            int request = reqGen.GenerateRandomRequest(requests);
            requests.Add(request);
            this.Invoke(new Action(() => CreateLabel(request)));
            currentOs.AddRequest(requests.ToArray());
            currentOs.UpdateHeader(header);
            //need to update seektime 
            currentOs.ExecuteScheduleRequests();

            this.Invoke(new Action(() => lbRequests.Items.Add(request.ToString())));



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void trackBarRequest_Scroll(object sender, EventArgs e)
        {


        }

        private void InitializeSystem()
        {
            seekTimeTracker = 0;
            ClearLabels();
            this.lbRequests.Items.Clear();
            generatedRequest.Clear();
            if (generatedRequest.Count == 0)
                FillRandomRequests();
            header = trackBarRequest.Value;
            //runs the FCFS
            if (rbFCFS.Checked == true)
            {
                currentOs = new OS(new FCFS(), header, generatedRequest.ToArray());


            }
            //runs the SSTF
            else if (rbSSTF.Checked == true)
            {
                currentOs = new OS(new SSTF(), header, generatedRequest.ToArray());
            }
            //Runs the RBSCAN
            else if (rbSCAN.Checked == true)
            {
                //throws an array exception index ouf range
                //todo fix

                currentOs = new OS(new SCAN(), header, generatedRequest.ToArray());
            }
            currentOs.ExecuteScheduleRequests();
        }

        private void InitializeFormRequestElements()
        {

            tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString();
            foreach (int item in currentOs.ScheduledRequests)
            {
                CreateLabel(item);
            }
            labCurrentSeek.Text = "Current seek time : " + seekTimeTracker;
            this.Invoke(new Action(() => labSeekTime.Text = "Total seek time: " + currentOs.LastSeekTime.ToString()));
        }

        private void btnRunForEver_Click(object sender, EventArgs e)
        {

            runOnce = false;
            InitializeSystem();
            InitializeFormRequestElements();


            if (t != null) t.Abort();
            t = new Thread(new ThreadStart(this.ThreadWorker));

            t.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Abort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (t != null)
                t.Abort();
        }

        private void labSeekTime_Click(object sender, EventArgs e)
        {

        }
    }
}
