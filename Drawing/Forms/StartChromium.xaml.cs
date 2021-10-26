using CefSharp;
using CefSharp.Wpf;
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
using Drawing.Utils;
using System.IO;

namespace Drawing.Forms
{
    /// <summary>
    /// StartChromium.xaml 的交互逻辑
    /// </summary>
    public partial class StartChromium : Window
    {
        private ChromiumWebBrowser chromiumWebBrowser;
        private readonly string FilePath = @"../../../Resources/Static/index.html";
        public StartChromium()
        {
            InitializeComponent();
            chromiumWebBrowser = new ChromiumWebBrowser();
            chromiumWebBrowser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;

            chromiumWebBrowser.JavascriptObjectRepository.Register("dotNetMessage", new JavascriptCallCSharp(),
                isAsync: true, options: BindingOptions.DefaultBinder);

            chromiumWebBrowser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender, e) =>
            {
                var name = e.ObjectName;
                System.Diagnostics.Debug.WriteLine($"对象{e.ObjectName}绑定成功！");
            };

            chromiumWebBrowser.IsBrowserInitializedChanged += ChromiumWebBrowser_IsBrowserInitializedChanged;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

            this.ChromeWrapper.Children.Add(chromiumWebBrowser);
        }

        private void ChromiumWebBrowser_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (chromiumWebBrowser.IsBrowserInitialized)
            {
                if (!File.Exists(FilePath)) return;
                //chromiumWebBrowser.LoadHtml(File.ReadAllText(FilePath));
                chromiumWebBrowser.Address = @"http://127.0.0.1:5500/index.html";
            }
        }
    }
}
