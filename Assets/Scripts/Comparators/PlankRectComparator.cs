using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PlankRectComparator : IComparer<PlankView>
    {
        public int Compare(PlankView x, PlankView y)
        {
            var rectX = x.GetRectTransform();
            var rectY = y.GetRectTransform();
            
            if (rectX.anchoredPosition.y < rectY.anchoredPosition.y)
                return 1;
            if (rectX.anchoredPosition.y > rectY.anchoredPosition.y)
                return -1;

            return 0;
        }
    }
}