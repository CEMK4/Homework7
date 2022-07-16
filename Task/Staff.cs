using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task
{
    public class Staff
    {
        public List<Worker> staff;

        public Staff()
        {
            staff = new List<Worker>();
        }

        /// <summary>
        /// Добавляет нового сотрудника класса Worker.
        /// </summary>        
        public void AddWorker(Worker worker)
        {
            staff.Add(worker);
        }

        /// <summary>
        /// Добавляет нового сотрудника по его личным данным.
        /// </summary>        
        public void AddWorker(string name, int age, double height, string birthdayDate, string birthdayPlace)
        {
            Worker worker = new Worker(name,age,height,birthdayDate,birthdayPlace);
            staff.Add(worker);            
        }

        /// <summary>
        /// Удаляет сотрудника из записи.
        /// </summary>        
        public void RemoveWorker(Worker worker)
        {
            staff.Remove(worker);
        }

        /// <summary>
        /// Выводит информацию по конкретному сотруднику.
        /// </summary>        
        public void PrintWorker(int ID)
        {
            staff.Find((Worker worker) => worker.ID == ID).Print();
        }

        /// <summary>
        /// Выводит сотрудников в диапазоне [firstDate, secondDate].
        /// </summary>        
        public void PrintWorkersInRange(string firstDate, string secondDate)
        {
            if (File.Exists("staff.txt"))
                using (StreamReader sr = new StreamReader("staff.txt"))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        if (DateTime.Compare(DateTime.Parse(firstDate), DateTime.Parse(line.Split('#')[1])) <= 0 &&
                            DateTime.Compare(DateTime.Parse(line.Split('#')[1]), DateTime.Parse(secondDate)) <= 0)
                        {
                            foreach (var item in line.Split('#'))
                                Console.Write(item + " ");
                            Console.WriteLine();
                        }
                        line = sr.ReadLine();
                    }
                }
            else
                Console.WriteLine("Файла с информацией о сотрудниках не существует.");
        }

        /// <summary>
        /// Упорядочивает сотрудников по уменьшению даты добавления в запись.
        /// </summary>
        public void OrderDescending()
        {
            staff = staff.OrderByDescending(worker => worker.Date).ToList();
        }

        /// <summary>
        /// Упорядочивает сотрудников по увеличению даты добавления в запись.
        /// </summary>
        public void OrderAscending()
        {
            staff = staff.OrderBy(worker => worker.Date).ToList();
        }

        /// <summary>
        /// Выводит информацию всех сотрудников из записи.
        /// </summary>
        public void Print()
        {
            foreach (Worker worker in staff)
            {
                worker.Print();
            }
        }

        /// <summary>
        /// Выводит информацию всех сотрудников, записанных в файл.
        /// </summary>
        public void PrintFile(string path = "staff.txt")
        {
            if (File.Exists(path))
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        foreach (var item in line.Split('#'))
                            Console.Write(item + " ");
                        Console.WriteLine();
                        line = sr.ReadLine();
                    }
                }
            else
                Console.WriteLine("Файла с информацией о сотрудниках не существует.");
        }

        /// <summary>
        /// Записывает всех сотрудников из записи в файл.
        /// </summary>        
        public void WriteWorkers(string path = "staff.txt", string delim = "#")
        {
            using (StreamWriter sw = new StreamWriter("staff.txt", false, Encoding.Unicode))
            {
                foreach (Worker worker in staff)
                {
                    worker.WriteWorker();
                }
            }
        }

        /// <summary>
        /// Считывает всех сотрудников из файла в запись.
        /// </summary>        
        public void ReadWorkers(string path = "staff.txt")
        {
            string[] workersStringArray = File.ReadAllLines(path);
            File.Delete(path);
            foreach (string worker in workersStringArray)
            {
                string[] workerString = worker.Split('#');
                AddWorker(new Worker(workerString[2], int.Parse(workerString[3]), int.Parse(workerString[4]), workerString[5], workerString[6]));
            }
        }        
    }
}
