using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SSTF : IScheduleType
    {
        /// <summary>
        /// Generate the requests by calculating the shortest distance from the head to it's neighbour.
        /// </summary>
        /// <param name="header">Start point of the disk </param>
        /// <param name="requests">The requests that the disk needs to retrieve.</param>
        /// <param name="seekTime">Ref param. The time it took for the process to finish.</param>
        /// <param name="scheduledRequest">Out param. The list of requests that the needle will pass thru.</param>
        public void ScheduleRequests(int header, int[] requests, ref int seekTime, out List<int> scheduledRequest)
        {
            seekTime = 0;
            scheduledRequest = new List<int>();

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
            //Merge sort
            Utility.MergeSort_Recursive(ref requests, 0, requests.Length - 1);


            List<int> resultsFromSched = requests.ToList();
            //Loop to go thru all the requests.
            while (resultsFromSched.Count > 0)
            {
                int indexOfElement = -1;
                for (int i = 0; i < resultsFromSched.Count; i++)
                {
                    if (resultsFromSched[i] == header)
                    {
                        indexOfElement = i;
                        break;
                    }
                }


                
                int left = -1;
                int right = -1;
                //if there are no elements left remove the last element left( it has already been added)
                if (resultsFromSched.Count <= 1)
                {
                    if (scheduledRequest.Count > requests.Length) scheduledRequest.RemoveAt(0);
                    break;
                }

                //check if no elements are on the right side, then takes the first element on the left.
                if (indexOfElement + 1 >= resultsFromSched.Count)
                {


                    left = resultsFromSched[indexOfElement - 1];
                    scheduledRequest.Add(left);
                    resultsFromSched.RemoveAt(indexOfElement);
                    seekTime += Math.Abs(header - left);
                    header = left;

                }
                //checks if no elements are on the left side, then takes the first element on the right
                else if (indexOfElement - 1 < 0)
                {
                    right = resultsFromSched[indexOfElement + 1];
                    scheduledRequest.Add(right);
                    resultsFromSched.RemoveAt(indexOfElement);
                    seekTime += Math.Abs(header - right);
                    header = right;
                }
                else
                {
                    //if both sides have elements, gets the both elements
                    left = resultsFromSched[indexOfElement - 1];
                    right = resultsFromSched[indexOfElement + 1];
                    //calculates the difference between the two sides, to see which is closer.

                    if (Math.Abs(header - left) > Math.Abs(header - right))
                    {

                        UpdateHeaderAndAddRequest(ref header, right, ref scheduledRequest, ref seekTime);
                    }
                    else
                    {

                        UpdateHeaderAndAddRequest(ref header, left, ref scheduledRequest, ref seekTime);

                    }
                    //removes the element that the head was on last.
                    resultsFromSched.RemoveAt(indexOfElement);

                }
            }



        }


        private void UpdateHeaderAndAddRequest(ref int header, int value, ref List<int> requestsList, ref int seekTime)
        {
            //adds the next element from the head.
            requestsList.Add(value);

            seekTime += Math.Abs(header - value);

            //moves the head to the next element.
            header = value;
        }
    }
}
