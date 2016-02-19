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
        OS FCFS;
        OS SSTF;
        OS SCAN;
        public Form1()
        {
            InitializeComponent();
            generatedRequest = new int[20];
            header = 50;
            reqGen = new RequestGenerator(generatedRequest.Length,0,99);
            
        }



        private void btnGnrtReq_Click(object sender, EventArgs e)
        {
            lbRequests.Items.Clear();
            generatedRequest = reqGen.GenerateRandom();
            foreach (int request in generatedRequest)
            {
                lbRequests.Items.Add(request.ToString());

            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            
            List<int> scheduledRequest = new List<int>();
            if (rbFCFS.Enabled == true)
            {
                FCFS = new OS(new FCFS(),header,generatedRequest);
                FCFS.scheduleRequest();
                
            }
            else if (rbSSTF.Enabled == true)
            {

            }
            else if (rbSCAN.Enabled == true)
            {

            }
        }
    }
}
