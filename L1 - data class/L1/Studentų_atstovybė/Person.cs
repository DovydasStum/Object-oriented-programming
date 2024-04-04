using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Studentų_atstovybė
{
    class Person // class for information about one student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public int Course { get; set; }
        public string Phone { get; set; }
        public string Mark  { get; set; }

        public Person(string surname, string name, DateTime date, int number,
                      int course, string phone, string mark)
        {
            this.Surname = surname;
            this.Name = name;
            this.Date = date;
            this.Number = number;
            this.Course = course;
            this.Phone = phone;
            this.Mark = mark;
        }

        /// <summary>
        /// Finds the age of oldest person
        /// </summary>
        /// <returns></returns>
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.Date.Year;
            if (this.Date.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
