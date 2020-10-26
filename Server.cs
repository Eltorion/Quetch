using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Server
    {
        private Random rand;
        public List<Request> Queue { get; set; } = new List<Request>(); 
        public List<Request> Processed { get; set; } = new List<Request>();

        public Server(Random rnd) 
        {
             rand = rnd;
        }

        public void AddRequest(Request value)
        {
            Queue.Add(value);
        }

        public void Process(double mu)
        {
            int prCount = Processed.Count;
            if (prCount == 0)
                Queue[0].ProcessStart(Queue[0].ArrivalTime);
            else 
                if (Processed[prCount - 1].ExitTime > Queue[0].ArrivalTime)
                Queue[0].ProcessStart(Processed[prCount - 1].ExitTime);
            else
                Queue[0].ProcessStart(Queue[0].ArrivalTime);
            Queue[0].Exit(ExpRandom.Generate(mu, rand));
            Processed.Add(Queue[0]);
            Queue.RemoveAt(0);
        }

        public void FullProcess(double mu)
        {
            while (Queue.Count > 0)
                Process(mu);
        }

        public void Normalize(double maxtime)
        {
            for (int i = Processed.Count - 1; i >= 0; i--)
                if (Processed[i].ExitTime > maxtime)
                    Processed.RemoveAt(i);
        }
    }
}
