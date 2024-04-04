using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5
{
    /// <summary>
    /// A class for one publisher data
    /// </summary>
    [Serializable]
    public class Publisher
    {
        public string Name { get; set; }
        public List<string> AllPublicationsCodes = new List<string>();
        public double TotalPrice = 0.00;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Publisher name</param>
        /// <param name="publications">Publications list</param>
        public Publisher (string name, List<string> publications)
        {
            Name = name;
            AllPublicationsCodes = publications;
        }

        /// <summary>
        /// Returns formatted line with data
        /// </summary>
        /// <returns>Line</returns>
        public override string ToString()
        {
            return string.Format("| {0,-20} | {1,11} |", Name, TotalPrice);
        }

    }
}