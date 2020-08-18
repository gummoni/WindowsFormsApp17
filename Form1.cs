using PriorityQueue.Src;
using PriorityQueue.Src.ErrorMessages;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form, IReporter<ErrorMessage>
    {
        readonly ErrorMessageQueue Queue;

        public Form1()
        {
            InitializeComponent();
            Queue = new ErrorMessageQueue(this);
        }

        public void Report(ErrorMessage progress)
        {
            Text = (null == progress) ? "" : progress.Message;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //完了
            Queue.Current?.Complete();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //追加
            var priority = int.Parse(textBox1.Text);
            var message = textBox2.Text;
            Queue.Invoke(priority, message, OperationButtons.OK);
        }
    }

}
