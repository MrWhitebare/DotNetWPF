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

namespace SingleInstanceApplication.Forms
{
    /// <summary>
    /// DocumentList.xaml 的交互逻辑
    /// </summary>
    public partial class DocumentList : Window
    {
        public DocumentList()
        {
            InitializeComponent();

            this.lstDocuments.DisplayMemberPath = "Name";
            this.lstDocuments.ItemsSource = ((WpfApp)Application.Current).Documents;
        }
    }
}
