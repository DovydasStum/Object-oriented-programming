using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for workers information
    /// </summary>
    public class Worker : IComparable<Worker>, IEquatable<Worker>
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
        /// <param name="obj">Other worker</param>
        /// <returns>Condition</returns>
        public int CompareTo(Worker obj)
        {
            if ((object)obj == null)
            {
                return 1;
            }
            Worker other = obj as Worker;
            if (Surname.CompareTo(other.Surname) == 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return Surname.CompareTo(other.Surname);
            }
        }

        /// <summary>
        /// Checks if the objects are equal
        /// </summary>
        /// <param name="worker">Object</param>
        /// <returns>Condition</returns>
        public bool Equals (Worker worker)
        {
            if (Object.ReferenceEquals(worker, null)) // checks if the object exists
            {
                return false;
            }
            if (this.GetType() != worker.GetType()) // checks if the class is the same
            {
                return false;
            }
            // return comparison
            return worker.Name == Name && worker.Surname == Surname;
        }

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    } 
    
}