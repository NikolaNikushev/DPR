using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class FCFS : IScheduleType
    {
        /// <summary>
        /// Generate the requests based on the start of the header and follows the requests as they are given.
        /// </summary>
        /// <param name="header">Start point of the disk </param>
        /// <param name="requests">The requests that the disk needs to retrieve.</param>
        /// <param name="seekTime">Ref param. The time it took for the process to finish.</param>
        /// <param name="scheduledRequest">Out param. The list of requests that the needle will pass thru.</param>
        public void ScheduleRequests(int header, int[] requests, ref int seekTime,out List<int> scheduledRequest)
        {
            scheduledRequest = new List<int>();
            int lastRequest = 0;
         
            seekTime = 0;
            //Stars going thru all the requests and gets them in the order they have been first given.
            for (int i = 0; i < requests.Length; i++)
            {
                //Calculates the distance between the requests
                seekTime += Math.Abs(header - requests[i]);
                lastRequest = requests[i];

                scheduledRequest.Add(lastRequest);
                //Moves the head of the disk.
                header = lastRequest;
            }
        }

       
    }
}
