using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Utils
{
    class ToolProperty
    {
        private List<JsonItem> emergency;
        private List<JsonItem> scene;
        private List<JsonItem> manager;
        public List<JsonItem> Emergency
        {
            get
            {
                return this.emergency;
            }
            set
            {
                this.emergency = value;
            }
        }
        public List<JsonItem> Scene
        {
            get
            {
                return this.scene;
            }
            set
            {
                this.scene = value;
            }
        }
        public List<JsonItem> Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                this.manager = value;
            }
        }
    }

    public class JsonItem
    {
        private string key;
        private string title;
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    }
}
