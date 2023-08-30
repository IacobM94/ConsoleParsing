using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParsing
{
    internal class AgeComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((Contact)x).age, ((Contact)y).age);
        }
    }
}
