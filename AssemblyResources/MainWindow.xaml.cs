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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssemblyResources
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //this.imgWrapper.Source = new BitmapImage(new Uri("./Resource/Images/winter.jpg",UriKind.Relative));
            this.imgWrapper.Source = new BitmapImage(new Uri("pack://application:,,,/Resource/Images/winter.jpg"));
            this.soundWrapper.Stop();
            this.soundWrapper.Play();
        }
    }
}
