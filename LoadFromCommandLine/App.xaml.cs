using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace LoadFromCommandLine
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// 命令行 加载
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FileViewer fileViewer = new FileViewer();
            if (e.Args.Length > 0)
            {
                string file = @"C:\Users\17669\Documents\MyWork\记录\C#学习\WPF实践\WPFDesktop\LoadFromCommandLine\" + e.Args[0];
                if (File.Exists(file)){
                    fileViewer.LoadFile(file);
                }
            }

            fileViewer.Show();
        }
    }
}
