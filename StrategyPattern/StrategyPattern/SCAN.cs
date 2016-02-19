using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class SCAN : IScheduleType
    {
        public void ScheduleRequests(int header, int[] requests, out int seekTime, out List<int> scheduledRequest)
        {
            throw new NotImplementedException();
        }
    }
}
