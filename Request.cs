using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Request
    {
        /* private double arrivalTime;
         * public double ArrivalTime
         * {
         * get { return arrivalTime; }
         * set { arrivalTime - value; }
         * }
         * РАВНОСИЛЬНО
         * public double ArrivalTime { get; set; } */
        public double ArrivalTime { get; set; } // Время поступления
        public double ProcessStartTime { get; set; } // Время начала обработки
        public double ExitTime { get; set; } // Время выхода

        // Конструктор запроса. На вход подаётся время прибытия, остальные поля
        // у "новоприбывшего" запроса отсутствуют, поэтому обнуляются
        public Request(double at)
        {
            ArrivalTime = at;
            ProcessStartTime = 0;
            ExitTime = 0;
        }

        // Метод начала обработки запроса. На вход подаётся время начала обработки
        public void ProcessStart(double pst)
        {
            ProcessStartTime = pst;
        }

        // Метод выхода. На вход подаётся время обработки, время
        // выхода равно времени начала обработки плюс время обработки
        public void Exit(double pt)
        {
            ExitTime = pt + ProcessStartTime;
        }
    }
}
