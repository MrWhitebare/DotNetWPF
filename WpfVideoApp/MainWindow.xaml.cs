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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vlc.DotNet.Wpf;

namespace WpfVideoApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        VlcControl vlcControl=null;
        public MainWindow()
        {
            InitializeComponent();
            btnPlay.Click += BtnPlay_Click;
            InitVlCMedia();
        }

        private void InitVlCMedia()
        {
            DirectoryInfo vlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory+ "..\\..\\..\\Lib\\VlcLib", "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            Task.Factory.StartNew(() =>
            {
               videoControl.SourceProvider.CreatePlayer(vlcLibDirectory,new string[] {});
            });
        }
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
