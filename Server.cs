using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Server
    {
        private Random rand = new Random(DateTime.Now.Millisecond);
        public List<Request> Queue { get; set; } = new List<Request>(); // Список запросов в очереди
        public List<Request> Processed { get; set; } = new List<Request>(); // Список обработанных запросов

        // Конструктор сервера (при создании - нет ни очереди запросов, ни обработанных,
        // поэтому списки изначально пусты). На вход подаётся экземпляр класса Random
        public Server(Random rnd) 
        {
             rand = rnd;
        }

        // Добавление запроса (изначально попадает в очередь)
        public void AddRequest(Request value)
        {
            Queue.Add(value);
        }

        // Обработка одиночного запроса. На вход подаётся мю
        public void Process(double mu)
        {
            int prCount = Processed.Count; // Число элементов в списке обработанных
            if (prCount == 0) // Если ни один запрос ещё не был отработан
                              // то время начала обработки равно времени прибытия
                Queue[0].ProcessStart(Queue[0].ArrivalTime);
            else // Если же обработанные уже есть
                 // и время выхода последнего обработанного больше, чем время прибытия текущего

                if (Processed[prCount - 1].ExitTime > Queue[0].ArrivalTime)
                // время начала обработки равно времени выхода последнего обработанного
                Queue[0].ProcessStart(Processed[prCount - 1].ExitTime);
            // если же время выхода последнего обработанного меньше, чем время прибытия текущего
            else
                // то время начала обработки равно времени прибытия
                Queue[0].ProcessStart(Queue[0].ArrivalTime);
            // завершаем обработку запроса
            Queue[0].Exit(ExpRandom.Generate(mu, rand));
            // Добавляем запрос в список обработанных
            Processed.Add(Queue[0]);
            // Удаляем запрос из очереди
            Queue.RemoveAt(0);
        }

        // Обработка всех запросов из очереди. На вход подаётся параметр интенсивности обслуживания, при помощи
        // которого на основе пуассоновского распределения вычисляется время обработки для каждого запроса.
        public void FullProcess(double mu)
        {
            // Пока в очереди что-то есть - запускаем процесс
            while (Queue.Count > 0)
                Process(mu);
        }

        // Нормализация сервера (удаление запросов, которые вышли после максимального времени)
        public void Normalize(double maxtime)
        {
            for (int i = Processed.Count - 1; i >= 0; i--)
                if (Processed[i].ExitTime > maxtime)
                    Processed.RemoveAt(i);
        }
    }
}
