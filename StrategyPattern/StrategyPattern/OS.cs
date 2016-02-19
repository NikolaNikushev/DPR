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
        List<int> scheduledRequests;
        int[] requests;
        int seekTime;

        private IScheduleType scheduleType;
        //properties

        public int LastSeekTime
        {
            get
            {
                return seekTime;
            }
        }

        public List<int> ScheduledRequests
        {
            get
            {
                return scheduledRequests;
            }
        }

        //Constructor
        public OS(IScheduleType p_scheduleType, int p_header, int[] p_requests)
        {
            scheduleType = p_scheduleType;
            header = p_header;
            requests = p_requests;
        }

        public void scheduleRequest()
        {
            seekTime = 0;
            scheduleType.ScheduleRequests(header, requests, out seekTime, out scheduledRequests);
        }
    }
}
