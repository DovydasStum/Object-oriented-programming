using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for parts linked list
    /// </summary>
    public class PartsList
    {
        private Node head; // head of the list
        private Node tail; // tail of the list
        private Node current; // current node

        /// <summary>
        /// Private Node class for parts data and links
        /// </summary>
        private sealed class Node
        {
            public Part Data { get; set; } // Part's data
            public Node Link { get; set; } // Link to next object
            public Node() { }
            /// <summary>
            /// Creates new node
            /// </summary>
            /// <param name="value">Part</param>
            /// <param name="address">Address</param>
            public Node(Part value, Node address)
            {
                Data = value;
                Link = address;
            }
        }

        /// <summary>
        /// Creates new parts list
        /// </summary>
        public PartsList()
        {
            this.head = null;
            this.tail = null;
        }

        /// <summary>
        /// Adds part to reverse List
        /// </summary>
        /// <param name="part">Part</param>
        public void SetLifo(Part part)
        {
            head = new Node(part, head);
        }

        /// <summary>
        /// Adds part's to consecutive list
        /// </summary>
        /// <param name="part">Part</param>
        public void SetFifo(Part part)
        {
            var dd = new Node(part, null);
            if (head != null)
            {
                tail.Link = dd;
                tail = dd;
            }
            else
            {
                head = dd;
                tail = dd;
            }
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
        /// Checks if next node is not the end of a list
        /// </summary>
        /// <returns>Condition</returns>
        public bool Contains()
        {
            return current != null && current.Data != null;
        }

        /// <summary>
        /// Return part's data
        /// </summary>
        /// <returns>Part's data</returns>
        public Part Data()
        {
            return current.Data;
        }

        /// <summary>
        /// Deletes list
        /// </summary>
        public void DeleteList()
        {
            while (head != null)
            {
                Node d = head;
                head = head.Link;
                d.Link = null;
                d.Data = null;
            }
        }
    }

}