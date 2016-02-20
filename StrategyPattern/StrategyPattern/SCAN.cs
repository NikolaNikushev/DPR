using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SCAN : IScheduleType
    {
        public void ScheduleRequests(int header, int[] requests, out int seekTime, out List<int> scheduledRequest)
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
            resultsFromSched.Insert(0, 0);
            resultsFromSched.Add(99);
            int indexOfHeader = resultsFromSched.IndexOf(header); //the index of the header in the List<int>

            int direction = 0;
            while (resultsFromSched.Count > 2)
            {
                if (indexOfHeader == 0)
                {
                    direction = 1;
                }
                else if (indexOfHeader == resultsFromSched.Count - 1)
                {
                    direction = 0;
                }

                while (direction == 0)
                {
                    if (indexOfHeader != 1)
                    {
                        scheduledRequest.Add(resultsFromSched[indexOfHeader - 1]);
                        resultsFromSched.RemoveAt(indexOfHeader);
                        indexOfHeader = indexOfHeader - 1;
                    }
                    else
                    {
                        resultsFromSched.RemoveAt(indexOfHeader);
                        indexOfHeader = 0;
                        break;
                    }

                }
                while (direction == 1)
                {
                    if (indexOfHeader != resultsFromSched.Count - 2)
                    {
                        
                        if(indexOfHeader == 0)
                        {
                            scheduledRequest.Add(resultsFromSched[indexOfHeader + 1]);
                            indexOfHeader = indexOfHeader + 1;
                        }
                        else if(indexOfHeader != 0)
                        {
                            scheduledRequest.Add(resultsFromSched[indexOfHeader + 1]);
                            resultsFromSched.RemoveAt(indexOfHeader);
                            indexOfHeader = indexOfHeader + 1;
                        }
                    }
                    else
                    {
                        resultsFromSched.RemoveAt(indexOfHeader);
                        indexOfHeader = resultsFromSched.Count - 1;
                        break;
                    }
                }
            }

      
        }
    }

}
