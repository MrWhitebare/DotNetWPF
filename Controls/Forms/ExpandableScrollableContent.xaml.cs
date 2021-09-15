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
    /// ExpandableScrollableContent.xaml 的交互逻辑
    /// </summary>
    public partial class ExpandableScrollableContent : Window
    {
        public ExpandableScrollableContent()
        {
            InitializeComponent();
        }

        private void btnHiddle_Click(object sender, RoutedEventArgs e)
        {
            bool isExpanded = this.expTwo.IsExpanded;
            this.btnHiddle.Content = !isExpanded ? "Hidden Expander Two" : "Show Expander Two";
            this.expTwo.IsExpanded = !isExpanded;
        }
    }
}
