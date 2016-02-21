using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class OS
    {
        //Fileds
        int header;
        List<int> scheduledRequests; // the requests the head needs to go thru
        int[] requests;
        int seekTime;

        private IScheduleType scheduleType; // the type of the system, FCFS/SCAN/SSTF
        //properties

            /// <summary>
            /// Returns the seek time after executing the requests.
            /// </summary>
        public int LastSeekTime
        {
            get
            {
                return seekTime;
            }
        }

        object l = new object();//lock to make sure the thread does not get interuped or get a different instance of the data.

        public List<int> ScheduledRequests
        {
            get
            {
                lock (l)//using the lock.
                return scheduledRequests;
            }
        }


        /// <summary>
        /// Returns the current system type
        /// </summary>
        public IScheduleType ScheduleType
        {
            get { return scheduleType; }
        }

        //Constructor
        public OS(IScheduleType p_scheduleType, int p_header, int[] p_requests)
        {
            scheduleType = p_scheduleType;
            header = p_header;
            requests = p_requests;
        }


        /// <summary>
        /// Executes the requests and generates the list of requests to be passed by the thread.
        /// Also calculates the seek time of the process.
        /// </summary>
        public void ExecuteScheduleRequests()
        {

            scheduleType.ScheduleRequests(header, requests, ref seekTime, out scheduledRequests);
        }

        /// <summary>
        /// Adds changes the array of requests to a new request array
        /// </summary>
        /// <param name="requests">The new requests</param>
        public void AddRequest(int[] requests)
        {
            this.requests = requests;
        }

        /// <summary>
        /// Updates the header
        /// </summary>
        /// <param name="value">The new value of the header</param>
        public void UpdateHeader(int value)
        {
            this.header = value;
        }

     
        /// <summary>
        /// Calculates the distance between the head and the first request element that needs to be passed thru 
        /// </summary>
        /// <returns>Int value of the distance</returns>
        public int CalculateNextSeek()
        {
            //Since we always remove the first element of the list in the main programm we can use [0] as index, because the [0] is always the current request we need to get to.
            return Math.Abs(header - scheduledRequests[0]);
        }

    }
}
