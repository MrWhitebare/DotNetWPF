using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Utils
{
    public class ChildrensItem
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }
    }

    public class JsonItems
    {
        public bool IsChecked { get; set; }
        public string Title { get; set; }
        public List<ChildrensItem> Childrens { get; set; }
    }

    public class ToolsProperty
    {
        public JsonItems ProjectDic { get; set; }
        public JsonItems Section { get; set; }  
        public JsonItems Measure { get; set; }
        public JsonItems Range { get; set; } 
        public JsonItems Equiptment { get; set; }
        public JsonItems Monitor { get; set; }
        public JsonItems Video { get; set; }   
        public JsonItems Space { get; set; } 
        public JsonItems Schedule { get; set; }
        public JsonItems MainSpeed { get; set; }
    }
}
