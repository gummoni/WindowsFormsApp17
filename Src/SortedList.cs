using System.Collections.Generic;

namespace PriorityQueue.Src
{
    /// <summary>
    /// ソート済みリスト(先頭項目変化通知付き)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortedList<T>
    {
        readonly List<T> Items = new List<T>();
        readonly IReporter<T> Reporter;
        readonly IComparer<T> Comparer;

        /// <summary>
        /// 現在の先頭アイテム
        /// </summary>
        public T Current { get; private set; }

        public SortedList(IComparer<T> comparer)
        {
            Reporter = null;
            Comparer = comparer;
        }

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
            Items.Add(item);
            Items.Sort(Comparer);
            Report();
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            Items.Remove(item);
            Report();
        }

        /// <summary>
        /// 先頭アイテム取得
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
