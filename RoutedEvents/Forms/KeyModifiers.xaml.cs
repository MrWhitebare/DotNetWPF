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
    /// KeyModifiers.xaml 的交互逻辑
    /// </summary>
    public partial class KeyModifiers : Window
    {
        public KeyModifiers()
        {
            InitializeComponent();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {

            lblInfo.Text = "Modifiers: " +
                e.KeyboardDevice.Modifiers.ToString();

            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                lblInfo.Text += "\r\nYou held the Control key.";
            }
        }

        private void btnCheckShift_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                lblInfo.Text = "The left Shift is held down.";
            }
            else
            {
                lblInfo.Text = "The left Shift is not held down.";
            }
        }
    }
}
