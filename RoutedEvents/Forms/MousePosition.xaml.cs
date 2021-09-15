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
    /// MousePosition.xaml 的交互逻辑
    /// </summary>
    public partial class MousePosition : Window
    {
        public MousePosition()
        {
            InitializeComponent();
        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);
            tbxInfo.Text = String.Format("You are at ({0},{1}) in window coordinates",
                point.X,point.Y);
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            this.AddHandler(Mouse.LostMouseCaptureEvent, new RoutedEventHandler(LostCapture));
            Mouse.Capture(rect);
            btnCapture.Content= "[ Mouse is now captured ... ]";
        }

        private void LostCapture(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lost capture");
            btnCapture.Content = "Capture the Mouse";
        }
    }
}
