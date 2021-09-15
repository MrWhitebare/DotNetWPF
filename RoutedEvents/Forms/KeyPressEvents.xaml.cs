using System.Windows;
using System.Windows.Input;

namespace RoutedEvents.Forms
{
    /// <summary>
    /// KeyPressEvents.xaml 的交互逻辑
    /// </summary>
    public partial class KeyPressEvents : Window
    {
        public KeyPressEvents()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessage.Items.Clear();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if ((bool)chkIgnoreRepeat.IsChecked && e.IsRepeat) return;

            string message = //"At: " + e.Timestamp.ToString() +
                "Event: " + e.RoutedEvent + " " +
                " Key: " + e.Key;
            lstMessage.Items.Add(message);
        }

        private void txtWrapper_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string message = "Event" + e.RoutedEvent;
            lstMessage.Items.Add(message);
        }

        private void txtWrapper_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string message = //"At: " + e.Timestamp.ToString() +
                "Event: " + e.RoutedEvent + " " +
                " Text: " + e.Text;
            lstMessage.Items.Add(message);
        }
    }
}
