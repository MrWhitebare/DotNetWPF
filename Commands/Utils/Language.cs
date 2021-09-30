using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Utils
{
    public interface IFile
    {
        string New { get; set; }
        string Open { get; set; }
        string Save { get; set; }
    }

    public class FileItem : IFile
    {
        public string Title { get; set; }
        public string New { get; set; }
        public string Open { get; set; }
        public string Save { get; set; }
        public string SaveAs { get; set; }
        public string Close { get; set; }
    }

    public class toolBarFileItem : IFile
    {
        public string New { get; set; }
        public string Open { get; set; }
        public string Save { get; set; }
    }

    public class toolBarSelfItem
    {
        public string Cut { get; set; }
        public string Copy { get; set; }
        public string Paste { get; set; }
    }

    public class Settings
    {
        public string Title { get; set; }
        public string zhCh { get; set; }
        public string English { get; set; }
    }

    public class OptionItem
    {
        public string Title { get; set; }
        public Settings Setting { set; get; }
    }

    public class MenuItem
    {
        public FileItem File { get; set; }
        public OptionItem Options { get; set; }
    }

    public class ToolBarItem
    {
        public toolBarFileItem toolBarFile { get; set; }
        public toolBarSelfItem toolBarSelf { get; set; }
    }

    public class Language
    {
        public MenuItem Menu { get; set; }
        public ToolBarItem ToolBar { get; set; }
    }
}
