using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Controls.Forms
{
    /// <summary>
    /// PopupTest.xaml 的交互逻辑
    /// </summary>
    public partial class PopupTest : Window
    {
        public PopupTest()
        {
            InitializeComponent();
        }

        private void lnkUri_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(((Hyperlink)sender).NavigateUri.ToString());
        }

        private void Run_MouseEnter(object sender, MouseEventArgs e)
        {
            popLink.IsOpen = true;
        }
    }
}
