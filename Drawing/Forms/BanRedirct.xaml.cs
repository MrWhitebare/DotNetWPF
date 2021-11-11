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
using CefSharp;
using CefSharp.Wpf;

namespace Drawing.Forms
{
    /// <summary>
    /// BanRedirct.xaml 的交互逻辑
    /// </summary>
    public partial class BanRedirct : Window
    {
        private ChromiumWebBrowser chromium;
        private readonly string Url = "http://192.168.2.215:5500/index.html";
        public BanRedirct()
        {
            InitializeComponent();
            chromium = new ChromiumWebBrowser();
            chromium.IsBrowserInitializedChanged += Chromium_IsBrowserInitializedChanged;
            this.Wrapper.Children.Add(chromium);          
        }

        private async Task<bool> IsLoading(ChromiumWebBrowser chromium)
        {
            while (chromium.GetBrowser().IsLoading)
                await Task.Delay(500);
            return false;
        }

        private void Chromium_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (chromium.IsBrowserInitialized)
            {
                chromium.Address = @Url;
                Task.Run(async ()=>
                {
                    await IsLoading(this.chromium);
                    const string script = @"
                    function stop(event) {
                        event = event || window.event;
                        if (event.preventDefault) {
                            event.preventDefault();
                        } else {
                            event.returnValue = false;
                        }
                    };
                    let a = document.getElementsByTagName('a');
                    for (var i = 0; i < a.length; i++)
                    {
                        a[i].onclick = function(e) 
                        {
                            stop(e);
                            return false;
                        }
                    }";
                    this.chromium.ExecuteScriptAsync(script);
                });
            }
        }
    }
}
