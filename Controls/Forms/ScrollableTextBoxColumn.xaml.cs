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

namespace Controls.Forms
{
    /// <summary>
    /// ScrollableTextBoxColumn.xaml 的交互逻辑
    /// </summary>
    public partial class ScrollableTextBoxColumn : Window
    {
        public ScrollableTextBoxColumn()
        {
            InitializeComponent();
        }

        private void btnLineUp_Click(object sender, RoutedEventArgs e)
        {
            scroller.LineUp();
        }

        private void btnLineDown_Click(object sender, RoutedEventArgs e)
        {
            scroller.LineDown();
        }

        private void btnPageUp_Click(object sender, RoutedEventArgs e)
        {
            scroller.PageUp();
        }

        private void btnPageDown_Click(object sender, RoutedEventArgs e)
        {
            scroller.PageDown();
        }
    }
}
