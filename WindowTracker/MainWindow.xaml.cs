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

namespace WindowTracker
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            //获取或者设置Windows
            document.Owner = this;
            document.Show();
            ((App)Application.Current).Documents.Add(document);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Document document in ((App)Application.Current).Documents)
            {
                document.SetContent("Refreshed at" + DateTime.Now.ToLongDateString() + '.');
            }
        }
    }
}
