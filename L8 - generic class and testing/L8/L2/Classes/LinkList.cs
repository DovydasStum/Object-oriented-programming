using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for linked list
    /// </summary>
    public class LinkList<type> : IEnumerable<type>
            where type : IComparable<type>, IEquatable<type>
    {
        private Node<type> head; // head of the list
        private Node<type> tail; // tail of the list
        private Node<type> current; // current node

        /// <summary>
        /// Private Node class for workers data and links
        /// </summary>
        public sealed class Node<type>
            where type : IComparable<type>, IEquatable<type>
        {
            public type Data { get; set; } // Worker's data
            public Node<type> Link { get; set; } // Link to next object
            public Node() { }
            /// <summary>
            /// Creates new node
            /// </summary>
            /// <param name="value">Worker</param>
            /// <param name="address">Address</param>
            public Node(type value, Node<type> address)
            {
                Data = value;
                Link = address;
            }
        }

        /// <summary>
        /// Creates new workers list 
        /// </summary>
        public LinkList()
        {
            this.head = null;
            this.tail = null;
        }

        /// <summary>
        /// Adds worker to reverse List
        /// </summary>
        /// <param name="worker">Worker</param>
        public void SetLifo(type worker)
        {
            head = new Node<type>(worker, head);
        }

        /// <summary>
        /// Makes current node return to start
        /// </summary>
        public void Begin()
        {
            current = head;
        }

        /// <summary>
        /// Makes current node the next node
        /// </summary>
        public void Next()
        {
            current = current.Link;
        }

        /// <summary>
        /// Checks if the next node is not the end of a list
        /// </summary>
        /// <returns>Condition</returns>
        public bool Contains()
        {
            return current != null && current.Data != null;
        }

        /// <summary>
        /// Returns worker's data
        /// </summary>
        /// <returns>Worker's data</returns>
        public type Data()
        {
            return current.Data;
        }

        /// <summary>
        /// Returns the head of the list
        /// </summary>
        /// <returns>Head</returns>
        public Node<type> ReturnHead()
        {
            return head;
        }

        /// <summary>
        /// Sorts by surname and name aplhabetically
        /// </summary>
        public void Sort()
        {
            for (Node<type> d1 = head; d1 != null; d1 = d1.Link)
            {
                Node<type> minValue = d1;
                for (Node<type> d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    var result = Comparer<type>.Default.Compare(d2.Data, minValue.Data);
                    if (result < 0)
                    {
                        minValue = d2;
                    }
                }
                type temp = d1.Data;
                d1.Data = minValue.Data;
                minValue.Data = temp;
            }
        }

        public IEnumerator<type> GetEnumerator()
        {
            for (Node<type> current = head; current != null; current = current.Link)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}