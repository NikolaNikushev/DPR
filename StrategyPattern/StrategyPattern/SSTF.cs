using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class SSTF : IScheduleType
    {
        public void ScheduleRequests(int header, int[] requests, out int seekTime, out List<int> scheduledRequest)
        {
            scheduledRequest = new List<int>();
            seekTime = 0;
            if (!requests.Contains(header))
            {

                //Assigning value of the header to the requests array
                int[] temp = new int[requests.Length + 1];
                for (int i = 0; i < requests.Length; i++)
                {
                    temp[i] = requests[i];
                }
                temp[requests.Length + 1] = header;
                requests = temp;
            }
            else
            {
                scheduledRequest.Add(header);
            }
            //Merge sort
            Utility.MergeSort(ref requests, 0, requests.Length / 2, requests.Length);
            //Step 1 Find closest to header

            List<int> resultsFromSched = requests.ToList();
            while (resultsFromSched.Count > 0)
            {
                int indexOfElement = -1;
                for (int i = 0; i < resultsFromSched.Count; i++)
                {
                    if (resultsFromSched[i] == header)
                    {
                        indexOfElement = i;
                    }
                }

                
                //Find Closest to header
                header = resultsFromSched[indexOfElement];
                int left = resultsFromSched[indexOfElement - 1];
                int right = resultsFromSched[indexOfElement + 1];
                if (Math.Abs(header - left) > Math.Abs(header - right))
                {
                    scheduledRequest.Add(right);
                    header = right;
                    resultsFromSched.RemoveAt(indexOfElement + 1);
                }
                else
                {
                    scheduledRequest.Add(left);
                    header = left;
                    resultsFromSched.RemoveAt(indexOfElement - 1);
                }
            }
            
           

        }
    }
}
