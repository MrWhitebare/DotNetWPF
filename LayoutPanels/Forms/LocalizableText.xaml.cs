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

namespace LayoutPanels.Forms
{
    /// <summary>
    /// LocalizableText.xaml 的交互逻辑
    /// </summary>
    public partial class LocalizableText : Window
    {
        public LocalizableText()
        {
            InitializeComponent();
        }

        private void cbxLongText_Checked(object sender, RoutedEventArgs e)
        {
            btnPrev.Content = " <- Go to the Previous Window ";
            btnNext.Content = " Go to the Next Window -> ";
        }

        private void cbxLongText_Unchecked(object sender, RoutedEventArgs e)
        {
            btnPrev.Content = "Prev";
            btnNext.Content = "Next";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //关闭窗体
            this.Close();
        }
    }
}
