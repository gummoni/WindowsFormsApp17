namespace PriorityQueue.Src
{
    /// <summary>
    /// 変化通知インターフェイス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReporter<T>
    {
        void Report(T progress);
    }
}
