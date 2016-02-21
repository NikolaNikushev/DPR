using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SSTF : IScheduleType
    {

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


                //Find Closest to header
                int left = -1;
                int right = -1;
                if (resultsFromSched.Count <= 1)
                {
                    if (scheduledRequest.Count > requests.Length) scheduledRequest.RemoveAt(0);
                    break;
                }

                if (indexOfElement + 1 >= resultsFromSched.Count)
                {


                    left = resultsFromSched[indexOfElement - 1];
                    scheduledRequest.Add(left);
                    resultsFromSched.RemoveAt(indexOfElement);
                    seekTime += Math.Abs(header - left);
                    header = left;

                }
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
                    left = resultsFromSched[indexOfElement - 1];
                    right = resultsFromSched[indexOfElement + 1];
                    if (Math.Abs(header - left) > Math.Abs(header - right))
                    {

                        UpdateHeaderAndAddRequest(ref header, right, ref scheduledRequest, ref seekTime);
                    }
                    else
                    {

                        UpdateHeaderAndAddRequest(ref header, left, ref scheduledRequest, ref seekTime);

                    }
                    resultsFromSched.RemoveAt(indexOfElement);

                }
            }



        }


        private void UpdateHeaderAndAddRequest(ref int header, int value, ref List<int> requestsList, ref int seekTime)
        {
            requestsList.Add(value);
            seekTime += Math.Abs(header - value);

            header = value;
        }
    }
}
