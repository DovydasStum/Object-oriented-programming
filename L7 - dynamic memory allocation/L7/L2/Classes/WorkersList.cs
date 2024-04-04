using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// A class for workers linked list
    /// </summary>
    public class WorkersList
    {
        private Node head; // head of the list
        private Node tail; // tail of the list
        private Node current; // current node

        /// <summary>
        /// Private Node class for workers data and links
        /// </summary>
        private sealed class Node
        {
            public Worker Data { get; set; } // Worker's data
            public Node Link { get; set; } // Link to next object
            public Node() { }
            /// <summary>
            /// Creates new node
            /// </summary>
            /// <param name="value">Worker</param>
            /// <param name="address">Address</param>
            public Node(Worker value, Node address)
            {
                Data = value;
                Link = address;
            }
        }

        /// <summary>
        /// Creates new workers list 
        /// </summary>
        public WorkersList()
        {
            this.head = null;
            this.tail = null;
        }

        /// <summary>
        /// Adds worker to reverse List
        /// </summary>
        /// <param name="worker">Worker</param>
        public void SetLifo(Worker worker)
        {
            head = new Node(worker, head);
        }

        /// <summary>
        /// Adds worker to consecutive list
        /// </summary>
        /// <param name="worker">Worker</param>
        public void SetFifo(Worker worker)
        {
            var dd = new Node(worker, null);
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
        /// Checks if list contains worker
        /// </summary>
        /// <param name="worker">Worker</param>
        /// <returns>Condition</returns>
        public bool Contains(Worker worker)
        {
            for (Node d1 = head; d1 != null; d1 = d1.Link)
            {
                if (d1.Data.Name == worker.Name &&
                    d1.Data.Surname == worker.Surname)
                {
                    return true;
                }
            }
            return false;
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
        /// Return worker's data
        /// </summary>
        /// <returns>Worker's data</returns>
        public Worker Data()
        {
            return current.Data;
        }

        /// <summary>
        /// Sorts by surname and name aplhabetically
        /// </summary>
        public void Sort()
        {
            for (Node d1 = head; d1 != null; d1 = d1.Link)
            {
                Node minValue = d1;
                for (Node d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    if (d2.Data.CompareTo(minValue.Data) < 0)
                    {
                        minValue = d2;
                    }
                }
                Worker worker = d1.Data;
                d1.Data = minValue.Data;
                minValue.Data = worker;
            }
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

        /// <summary>
        /// Makes a copy of the list
        /// </summary>
        /// <returns>Copy of the list</returns>
        public WorkersList Copy()
        {
            WorkersList Copy = new WorkersList();
            for (Node d1 = head; d1 != null; d1 = d1.Link)
            {
                Copy.SetFifo(d1.Data);
            }
            return Copy;
        }


        /// <summary>
        /// Removes node from List
        /// </summary>
        public void Remove()
        {
            Node next = current.Link;
            if (next != null)
            {
                current.Data = next.Data;
                current.Link = next.Link;
                next = null;
            }
            else if (next == null)
            {
                tail.Link = current;
                tail = current;
                current.Data = null;
                current.Link = null;
            }

        }

        /// <summary>
        /// Counts workers
        /// </summary>
        /// <returns>Sum of workers</returns>
        public int WorkersCount()
        {
            int i = 0;
            for (Begin(); Contains(); Next())
            {
                i++;
            }
            return i;
        }
    }
}