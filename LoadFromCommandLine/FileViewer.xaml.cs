using System;
using System.Collections.Generic;
using System.IO;
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

namespace LoadFromCommandLine
{
    /// <summary>
    /// FileViewer.xaml 的交互逻辑
    /// </summary>
    public partial class FileViewer : Window
    {
        public FileViewer()
        {
            InitializeComponent();
        }

        public void LoadFile(string path)
        {
            this.Content = File.ReadAllText(path);
            this.Title = path;
        }
    }
}
