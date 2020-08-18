namespace PriorityQueue.Src.ErrorMessages
{
    /// <summary>
    /// エラーメッセージキュー
    /// </summary>
    public class ErrorMessageQueue : SortedList<ErrorMessage>
    {
        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="reporter"></param>
        /// <param name="comparer"></param>
        public ErrorMessageQueue(IReporter<ErrorMessage> reporter) : base(reporter, new ErrorMessageEqualityComparer())
        {
        }

        /// <summary>
        /// 移譲
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public ErrorMessage Invoke(int priority, ErrorCode errorCode)
        {
            var errorMessage = new ErrorMessage(priority, errorCode, Remove);
            Add(errorMessage);
            return errorMessage;
        }

        /// <summary>
        /// 移譲
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public ErrorMessage Invoke(int priority, string message, OperationButtons buttons)
        {
            var errorMessage = new ErrorMessage(priority, message, buttons, Remove);
            Add(errorMessage);
            return errorMessage;
        }
    }
}
