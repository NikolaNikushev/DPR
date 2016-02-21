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

        Label[] labelsList = new Label[101];// Values from 0-100
        Thread sliderThread;//used to update the slider
        public Form1()
        {
            InitializeComponent();
            generatedRequest = new List<int>();
            header = 50;
            totalCylinders = 99;
            reqGen = new RequestGenerator(20, 0, totalCylinders);

        }


        //Used for testing perposes.
        private void btnGnrtReq_Click(object sender, EventArgs e)
        {
            FillRandomRequests();

        }

        /// <summary>
        /// Assigns the value of the new generated random numbers to the request list and adds their values to the listbox.
        /// </summary>
        private void FillRandomRequests()
        {
            lbRequests.Items.Clear();
            generatedRequest = reqGen.GenerateRandom().ToList();
            foreach (int request in generatedRequest)
            {
                lbRequests.Items.Add(request.ToString());

            }

        }


        /// <summary>
        /// Creates a label on the form next to slider with a value.
        /// </summary>
        /// <param name="value">The value of the label</param>
        private void CreateLabel(int value)
        {

            Label l = new Label();

            int y = 500 - (5 * value) + 25;
            l.Location = new Point(250, y);
            l.Width = 100;
            l.Text = value.ToString();
            l.BringToFront();

            labelsList[value] = l;
            this.Controls.Add(l);
        }


        /// <summary>
        /// Deletes a specific label on the form with a certain value.
        /// Used when slider value is the same as the current request value
        /// </summary>
        /// <param name="value">The value of the label to be deleted</param>
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

        /// <summary>
        /// Clears all the labels that display the current requests.
        /// </summary>
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


        //Executes the current selected system once.
        private void btnRun_Click(object sender, EventArgs e)
        {
            runOnce = true; // specifies that the system should run only one time.

            InitializeSystem();
            InitializeFormRequestElements();

            if (sliderThread != null) sliderThread.Abort(); // makes sure there is only one thread created by the application.
            sliderThread = new Thread(new ThreadStart(this.ThreadWorker)); // runs a thread safe thread, allowing to invoke changes from another thread to the form.

            sliderThread.Start();
        }

        /// <summary>
        /// The method the thread uses to execute it's operation.
        /// </summary>
        private void ThreadWorker()
        {
            //loop for all requests untill none left.
            while (currentOs.ScheduledRequests.Count > 0)
            {
                //execute the disk reading and move the slider with a delay of 30 seconds
                Thread.Sleep(30);
                TrackbarChange();
            }

        }

        /// <summary>
        /// Removes a specific label and updates the current seek time and the current thread. 
        /// Used for the trackbar change.
        /// </summary>
        /// <param name="selectedTrackValue">The label that will be deleted</param>
        private void RemoveLabelAndUpdateCurrentRequest(int selectedTrackValue)
        {
            //Updates the current seek time
            seekTimeTracker += currentOs.CalculateNextSeek();
            this.Invoke(new Action(() => labCurrentSeek.Text = "Current seek time: " + seekTimeTracker.ToString()));

            //Updates the current thread
            currentOs.UpdateHeader(header);
            List<int> requests = currentOs.ScheduledRequests;

            //if the system is SCAN we also need to indicate the direction if necesery to change.
            if (currentOs.ScheduleType is SCAN)
            {
                SCAN curOS = currentOs.ScheduleType as SCAN;
                if (header == requests.Max() && curOS.CurrentDirection == 1 || header == requests.Min() && curOS.CurrentDirection == 0)
                    curOS.ChangeDirection();
            }
            //Invoke thread save delete label.
            this.Invoke(new Action(() => DeleteLabel(selectedTrackValue)));

            currentOs.ScheduledRequests.RemoveAt(0);



        }



        /// <summary>
        /// Thread code that is looped
        /// </summary>
        private void TrackbarChange()
        {
            //Current requests that we need.
            int currrentValue = int.Parse(tbCurrentRequest.Text);
            //Current trackbar , head value
            this.Invoke(new Action(() => header = trackBarRequest.Value));


            //gets the first request of the requests
            int elementZero = currentOs.ScheduledRequests.ElementAt(0);

            //if the request is bigger than the slider, the slider is increased untill it reaches the request value
            if (header < elementZero)
                this.Invoke(new Action(() => trackBarRequest.Value++));
            //if the head is the same as the current request removes the label and updates the seek time.
            else if (header == elementZero)
            {
                RemoveLabelAndUpdateCurrentRequest(header);
                this.Invoke(new Action(() => labSeekTime.Text = "Time needed for requests: " + currentOs.LastSeekTime.ToString()));
                //if the process is to run without stopping, make a call to generate a new request and update the current requests
                if (!runOnce)
                    GenerateNewRequest();
                //if not requests are left, empty the current request.
                if (currentOs.ScheduledRequests.Count == 0)
                {
                    this.Invoke(new Action(() => tbCurrentRequest.Text = ""));


                }
                //displays the next element from the list.
                else
                {
                    this.Invoke(new Action(() => tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString()));

                }
            }
            //losers the value of the trackbar untill it reaches the current request
            else
            {


                this.Invoke(new Action(() => trackBarRequest.Value--));
            }

        }

        /// <summary>
        /// Generates an ew request.
        /// </summary>
        private void GenerateNewRequest()
        {
            //Gets the current requests
            List<int> requests = currentOs.ScheduledRequests;

            //Gets a new unique value to add to the list of requests
            int request = reqGen.GenerateRandomRequest(requests);
            //adds the new value
            requests.Add(request);

            //Initializes the new request on the form.
            this.Invoke(new Action(() => CreateLabel(request)));

            //Updates the request to the OS and the header.
            currentOs.AddRequest(requests.ToArray());
            currentOs.UpdateHeader(header);
            //Executes the disk reading process again, with the new requests.
            currentOs.ExecuteScheduleRequests();
            //Thread safe updates the items of the list box.
            this.Invoke(new Action(() => lbRequests.Items.Add(request.ToString())));



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void trackBarRequest_Scroll(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Initializes the system. Setting all defaults, clearing anything left from before.
        /// </summary>
        private void InitializeSystem()
        {
            seekTimeTracker = 0;
            ClearLabels();
            this.lbRequests.Items.Clear();
            generatedRequest.Clear();
            //if it is the first time running, or the previous run has finished
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

        /// <summary>
        /// Displays the labels next to the slider. and shows the starting point of the seek times.
        /// </summary>
        private void InitializeFormRequestElements()
        {

            tbCurrentRequest.Text = currentOs.ScheduledRequests.ElementAt(0).ToString();
            foreach (int item in currentOs.ScheduledRequests)
            {
                CreateLabel(item);
            }
            labCurrentSeek.Text = "Current seek time : " + seekTimeTracker;
            this.Invoke(new Action(() => labSeekTime.Text = "Time needed for requests: " + currentOs.LastSeekTime.ToString()));
        }

        private void btnRunForEver_Click(object sender, EventArgs e)
        {
            //same as run, but with run once being false.
            runOnce = false;
            InitializeSystem();
            InitializeFormRequestElements();


            if (sliderThread != null) sliderThread.Abort();
            sliderThread = new Thread(new ThreadStart(this.ThreadWorker));

            sliderThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //stops the thread at the point it was last.
            sliderThread.Abort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //makes sure the thread that was started is stopped after closing the application ( we control our threads )
            if (sliderThread != null)
                sliderThread.Abort();
        }

        private void labSeekTime_Click(object sender, EventArgs e)
        {

        }
    }
}
