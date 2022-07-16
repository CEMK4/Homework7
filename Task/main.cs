using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Task
{
    class main
    {
        static void Main(string[] args)
        {
            Staff staff = new Staff();

            staff.AddWorker(new Worker("AAA", 20, 180, "1.1.2002", "Москва"));
            Thread.Sleep(1000);
            staff.AddWorker(new Worker("BBB", 20, 180, "2.1.2002", "Москва"));
            Thread.Sleep(1000);
            staff.AddWorker(new Worker("CCC", 20, 180, "3.1.2002", "Москва"));
            Thread.Sleep(1000);
            staff.AddWorker(new Worker("DDD", 20, 180, "4.1.2002", "Москва"));

            //staff.ReadWorkers();
            
            Console.WriteLine("Вывод информации о сотрудниках:");
            staff.Print();

            Console.WriteLine("\nВывод информации о сотрудниках, упорядоченный по убыванию даты добавления:");
            staff.OrderDescending();
            staff.Print();

            Console.WriteLine("\nВывод 1-ого сотрудника:");
            staff.PrintWorker(1);

            Console.WriteLine("\nВывод 3-ого сотрудника:");
            staff.PrintWorker(3);
        }
    }
}

