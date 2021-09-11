using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace RoutedEvents
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
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //获取原始点击源
            Button button = (Button)e.OriginalSource;

            Type type = this.GetType();
            Assembly assembly = type.Assembly;

            Window window = (Window)assembly.CreateInstance(string.Format("{0}.Forms.{1}",type.Namespace,button.Content));
            window.ShowDialog();
        }
    }
}
