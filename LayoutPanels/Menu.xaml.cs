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
using System.Windows.Shapes;

namespace LayoutPanels
{
    /// <summary>
    /// Menu.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void splWrapper_Click(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)e.OriginalSource;

            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window window = (Window)assembly.CreateInstance(string.Format("{0}.Forms.{1}",type.Namespace,cmd.Content));
            try
            {
                window.ShowDialog();
            }catch(InvalidOperationException exception)
            {
                string strTitle = string.Format("发生异常：{0}；请联系Developer: MrWhitebare",exception.Message);
                MessageBox.Show(strTitle,"异常",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
