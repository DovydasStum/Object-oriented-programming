using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    class MembersRegister
    {
        private MembersContainer AllMembers;
        public int Year { get; set; }
        public MembersRegister()
        {
            AllMembers = new MembersContainer();
        }

        public MembersRegister(MembersContainer Members)
        {
            Members = new MembersContainer();
            for (int i = 0; i < Members.Count; i++)
            {
                this.AllMembers.Add(Members.Get(i));
            }
        }

        /// <summary>
        /// Checks if element already exists
        /// </summary>
        /// <param name="member">member</param>
        /// <returns>true or false</returns>
        public bool Contains(Member member)
        {
            return AllMembers.Contains(member);
        }

        /// <summary>
        /// Adds element
        /// </summary>
        /// <param name="member">element</param>
        public void Add(Member member)
        {
            AllMembers.Add(member);
        }

        /// <summary>
        /// Counts all elements
        /// </summary>
        /// <returns>quantity</returns>
        public int Count()
        {
            return this.AllMembers.Count;
        }

        /// <summary>
        /// Returns member by its index
        /// </summary>
        /// <param name="index">index of student</param>
        /// <returns>Member by index</returns>
        public Member Get(int index)
        {
            return AllMembers.Get(index);
        }

        /// <summary>
        /// Counts members in the list
        /// </summary>
        /// <returns>Number of members</returns>
        public int MembersCount()
        {
            return this.AllMembers.Count;
        }
    }
}
