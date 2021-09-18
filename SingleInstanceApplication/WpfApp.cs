using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using SingleInstanceApplication.Interface;
using SingleInstanceApplication.Forms;

namespace SingleInstanceApplication
{
    class WpfApp:System.Windows.Application
    {
        private ObservableCollection<DocumentReference> documents = 
                new ObservableCollection<DocumentReference>();

        public ObservableCollection<DocumentReference> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DocumentList documentList = new DocumentList();
            this.MainWindow = documentList;
            documentList.Show();

            if (e.Args.Length > 0)
            {
                ShowDocument(e.Args[0]);
            }
        }

        public void ShowDocument(string filename)
        {
            try
            {
                Document document = new Document();
                DocumentReference docRef = new DocumentReference(document, filename);
                document.LoadFile(docRef);
                document.Owner = this.MainWindow;
                document.Show();
                document.Activate();
                Documents.Add(docRef);
            }
            catch (Exception)
            {
                MessageBox.Show("不能加载文档！");
            }
        }
    }
}
