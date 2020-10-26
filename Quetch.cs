using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Quetch
    {
        private Random rand = new Random();
        public int ReqCount { get; set; }
        private double inputTime;
        public List<Server> Servers { get; set; }  = new List<Server>();
     
        public Quetch(int count)
        {
            inputTime = 0;
            ReqCount = 0;
            for (int i = 0; i < count; i++)
            {
                Server buf = new Server(rand);
                Servers.Add(buf);
            }
        }

        public void SingleAddition(int number, double lambda)
        {
            ReqCount++;
            inputTime += ExpRandom.Generate(lambda, rand);
            Request nReq = new Request(inputTime);
            Servers[number].AddRequest(nReq);
        }

        public void RandomAdd(double tmax, double lambda, double mu)
        {
            while (inputTime <= tmax)
            {
                int rnd = rand.Next(0, Servers.Count);
                SingleAddition(rnd, lambda);
            }
            for (int j = 0; j < Servers.Count; j++)
            {
                Servers[j].FullProcess(mu);
                Servers[j].Normalize(tmax);
            }
        }

        public void RoundRobinAdd(double tmax, double lambda, double mu)
        {
            int i = 0;
            while (inputTime <= tmax)
            {
                SingleAddition(i % Servers.Count, lambda);
                i++;
            }
            for (int j = 0; j < Servers.Count; j++) 
            {
                Servers[j].FullProcess(mu);
                Servers[j].Normalize(tmax);
            }
        }

        public void JSQAdd(double tmax, double lambda, double mu)
        {
            for (int i = 0; (i < Servers.Count) && (inputTime <= tmax); i++)
                SingleAddition(i, lambda);
            while (inputTime <= tmax)
            {
                double minTimeExit = tmax + 1.0;
                int indexOfMin = 0;
                for (int i = 0; i < Servers.Count; i++)
                {
                    Servers[i].FullProcess(mu);
                    Servers[i].Normalize(tmax);
                }
                for (int i = 0; i < Servers.Count; i++)
                    if (Servers[i].Processed[Servers[i].Processed.Count - 1].ExitTime < minTimeExit)
                    {
                        indexOfMin = i;
                        minTimeExit = Servers[i].Processed[Servers[i].Processed.Count - 1].ExitTime;
                    }
                SingleAddition(indexOfMin, lambda);
                Servers[indexOfMin].Normalize(tmax);
            }
        }

        public int GetCountOfProcessed()
        {
            int sum = 0;
            for (int i = 0; i < Servers.Count; i++)
                sum += Servers[i].Processed.Count;
            return sum;
        }

        public double AverageTimeRequestInQueue()
        {
            double sum = 0.0;
            int numberOfRequests = 0;
            for (int i = 0; i < Servers.Count; i++)
            {
                numberOfRequests += Servers[i].Processed.Count;
                for (int j = 0; j < Servers[i].Processed.Count; j++)
                    sum += Servers[i].Processed[j].ProcessStartTime - Servers[i].Processed[j].ArrivalTime; 
            }
            return sum / numberOfRequests;
        }

        public double AverageTimeRequestInQuetch()
        {
            double sum = 0.0;
            int numberOfRequests = 0; 
            for (int i = 0; i < Servers.Count; i++)
            {
                numberOfRequests += Servers[i].Processed.Count; 
                for (int j = 0; j < Servers[i].Processed.Count; j++)
                    sum += Servers[i].Processed[j].ExitTime - Servers[i].Processed[j].ArrivalTime;
            }
            return sum / numberOfRequests;
        }

        public double AverageTimeOfProcessing()
        {
            double sum = 0.0;
            int numberOfRequests = 0;
            for (int i = 0; i < Servers.Count; i++)
            {
                numberOfRequests += Servers[i].Processed.Count; 
                for (int j = 0; j < Servers[i].Processed.Count; j++)                 
                    sum += Servers[i].Processed[j].ExitTime - Servers[i].Processed[j].ProcessStartTime;
            }           
            return sum / numberOfRequests;
        }

        public double AverageTimeOfServerIdle()
        {
            double sum = 0.0;
            for (int i = 0; i < Servers.Count; i++)
                for (int j = 1; j < Servers[i].Processed.Count; j++) 
                    sum += Servers[i].Processed[j].ProcessStartTime - Servers[i].Processed[j - 1].ExitTime;          
            return sum / Servers.Count;
        }

        public double AverageCountOfRequestsInQuetch(double tmax)
        {
            int tm = Convert.ToInt32(tmax) + 1;
            int[] countOfRequests = new int[tm];
            Array.Clear(countOfRequests, 0, tm);
            for (int i = 0; i < Servers.Count; i++)
                for (int j = 0; j < Servers[i].Processed.Count; j++)                    
                    for (int k = Convert.ToInt32(Servers[i].Processed[j].ArrivalTime); k <= Convert.ToInt32(Servers[i].Processed[j].ExitTime); k++)
                        countOfRequests[k]++;
            int sum = 0;
            for (int i = 0; i < tm; i++) 
                sum += countOfRequests[i];
            return Convert.ToDouble(sum) / (tmax + 1.0);
        }

        public double AverageCountOfRequestsInQueue(double tmax)
        {
            int tm = Convert.ToInt32(tmax) + 1;
            int[] countOfRequests = new int[tm];
            Array.Clear(countOfRequests, 0, tm);
            for (int i = 0; i < Servers.Count; i++)
                for (int j = 0; j < Servers[i].Processed.Count; j++)
                    for (int k = Convert.ToInt32(Servers[i].Processed[j].ArrivalTime); k <= Convert.ToInt32(Servers[i].Processed[j].ProcessStartTime); k++)
                        countOfRequests[k]++;
            int sum = 0;
            for (int i = 0; i < tm; i++)
                sum += countOfRequests[i];
            return Convert.ToDouble(sum) / (tmax + 1.0);
        }
    }
}
