using System;
using System.Reflection;
using System.Threading;

namespace PriorityQueue.Src.ErrorMessages
{

    /// <summary>
    /// エラーメッセージ
    /// </summary>
    public class ErrorMessage
    {
        #region "プロパティ"
        internal readonly int Priority;
        public readonly string Message;
        public readonly OperationButtons Buttons;
        #endregion
        readonly ManualResetEventSlim FinishEvent = new ManualResetEventSlim(false);
        readonly Action<ErrorMessage> DoRemove;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="priprity"></param>
        /// <param name="errorCode"></param>
        public ErrorMessage(int priority, ErrorCode errorCode, Action<ErrorMessage> doRemove)
        {
            var field = typeof(ErrorCode).GetField($"{errorCode}");
            var attribute = field.GetCustomAttribute<ErrorOperationAttribute>();
            Priority = priority;
            Message = attribute.Message;
            Buttons = attribute.Buttons;
            DoRemove = doRemove;
        }

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        public ErrorMessage(int priority, string message, OperationButtons buttons, Action<ErrorMessage> doRemove)
        {
            Priority = priority;
            Message = message;
            Buttons = buttons;
            DoRemove = doRemove;
        }

        /// <summary>
        /// 完了通知
        /// </summary>
        public void OnCompleted()
        {
            FinishEvent.Set();
            DoRemove?.Invoke(this);
        }

        /// <summary>
        /// 完了待ち
        /// </summary>
        public void Wait(CancellationToken token)
        {
            FinishEvent.Wait(token);
        }
    }
}
