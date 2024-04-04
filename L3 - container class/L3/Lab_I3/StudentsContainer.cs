using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_I3
{
    class StudentsContainer
    {
        private Student[] Students;
        public int Count { get; private set; }
        private int Capacity;
        public StudentsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.Students = new Student[capacity];
        }

        /// <summary>
        /// Ensures capacity
        /// </summary>
        /// <param name="minimumCapacity">Minimal capacity</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Student[] temp = new Student[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Students[i];
                }
                this.Capacity = minimumCapacity;
                this.Students = temp;
            }
        }

        /// <summary>
        /// Adds student to the container
        /// </summary>
        /// <param name="student">Student</param>
        public void Add(Student student)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Students[this.Count++] = student;
        }

        /// <summary>
        /// Gets element by index
        /// </summary>
        /// <param name="Index">Index</param>
        /// <returns>Element</returns>
        public Student Get(int index)
        {
            return this.Students[index];
        }

        /// <summary>
        /// Checks if student exists
        /// </summary>
        /// <param name="student">Student</param>
        /// <returns>True or false</returns>
        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Puts element to the specific place
        /// </summary>
        /// <param name="index">index of element</param>
        /// <param name="student">element</param>
        public void Put(int index, Student student)
        {
            if (0 <= index && index < this.Count)
            {
                this.Students[index] = student;
            }
        }

        /// <summary>
        /// Inserts element in the container
        /// </summary>
        /// <param name="index">index of element</param>
        /// <param name="student">element</param>
        public void Insert(int index, Student student)
        {
            if (0 <= index && index < this.Count)
            {
                if (this.Count == this.Capacity) //container is full
                {
                    EnsureCapacity(this.Capacity * 2);
                }
                for (int i = this.Count - 1; i >= index; i--)
                {
                    this.Students[i + 1] = this.Students[i];
                }
                this.Students[index] = student;
                this.Count++;
            }
        }

        /// <summary>
        /// Removes element from container
        /// </summary>
        /// <param name="student">element</param>
        public void Remove(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Students[i] == student)
                {
                    RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Finds the place where to remove
        /// </summary>
        /// <param name="index">index</param>
        public void RemoveAt(int index)
        {
            if (0 <= index && index < this.Count)
            {
                for (int i = index; i < this.Count; i++)
                {
                    this.Students[i] = this.Students[i + 1];
                }
                this.Count--;
            }
        }

        /// <summary>
        /// Makes container of elements which are in both containers
        /// </summary>
        /// <param name="other">Other container</param>
        /// <returns>New container</returns>
        public StudentsContainer Intersect(StudentsContainer other)
        {
            StudentsContainer result = new StudentsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Student current = this.Students[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }

        /// <summary>
        /// Sorts container
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Student a = this.Get(i);
                    Student b = this.Get(i + 1);
                    if (a.CompareTo(b) > 0)
                    {
                        this.Students[i] = b;
                        this.Students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
