using System;

namespace PriorityQueue.Src.ErrorMessages
{
    /// <summary>
    /// エラーオペレーション属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ErrorOperationAttribute : Attribute
    {
        public readonly string Message;
        public readonly OperationButtons Buttons;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="message"></param>
        public ErrorOperationAttribute(string message, OperationButtons buttons)
        {
            Message = message;
            Buttons = buttons;
        }
    }
}
