using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for parts data
    /// </summary>
    public class Part
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Part specifications
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="name">Name</param>
        /// <param name="price">Price</param>
        public Part(string code, string name, double price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Returns part specifications
        /// </summary>
        /// <returns>Formated line</returns>
        public override string ToString()
        {
            return string.Format("| {0,8} | {1,-20} | {2,9} |",
                                 Code, Name, Price);
        }
    }

}