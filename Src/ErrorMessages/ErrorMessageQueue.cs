namespace PriorityQueue.Src.ErrorMessages
{
    /// <summary>
    /// エラーメッセージキュー
    /// </summary>
    public class ErrorMessageQueue
    {
        readonly object MyLock = new object();
        readonly SortedList<ErrorMessage> Queue;
        public ErrorMessage Current => Queue.Current;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="reporter"></param>
        /// <param name="comparer"></param>
        public ErrorMessageQueue(IReporter<ErrorMessage> reporter)
        {
            Queue = new SortedList<ErrorMessage>(reporter, new ErrorMessageEqualityComparer());
        }

        /// <summary>
        /// 移譲
        /// </summary>
        /// <param name="priority">1=高い, 9=低い</param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public ErrorMessage Invoke(int priority, ErrorCode errorCode)
        {
            lock (MyLock)
            {
                var errorMessage = new ErrorMessage(priority, errorCode, Queue.Remove);
                Queue.Add(errorMessage);
                return errorMessage;
            }
        }

        /// <summary>
        /// 移譲
        /// </summary>
        /// <param name="priority">1=高い, 9=低い</param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public ErrorMessage Invoke(int priority, string message, OperationButtons buttons)
        {
            lock (MyLock)
            {
                var errorMessage = new ErrorMessage(priority, message, buttons, Queue.Remove);
                Queue.Add(errorMessage);
                return errorMessage;
            }
        }
    }
}
