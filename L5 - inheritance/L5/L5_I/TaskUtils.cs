using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    class TaskUtils
    {
        /// <summary>
        /// Makes the list of oldest members
        /// </summary>
        /// <param name="members">List of members</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>List of oldest members</returns>
        public static MembersContainer OldestList(MembersRegister members,
                                                DateTime OldestDate)
        {
            MembersContainer Oldest = new MembersContainer();
            for (int i = 0; i < members.Count(); i++)
            {
                Member member = members.Get(i);
                if (member == OldestDate && !Oldest.Contains(member))
                {
                    Oldest.Add(member);
                }
            }
            return Oldest;
        }

        /// <summary>
        /// Finds the oldest member
        /// </summary>
        /// <returns>Oldest member</returns>
        public static Member FindOldestMember(MembersRegister members)
        {
            Member oldest = members.Get(0);
            for (int i = 0; i < members.Count(); i++)
            {
                if (members.Get(i).Date < oldest.Date)
                {
                    oldest = members.Get(i);
                }
            }
            return oldest;
        }

        /// <summary>
        /// Makes a list of members who have been working at least two years in a row
        /// </summary>
        /// <param name="members0">first list</param>
        /// <param name="members1">second list</param>
        /// <returns>List of members</returns>
        public static MembersContainer Work2Years(MembersRegister members0,
                                                  MembersRegister members1)
        {
            MembersContainer work2years = new MembersContainer();

            for (int i = 0; i < members0.Count(); i++)
            {
                Member member0 = members0.Get(i);
                if (member0 is Graduate)
                {
                    for (int j = 0; j < members1.Count(); j++)
                    {
                        Member member1 = members1.Get(j);
                        if (member1 is Graduate && member1.Equals(member0) &&
                            !work2years.Contains(member1))
                        {
                            work2years.Add(member1);
                        }
                    }
                }
            }
            return work2years;
        }

        /// <summary>
        /// Makes one list of two lists
        /// </summary>
        /// <param name="first">first list</param>
        /// <param name="second">second list</param>
        /// <returns>new list</returns>
        public static MembersContainer ListOfBoth(MembersContainer first, 
                                                  MembersContainer second)
        {
            MembersContainer workingMembers = new MembersContainer();
            for (int i = 0; i < first.Count; i++)
            {
                if (!workingMembers.Contains(first.Get(i)))
                {
                    workingMembers.Add(first.Get(i));
                }
                for (int j = 0; j < second.Count; j++)
                {
                    if (!workingMembers.Contains(second.Get(j)))
                    {
                        workingMembers.Add(second.Get(j));
                    }
                }
            }
            return workingMembers;
        }

        /// <summary>
        /// Makes a list of workers in Atea
        /// </summary>
        /// <param name="members">list of members</param>
        /// <param name="workplace">name of workplace</param>
        /// <returns>list</returns>
        public static MembersContainer Atea (MembersRegister members, string workplace)
        {
            MembersContainer workers = new MembersContainer();
            for (int i = 0; i < members.Count(); i++)
            {
                Member member = members.Get(i);
                if (member is Graduate)
                {
                    Graduate g = member as Graduate;
                    if (WorkPlace(g, workplace))
                    {
                        workers.Add(member);
                    }
                }
            }        
            return workers;
        }

        /// <summary>
        /// Checks if member is working in particular workplace
        /// </summary>
        /// <param name="member">member</param>
        /// <param name="workplace">workplace</param>
        /// <returns>true or false</returns>
        private static bool WorkPlace (Graduate member, string workplace)
        {
            if (member.WorkPlace == workplace)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Makes one list of two
        /// </summary>
        /// <param name="members1">first list</param>
        /// <param name="members2">second list</param>
        /// <returns>new list</returns>
        public static MembersContainer ListOfMembers (MembersRegister members1,
                                                      MembersRegister members2)
        {
            MembersContainer list = new MembersContainer();
            for (int i = 0; i < members1.Count(); i++)
            {
                Member member1 = members1.Get(i);
                if (!list.Contains(member1))
                {
                    list.Add(member1);
                }
                for (int j = 0; j < members2.Count(); j++)
                {
                    Member member2 = members2.Get(j);
                    if (!list.Contains(member2))
                    {
                        list.Add(member2);
                    }
                }
            }
            return list;
        }

    }
}
