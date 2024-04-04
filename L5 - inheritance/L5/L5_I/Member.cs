using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    public abstract class Member
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }

        public Member(string surname, string name, DateTime date,
                      string phone)
        {
            this.Surname = surname;
            this.Name = name;
            this.Date = date;
            this.Phone = phone;
        }

        /// <summary>
        /// Overrides data to string
        /// </summary>
        /// <returns>Line</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("| {0,-12} | {1,-12} | {2,12} |" +
                                 " {3,11} |", Surname, Name,
                                 Date.ToShortDateString(), Phone);
            return line;
        }

        /// <summary>
        /// Compares two member's properties
        /// </summary>
        /// <param name="member">member</param>
        /// <returns>Surname of student</returns>
        public override bool Equals(object member)
        {
            return this.Phone == ((Member)member).Phone;
        }

        /// <summary>
        /// Gets hash code of member
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return this.Phone.GetHashCode();
        }

        /// <summary>
        /// Checks if member's birth date is the same as the oldest's member's
        /// </summary>
        /// <param name="MembersContainer">Container of members</param>
        /// <param name="OldestDate">Birth date of the oldest member</param>
        /// <returns>True if date is equal to the oldest's member's date</returns>
        public static bool operator ==(Member MembersContainer, DateTime OldestDate)
        {
            return MembersContainer.Date == OldestDate;
        }
        public static bool operator !=(Member MembersContainer, DateTime OldestDate)
        {
            return MembersContainer.Date != OldestDate;
        }


        /// <summary>
        /// Compares member by surname and name
        /// </summary>
        /// <param name="other">Other member</param>
        /// <returns>Comparison</returns>
        public int CompareTo(Member other)
        {
            if (this.Surname == other.Surname)
            {
                return this.Name.CompareTo(other.Name);
            }
            else
            {
                return this.Surname.CompareTo(other.Surname);
            }
        }

    }
}
