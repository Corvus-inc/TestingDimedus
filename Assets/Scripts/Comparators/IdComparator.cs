using System.Collections.Generic;

namespace DefaultNamespace
{
    public class IdComparator : IComparer<PlankView>
    {
        public int Compare(PlankView x, PlankView y)
        {
            return int.Parse(x.Id) - int.Parse(y.Id);
        }
    }
}