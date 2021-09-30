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
using Newtonsoft.Json;
using System.IO;
using Commands.Utils;

namespace Commands.Forms
{
    /// <summary>
    /// JSONRender.xaml 的交互逻辑
    /// </summary>
    public partial class JSONRender : Window
    {
        private string JSON;
        private ToolProperty toolProperty;
        public JSONRender()
        {
            InitializeComponent();
        }

        private void btnGetJson_Click(object sender, RoutedEventArgs e)
        {
            string path = @"../../config/config.json";
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                //定义存放文件信息的字节数组
                byte[] bytes = new byte[fileStream.Length];
                //读取文件
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                string json = Encoding.UTF8.GetString(bytes);
                this.JSON = json;
            }     
        }

        private void btnParseJson_Click(object sender, RoutedEventArgs e)
        {
            if (toolProperty == null)
            {
                toolProperty = JsonConvert.DeserializeObject<ToolProperty>(JSON);
            }
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            this.splBtnWrapper.Children.Clear();
            foreach (JsonItem item in toolProperty.Manager)
            {
                Button button = new Button();
                button.Name = item.Key;
                button.Content = item.Title;
                this.splBtnWrapper.Children.Add(button);
            }
        }

        private void btnScene_Click(object sender, RoutedEventArgs e)
        {
            this.splBtnWrapper.Children.Clear();
            foreach (JsonItem item in toolProperty.Scene)
            {
                Button button = new Button();
                button.Name = item.Key;
                button.Content = item.Title;
                this.splBtnWrapper.Children.Add(button);
            }
        }

        private void btnEmergency_Click(object sender, RoutedEventArgs e)
        {
            this.splBtnWrapper.Children.Clear();
            foreach (JsonItem item in toolProperty.Emergency)
            {
                Button button = new Button();
                button.Name = item.Key;
                button.Content = item.Title;
                button.Margin = new Thickness(5);
                this.splBtnWrapper.Children.Add(button);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.splBtnWrapper.Children.Clear();
        }
    }
}
