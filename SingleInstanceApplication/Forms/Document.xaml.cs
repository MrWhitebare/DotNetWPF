using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using SingleInstanceApplication.Interface;

namespace SingleInstanceApplication.Forms
{
    /// <summary>
    /// Document.xaml 的交互逻辑
    /// </summary>
    public partial class Document : Window
    {
        private DocumentReference docRef;

        public Document()
        {
            InitializeComponent();
        }

        public void LoadFile(DocumentReference docRef)
        {
            this.docRef = docRef;
            this.Content = File.ReadAllText(docRef.Name);
            this.Title =docRef.Name;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            //((WpfApp)Application.Current)
        }
    }
}
