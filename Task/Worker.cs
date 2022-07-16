using System;
using System.IO;
using System.Text;

namespace Task
{
    public struct Worker
    {
        private int _ID;
        private DateTime _date;
        private string _name;
        private int _age;
        private double _height;
        private DateTime _birthdayDate;
        private string _birthdayPlace;

        public Worker(string name, int age, double height, string birthdayDate, string birthdayPlace)
        {
            _ID = File.Exists("staff.txt") ? File.ReadAllLines("staff.txt").Length + 1 : 1;
            _date = DateTime.Now;
            _name = name;
            _age = age;
            _height = height;
            DateTime.TryParse(birthdayDate, out _birthdayDate);
            _birthdayPlace = birthdayPlace;
            WriteWorker();
        }

        /// <summary>
        /// Возвращает ID сотрудника.
        /// </summary>
        public int ID
        {
            get { return _ID; }
            private set { _ID = value; }
        }

        /// <summary>
        /// Возвращает дату создания записи о сотруднике.
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            private set { _date = DateTime.Now; }
        }

        /// <summary>
        /// Возвращает или задаёт новое имя сотрудника.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrWhiteSpace(value)) _name = value; }
        }

        /// <summary>
        /// Возвращает или задаёт новое значение возраста.
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { if (value > 0 && value < 120) _age = value; }
        }

        /// <summary>
        /// Возвращает или задаёт новое значение роста.
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { if (_height > 0 && _height < 250) _height = value; }
        }

        /// <summary>
        /// Возвращает день рождения сотрудника.
        /// </summary>
        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            private set { _birthdayDate = value; }
        }

        /// <summary>
        /// Возвращает место рождения сотрудника.
        /// </summary>
        public string BirthdayPlace
        {
            get { return _birthdayPlace; }
            private set { if (!string.IsNullOrWhiteSpace(value)) _birthdayPlace = value; }
        }

        /// <summary>
        /// Выводит информацию о сотруднике.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{ID} {Date.ToString()} {Name} {Height} {BirthdayDate.ToShortDateString()} {BirthdayPlace}");
        }

        /// <summary>
        /// Записывает запись о сотруднике в файл.
        /// </summary>
        public void WriteWorker(string path = "staff.txt", string delim = "#")
        {
            using (StreamWriter sw = new StreamWriter("staff.txt", true, Encoding.Unicode))
            {   
                string note = string.Empty;

                note += _ID + delim;
                note += _date.ToShortDateString() + delim;
                note += _name + delim;
                note += _age + delim;
                note += _height + delim;
                note += _birthdayDate.ToShortDateString() + delim;
                note += _birthdayPlace;

                sw.WriteLine(note);
            }
        }
    }
}
