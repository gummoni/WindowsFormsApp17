using System.Collections.Generic;

namespace PriorityQueue.Src.ErrorMessages
{
    /// <summary>
    /// ソート用(昇順)
    /// </summary>
    public class ErrorMessageEqualityComparer : IComparer<ErrorMessage>
    {
        public int Compare(ErrorMessage x, ErrorMessage y)
        {
            var vx = (null == x) ? 0 : x.Priority;
            var vy = (null == y) ? 0 : y.Priority;
            return vx - vy;
        }
    }
}
