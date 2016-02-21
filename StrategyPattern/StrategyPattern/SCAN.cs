using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SCAN : IScheduleType
    {
        static int lastDirection = 0; //0 is down, 1 is up
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
            //resultsFromSched.Insert(0, 0);
            //resultsFromSched.Add(99);
            int indexOfHeader = resultsFromSched.IndexOf(header); //the index of the header in the List<int>


            List<int> leftSide = resultsFromSched.GetRange(0, indexOfHeader);
            leftSide.Reverse();

            if (lastDirection == 0)
            {
                scheduledRequest.AddRange(leftSide);
                scheduledRequest.AddRange(resultsFromSched.GetRange(indexOfHeader + 1, resultsFromSched.Count - leftSide.Count - 1));
            }
            if (lastDirection == 1)
            {
                scheduledRequest.AddRange(resultsFromSched.GetRange(indexOfHeader + 1, resultsFromSched.Count - leftSide.Count - 1));
                scheduledRequest.AddRange(leftSide);
            }
            for (int i = 0; i < scheduledRequest.Count; i++)
            {
                seekTime += Math.Abs(header - scheduledRequest[i]);
                header = scheduledRequest[i];
            }
            /*int direction = 0;
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
            */


        }
    }

}
