using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFDesktop.Utils;

namespace WPFDesktop.Forms
{
    /// <summary>
    /// EightBallBrowserPage.xaml 的交互逻辑
    /// </summary>
    public partial class EightBallBrowserPage : Window
    {
        public EightBallBrowserPage()
        {
            InitializeComponent();
        }

        private void tbxAnswer_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            AnswerGenerator answerGenerator = new AnswerGenerator();
            txtAnswer.Text = answerGenerator.GetRandomAnswer(txtQuestion.Text);
            this.Cursor = null;
        }
    }
}
