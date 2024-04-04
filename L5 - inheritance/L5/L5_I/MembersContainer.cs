using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    class MembersContainer
    {
        private Member[] Members;
        public int Count { get; private set; }
        private int Capacity;
        public MembersContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.Members = new Member[capacity];
        }

        /// <summary>
        /// Ensures capacity
        /// </summary>
        /// <param name="minimumCapacity">Minimal capacity</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Member[] temp = new Member[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Members[i];
                }
                this.Capacity = minimumCapacity;
                this.Members = temp;
            }
        }

        /// <summary>
        /// Adds member to the container
        /// </summary>
        /// <param name="member">member</param>
        public void Add(Member member)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Members[this.Count++] = member;
        }

        /// <summary>
        /// Gets element by index
        /// </summary>
        /// <param name="Index">Index</param>
        /// <returns>Element</returns>
        public Member Get(int index)
        {
            return this.Members[index];
        }

        /// <summary>
        /// Checks if member exists
        /// </summary>
        /// <param name="member">member</param>
        /// <returns>True or false</returns>
        public bool Contains(Member member)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Members[i].Equals(member))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Makes a container of two containers
        /// </summary>
        /// <param name="other">Other container</param>
        /// <returns>New container</returns>
        public MembersContainer Intersect(MembersContainer other)
        {
            MembersContainer result = new MembersContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Member current = this.Members[i];
                if (!other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }

        /// <summary>
        /// Sorts container
        /// </summary>
        public void Sort(MembersComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Member a = this.Get(i);
                    Member b = this.Get(i + 1);
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.Members[i] = b;
                        this.Members[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new MembersComparator());
        }

    }
}
