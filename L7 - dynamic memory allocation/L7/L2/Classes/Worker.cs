using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for workers information
    /// </summary>
    public class Worker
    {
        public DateTime Date { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int PartsCount { get; set; }
        public int Days = 1; // days worked
        public int AllPartsCount = 0; // sum of all made parts
        public double EarnedSum = 0.00; // total earned sum

        /// <summary>
        /// Worker information
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="surname">Surnsme</param>
        /// <param name="name">Name</param>
        /// <param name="code">Code</param>
        /// <param name="parts">Parts count</param>
        public Worker(DateTime date, string surname, string name, string code,
                      int parts)
        {
            this.Date = date;
            this.Surname = surname;
            this.Name = name;
            this.Code = code;
            this.PartsCount = parts;
        }

        /// <summary>
        /// Returns worker information
        /// </summary>
        /// <returns>Formated line</returns>
        public override string ToString()
        {
            return string.Format("| {0,15} | {1,-20} | {2,-20} | {3,8} | {4,8} |",
                Date.ToShortDateString(), Surname, Name, Code, PartsCount);
        }

        /// <summary>
        /// Compares two workers by surname and name
        /// </summary>
        /// <param name="other">Other worker</param>
        /// <returns>Condition</returns>
        public int CompareTo(Worker other)
        {
            if (Surname.CompareTo(other.Surname) == 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return Surname.CompareTo(other.Surname);
            }
        }
    } 
    

}