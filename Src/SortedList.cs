using System.Collections.Generic;

namespace PriorityQueue.Src
{
    /// <summary>
    /// ソート済みリスト
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SortedList<T>
    {
        readonly object MyLock = new object();
        readonly List<T> Items = new List<T>();
        readonly IReporter<T> Reporter;
        readonly IComparer<T> Comparer;
        public T Current { get; private set; }

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="comparer"></param>
        public SortedList(IReporter<T> reporter, IComparer<T> comparer)
        {
            Reporter = reporter;
            Comparer = comparer;
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            lock (MyLock)
            {
                Items.Add(item);
                Items.Sort(Comparer);
                
                Report();
            }
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            lock (MyLock)
            {
                Items.Remove(item);
                Report();
            }
        }

        /// <summary>
        /// 先頭
        /// </summary>
        /// <returns></returns>
        T Peek() => (0 < Items.Count) ? Items[0] : default;

        /// <summary>
        /// 変化通知
        /// </summary>
        void Report()
        {
            var top = Peek();
            if (true != Current?.Equals(top))
            {
                Current = top;
                Reporter?.Report(top);
            }
        }
    }
}
