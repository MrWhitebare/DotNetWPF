using Drawing.Utils;
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

namespace Drawing.Forms
{
    /// <summary>
    /// TextBoxWithEllipsis.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxWithEllipsis : Window
    {
        public TextBoxWithEllipsis()
        {
            InitializeComponent();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)

        {

            tbEllipsis.EllipsisPlacement = EllipsisPlacement.Left;

        }



        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)

        {
            tbEllipsis.EllipsisPlacement = EllipsisPlacement.Center;

        }



        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)

        {

            tbEllipsis.EllipsisPlacement = EllipsisPlacement.Right;

        }



        private void Button_Click(object sender, RoutedEventArgs e)

        {

            tbEllipsis.Text = tbSource.Text;

        }



        private void cbShowEllipsis_Checked(object sender, RoutedEventArgs e)

        {

            tbEllipsis.IsEllipsisEnabled = true;

        }



        private void cbShowToolTip_Checked(object sender, RoutedEventArgs e)

        {

            tbEllipsis.UseLongTextForToolTip = true;

        }



        private void cbShowEllipsis_Unchecked(object sender, RoutedEventArgs e)

        {

            tbEllipsis.IsEllipsisEnabled = false;

        }



        private void cbShowToolTip_Unchecked(object sender, RoutedEventArgs e)

        {

            tbEllipsis.UseLongTextForToolTip = false;

        }
    }
}
