using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class Quetch
    {
        private Random rand = new Random(); // Экземпляр класса Random
        public int ReqCount { get; set; } // Количество запросов, отправленных на сервера
        private double inputTime; // "Счётчик" времени входа в СМО для каждого требования
        public List<Server> Servers { get; set; }  = new List<Server>(); // Список серверов в СМО

        // Конструктор СМО. На вход подаётся количество серверов
        public Quetch(int count)
        {
            inputTime = 0; // Время входа изначально равно нулю
            ReqCount = 0; // Ни одно требование ещё не было отправлено
            for (int i = 0; i < count; i++) // Добавляем count штук серверов в список серверов Servers
            {
                Server buf = new Server(rand);
                Servers.Add(buf);
            }
        }

        // Добавление одиночного запроса. На вход подаётся интенсивность поступления
        // заявок и номер сервера, на который необходимо добавить запрос
        public void SingleAddition(int number, double lambda)
        {
            ReqCount++; // Увеличиваем число отправленных требований
            ReqCount++; // Увеличиваем число отправленных требований
            // Генерируем время поступления заявки при помощи Poisson и прибавляем его к времени поступления предыдущей заявки
            inputTime += ExpRandom.Generate(lambda, rand);
            // Создаём новый запрос с временем поступления inputTime и добавляем его на сервер под номером number
            Request nReq = new Request(inputTime);
            Servers[number].AddRequest(nReq);
        }

        // Генерация запросов по случайному алгоритму
        public void RandomAdd(double tmax, double lambda, double mu)
        {
            while (inputTime <= tmax) // Пока время поступления требования не превышает максимальное
            {
                // Генерируем случайное целое число, которое принадлежит лучу [0; Servers.Count)
                int rnd = rand.Next(0, Servers.Count);
                // Отправляем новое требование на сервер с номером rnd
                SingleAddition(rnd, lambda);
            }
            for (int j = 0; j < Servers.Count; j++) // Для каждого сервера
            {
                Servers[j].FullProcess(mu); // Запускаем процесс для всех требований в очереди
                Servers[j].Normalize(tmax); // Запускаем процесс нормализации
            }
        }

        // Генерация запросов по round-robin алгоритму
        public void RoundRobinAdd(double tmax, double lambda, double mu)
        {
            int i = 0; // i - номер поступившей заявки
            while (inputTime <= tmax) // Пока время поступления требования не превышает максимальное
            {
                SingleAddition(i % Servers.Count, lambda); // Отправляем заявку на сервер с номером i mod Servers.Count
                i++; // Увеличиваем номер поступившей заявки
            }
            for (int j = 0; j < Servers.Count; j++) // Для каждого сервера
            {
                Servers[j].FullProcess(mu); // Запускаем процесс для всех требований в очереди
                Servers[j].Normalize(tmax); // Запускаем процесс нормализации
            }
        }

        // Генерация запросов по JSQ алгоритму
        public void JSQAdd(double tmax, double lambda, double mu)
        {
            // Так как все сервера изначально пусты, имеет смысл добавить на каждый сервер по 1 требованию по порядку
            for (int i = 0; (i < Servers.Count) && (inputTime <= tmax); i++)
                SingleAddition(i, lambda);
            while (inputTime <= tmax) // Далее пока время поступления требования не превышает максимальное
            {
                double minTimeExit = tmax + 1.0; // Объявляем минимальное время выхода последнего требования из сервера
                int indexOfMin = 0; // и индекс сервера, последний элемент которого вышел из сервера раньше остальных
                for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
                {
                    Servers[i].FullProcess(mu); // Запускаем процесс единичного требования в очереди
                    Servers[i].Normalize(tmax); // Запускаем процесс нормализации
                }
                for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
                    // Если время выхода последнего элемента i-того сервера меньше, чем минимальное время выхода
                    if (Servers[i].Processed[Servers[i].Processed.Count - 1].ExitTime < minTimeExit)
                    {
                        // Обновляем значение индекса "минимального" сервера и минимального времени выхода
                        indexOfMin = i;
                        minTimeExit = Servers[i].Processed[Servers[i].Processed.Count - 1].ExitTime;
                    }
                SingleAddition(indexOfMin, lambda); // Отправляем требование на "минимальный" сервер
                Servers[indexOfMin].Normalize(tmax); // Нормализуем "минимальный" сервер
            }
        }

        // Расчёт количества обработанных запросов
        public int GetCountOfProcessed()
        {
            int sum = 0; // Объявляем переменную суммы числа обработанных
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
                sum += Servers[i].Processed.Count; // Прибавляем размер списка обработанных требований к сумме
            return sum; // Выводим сумму
        }

        // Среднее время нахождения заявки в очереди
        public double AverageTimeRequestInQueue()
        {
            double sum = 0.0; // Объявляем переменную суммы времени нахождения требования в очереди
            int numberOfRequests = 0; // Объявляем переменную количества требований
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
            {
                numberOfRequests += Servers[i].Processed.Count; // Увеличиваем количество требований на размер списка обработанных
                for (int j = 0; j < Servers[i].Processed.Count; j++) // Для каждого обработанного запроса в сервере
                // Увеличиваем сумму на разность времени начала обработки и времени поступления заявки в СМО (что и есть время в очереди)
                    sum += Servers[i].Processed[j].ProcessStartTime - Servers[i].Processed[j].ArrivalTime; 
            }
            // Возвращаем сумму разделенную на количество требований, что и есть среднее время в очереди для требования
            return sum / numberOfRequests;
        }

        // Среднее время нахождения заявки в СМО
        public double AverageTimeRequestInQuetch()
        {
            double sum = 0.0; // Объявляем переменную суммы времени нахождения требования в СМО
            int numberOfRequests = 0; // Объявляем переменную количества требований
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
            {
                numberOfRequests += Servers[i].Processed.Count; // Увеличиваем количество требований на размер списка обработанных
                for (int j = 0; j < Servers[i].Processed.Count; j++) // Для каждого обработанного запроса в сервере
                // Увеличиваем сумму на разность времени выхода и времени поступления заявки в СМО (что и есть время в СМО)
                    sum += Servers[i].Processed[j].ExitTime - Servers[i].Processed[j].ArrivalTime;
            }
            // Возвращаем сумму разделенную на количество требований, что и есть среднее время в СМО для требования
            return sum / numberOfRequests;
        }

        // Среднее время обработки заявки
        public double AverageTimeOfProcessing()
        {
            double sum = 0.0; // Объявляем переменную суммы времени обработки требований
            int numberOfRequests = 0; // Объявляем переменную количества требований
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
            {
                numberOfRequests += Servers[i].Processed.Count; // Увеличиваем количество требований на размер списка обработанных
                for (int j = 0; j < Servers[i].Processed.Count; j++) // Для каждого обработанного запроса в сервере
                // Увеличиваем сумму на разность времени выхода и времени начала обработки (что и есть время обработки)
                    sum += Servers[i].Processed[j].ExitTime - Servers[i].Processed[j].ProcessStartTime;
            }
            // Возвращаем сумму разделенную на количество требований, что и есть среднее время обработки для требования
            return sum / numberOfRequests;
        }

        // Среднее время простоя сервера
        public double AverageTimeOfServerIdle()
        {
            double sum = 0.0; // Объявляем переменную суммы времени простоя серверов
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
                for (int j = 1; j < Servers[i].Processed.Count; j++) // Для каждого обработанного, кроме первого
                    // Увеличиваем сумму на разность между временем начала обработки i-того элемента
                    // и временем выхода предыдущего элемента (что и есть время простоя сервера)
                    sum += Servers[i].Processed[j].ProcessStartTime - Servers[i].Processed[j - 1].ExitTime;
            // Возвращаем сумму разделенную на количество серверов, что и есть среднее время простоя для сервера
            return sum / Servers.Count;
        }

        // Среднее число заявок в СМО в единицу времени
        public double AverageCountOfRequestsInQuetch(double tmax)
        {
            // Объявляем массив числа запросов для каждой единицы времени длины tm (tmax + 1) и обнуляем его
            int tm = Convert.ToInt32(tmax) + 1;
            int[] countOfRequests = new int[tm];
            Array.Clear(countOfRequests, 0, tm);
            for (int i = 0; i < Servers.Count; i++) // Для каждого сервера
                for (int j = 0; j < Servers[i].Processed.Count; j++) // Для каждого запроса
                    // Для каждой единицы времени, лежащей между временем поступления заявки в СМО и временем выхода этой заявки
                    for (int k = Convert.ToInt32(Servers[i].Processed[j].ArrivalTime); k <= Convert.ToInt32(Servers[i].Processed[j].ExitTime); k++)
                        countOfRequests[k]++; // Увеличиваем число требований в конкретную единицу времени на 1
            int sum = 0; // Объявляем сумму числа заявок каждой единицы времени
            for (int i = 0; i < tm; i++) // Для каждой единицы времени
                sum += countOfRequests[i]; // Увеличиваем сумму на число заявок в конкретную единицу времени
            // Возвращаем сумму, разделённую на число единиц времени, что и есть среднее количество
            // заявок в СМО для единицы измерения времени
            return Convert.ToDouble(sum) / (tmax + 1.0);
        }

        // Среднее число заявок в очереди в единицу времени
        // Данный метод полностью аналогичен предыдущему, кроме последнего вложенного цикла:
        // в данном методе увеличивается каждая единица времени между временем поступлением заявки в СМО
        // и временем её начала обработки
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
