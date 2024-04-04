using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    class ComparatorBySurnameAndName : MembersComparator
    {
        public override int Compare(Member a, Member b)
        {
            if (a.Surname.CompareTo(b.Surname) == 0)
            {
                return a.Name.CompareTo(b.Name);
            }
            return a.Surname.CompareTo(b.Surname);
        }
    }
}
