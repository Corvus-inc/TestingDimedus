using System.Collections.Generic;

namespace DefaultNamespace
{
    public class NameComparator : IComparer<PlankView>
    {
        public int Compare(PlankView x, PlankView y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}