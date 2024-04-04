using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I2
{
    class OlderStudents
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public int Course { get; set; }
        public string Phone { get; set; }
        public string Mark { get; set; }
        public string Year { get; set; }

        public OlderStudents(string surname, string name, DateTime date, int id, int course, string phone, string mark, string year)
        {
            this.Surname = surname;
            this.Name = name;
            this.Date = date;
            this.ID = id;
            this.Course = course;
            this.Phone = phone;
            this.Mark = mark;
            this.Year = year;
        }
    }
}
