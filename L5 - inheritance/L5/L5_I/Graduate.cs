using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    public class Graduate : Member
    {
        public string WorkPlace { get; set; }

        public Graduate(string surname, string name, DateTime date,
                       string phone, string workplace) :
                       base(surname, name, date, phone)
        {
            this.WorkPlace = workplace;
        }

        /// <summary>
        /// Overrides data to string
        /// </summary>
        /// <returns>Line</returns>
        public override string ToString()
        {
            string line;
            line = string.Format(base.ToString() + "{0,5} | {1,6} |" +
                                 " {2,-10} |", "", "", WorkPlace);
            return line;
        }

    }    
}
