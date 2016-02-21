using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SCAN : IScheduleType
    {
        int lastDirection = 0; //0 is down, 1 is up

        /// <summary>
        /// Generate the requests like an elevator, picking up all toward one direction, and then going to the other direction.
        /// </summary>
        /// <param name="header">Start point of the disk </param>
        /// <param name="requests">The requests that the disk needs to retrieve.</param>
        /// <param name="seekTime">Ref paramater. The time it took for the process to finish.</param>
        /// <param name="scheduledRequest">Out param. The list of requests that the needle will pass thru.</param>
        public void ScheduleRequests(int header, int[] requests, ref int seekTime, out List<int> scheduledRequest)
        {
            scheduledRequest = new List<int>();
            seekTime = 0;

            // Checking if the header exists in the array 
            // if it doesn't -> add it to the array
            // if it does -> add it to the processed(scheduled) List<int>
            if (!requests.Contains(header))
            {
                //Assigning value of the header to the requests array
                int[] temp = new int[requests.Length + 1];
                for (int i = 0; i < requests.Length; i++)
                {
                    temp[i] = requests[i];
                }
                temp[requests.Length] = header;
                requests = temp;
            }
            else
            {
                scheduledRequest.Add(header);
            }
            //Sort the array
            Utility.MergeSort_Recursive(ref requests, 0, requests.Length - 1);

            List<int> resultsFromSched = requests.ToList(); //using List<int> instead of array
        
            int indexOfHeader = resultsFromSched.IndexOf(header); //the index of the header in the List<int>


            //Gets all the elements that are on the left side of the head.
            List<int> leftSide = resultsFromSched.GetRange(0, indexOfHeader);
            leftSide.Reverse();
          

            //if going down, first put all the left side requests.
            if (lastDirection == 0 )
            {
                scheduledRequest.AddRange(leftSide);
                scheduledRequest.AddRange(resultsFromSched.GetRange(indexOfHeader + 1, resultsFromSched.Count - leftSide.Count - 1));
            }
            //if going up, first put all the right side requests.
            if (lastDirection == 1)
            {
                scheduledRequest.AddRange(resultsFromSched.GetRange(indexOfHeader + 1, resultsFromSched.Count - leftSide.Count - 1));
                scheduledRequest.AddRange(leftSide);
            }
            //calculate seek time 
            for (int i = 0; i < scheduledRequest.Count; i++)
            {
                seekTime += Math.Abs(header - scheduledRequest[i]);
                header = scheduledRequest[i];
            }
        }

        /// <summary>
        /// Changes the direction of the elevator.         
        /// </summary>
        public void ChangeDirection()
        {
            int direct = this.lastDirection == 0 ?  1 :  0;
            this.lastDirection = direct;
        }

        /// <summary>
        /// Returns the current direction of the elevator.
        /// 0 is down, 1 is up.
        /// </summary>
        public int CurrentDirection
        {
            get { return lastDirection; }
        }
    }

}
