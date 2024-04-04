using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{   
    /// <summary>
    /// A class for parts data
    /// </summary>
    public class Part : IComparable<Part>, IEquatable<Part>
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

        /// <summary>
        /// Checks if the objects are equal
        /// </summary>
        /// <param name="part">Object</param>
        /// <returns>Condition</returns>
        public bool Equals(Part part)
        {
            if (Object.ReferenceEquals(part, null)) // checks if the object exists
            {
                return false;
            }
            if (this.GetType() != part.GetType()) // checks if the class is the same
            {
                return false;
            }
            // return comparison
            return part.Code == Code;
        }

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares two parts
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Comparison</returns>
        public int CompareTo(Part obj)
        {
            if ((object)obj == null)
            {
                return 1;
            }
            Part other = obj as Part;
            return Code.CompareTo(other.Code);
        }

    }

}