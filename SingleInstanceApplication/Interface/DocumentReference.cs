using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleInstanceApplication.Forms;

namespace SingleInstanceApplication.Interface
{
    public class DocumentReference
    {
        private Document document;
        public Document Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DocumentReference(Document document,string name)
        {
            this.Document = document;
            this.Name = name;
        }
    }
}
