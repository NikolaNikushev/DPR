using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class FCFS : IScheduleType
    {
        public void ScheduleRequests(int header, int[] requests, ref int seekTime,out List<int> scheduledRequest)
        {
            scheduledRequest = new List<int>();
            int lastRequest = 0;
         
            seekTime = 0;
            for (int i = 0; i < requests.Length; i++)
            {
                seekTime += Math.Abs(header - requests[i]);
                lastRequest = requests[i];

                scheduledRequest.Add(lastRequest);
                header = lastRequest;
            }
        }

       
    }
}
