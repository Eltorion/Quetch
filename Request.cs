using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Request
    {      
        public double ArrivalTime { get; set; }
        public double ProcessStartTime { get; set; }
        public double ExitTime { get; set; }

        public Request(double at)
        {
            ArrivalTime = at;
            ProcessStartTime = 0;
            ExitTime = 0;
        }

        public void ProcessStart(double pst)
        {
            ProcessStartTime = pst;
        }

        public void Exit(double pt)
        {
            ExitTime = pt + ProcessStartTime;
        }
    }
}
