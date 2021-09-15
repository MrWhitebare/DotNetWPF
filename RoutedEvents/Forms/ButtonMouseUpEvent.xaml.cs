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

namespace RoutedEvents.Forms
{
    /// <summary>
    /// ButtonMouseUpEvent.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonMouseUpEvent : Window
    {
        public ButtonMouseUpEvent()
        {
            InitializeComponent();
            btnCmd.AddHandler(Button.MouseUpEvent, new RoutedEventHandler(Backdoor), true);
        }

        private void btnCmd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Button.Click event occurred. This may have been triggered with the keyboard.");
        }

        private void NeverCalled(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You didn't see this message. That would be impossible.");
        }

        private void Backdoor(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The (handled) Button.MouseUp event occurred.");
        }
    }
}
