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
using System.Windows.Shapes;
using Drawing.Utils;
using Newtonsoft.Json;

namespace Drawing.Forms
{
    /// <summary>
    /// CefWPFChrome.xaml 的交互逻辑
    /// </summary>
    public partial class CefWPFChrome : Window
    {
        private static readonly string PublicPath= @"http://127.0.0.1:5500/";
        public CefWPFChrome()
        {
            InitializeComponent();
        }

        private void tbxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (String.IsNullOrEmpty(this.tbxAddress.Text)) return;
                this.Browser.Address = PublicPath+this.tbxAddress.Text;
                this.Browser.LifeSpanHandler = new OpenPageSelf();
                InitData(20);
            }          
        }

        private void InitData(int count)
        {
            DateTime dateTime = DateTime.Parse("2021-10-25");
            ScriptCallbackManager scriptCallbackManager = new ScriptCallbackManager();
            int i = 0;
            while (i < count)
            {
                dateTime = dateTime.AddDays(1);
                scriptCallbackManager.Name.Add(dateTime.ToString("yyyy-MM-dd"));
                Random random = new Random(Guid.NewGuid().GetHashCode());
                scriptCallbackManager.Values.Add(random.Next(0, 50));
                i++;
            }
            string json = JsonConvert.SerializeObject(scriptCallbackManager);
            string script = $"InitCodeData({json})";
            this.Browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(script);
        }      
    }
}
