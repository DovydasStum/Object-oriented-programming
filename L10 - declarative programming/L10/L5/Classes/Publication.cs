using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5
{
    /// <summary>
    /// A class for publication data
    /// </summary>
    [Serializable]
    public class Publication : IComparable<Publication>, 
                 IEquatable<Publication>, IEnumerable<string>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PublisherName { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="name">Name</param>
        /// <param name="pName">Publisher name</param>
        /// <param name="price">Price</param>
        public Publication (string code, string name, 
                            string pName, double price)
        {
            Code = code;
            Name = name;
            PublisherName = pName;
            Price = price;
        }

        /// <summary>
        /// Checks the equality of two publications
        /// </summary>
        /// <param name="pub">Publication to check</param>
        /// <returns>True or false</returns>
        public bool Equals (Publication pub)
        {
            return Code == pub.Code && Name == pub.Name &&
                   PublisherName == pub.PublisherName 
                   && Price == pub.Price;
        }

        /// <summary>
        /// Compares two publications by their names
        /// </summary>
        /// <param name="pub">Publication to compare</param>
        /// <returns>Comparison</returns>
        public int CompareTo (Publication pub)
        {
            return Name.CompareTo(pub.Name);
        }

        /// <summary>
        /// Makes a line with publications data
        /// </summary>
        /// <returns>Formatted line</returns>
        public override string ToString()
        {
            return string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,20} |",
                                 Code, Name, PublisherName, Price);
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return PublisherName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}