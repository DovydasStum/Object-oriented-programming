using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5
{
    /// <summary>
    /// A class for subscriber's data
    /// </summary>
    [Serializable]
    public class Subscriber : IComparable<Subscriber>,
                 IEquatable<Subscriber>, IEnumerable<string>
    {
        public DateTime Date { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public int StartMonth { get; set; }
        public int SubscriptionLength { get; set; }
        public string Code { get; set; }
        public int PublicationsCount { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="person">Person's name and surname</param>
        /// <param name="address">Address</param>
        /// <param name="start">Month to start subscription</param>
        /// <param name="length">Subcription length</param>
        /// <param name="code">Publication code</param>
        /// <param name="count">Publication quantity</param>
        public Subscriber (DateTime date, string person, string address,
                           int start, int length, string code, int count)
        {
            Date = date;
            Person = person;
            Address = address;
            StartMonth = start;
            SubscriptionLength = length;
            Code = code;
            PublicationsCount = count;
        }

        /// <summary>
        /// Makes a line with subcriber's data
        /// </summary>
        /// <returns>Formatted line</returns>
        public override string ToString()
        {
            return string.Format("| {0,-20} | {1,-25} | {2,-20} | {3,20} |" +
                                 " {4,25} | {5,-15} | {6,20} |",
                                 Date.ToShortDateString(), Person, Address,
                                 StartMonth, SubscriptionLength, Code,
                                 PublicationsCount);
        }

        /// <summary>
        /// Checks if two objects are equal
        /// </summary>
        /// <param name="sub">Subcriber to check</param>
        /// <returns>True or false</returns>
        public bool Equals (Subscriber sub)
        {
            return Date == sub.Date && Person == sub.Person && Address == sub.Address
                   && StartMonth == sub.StartMonth &&
                   SubscriptionLength == sub.SubscriptionLength &&
                   Code == sub.Code && PublicationsCount == sub.PublicationsCount;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return Code;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Compares two subscribers
        /// </summary>
        /// <param name="other">Other to compare</param>
        /// <returns>Comparison</returns>
        public int CompareTo(Subscriber other)
        {
            return Person.CompareTo(other.Person);
        }
    }
}