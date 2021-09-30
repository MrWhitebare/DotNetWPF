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
using Commands.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Commands.Forms
{
    /// <summary>
    /// JsonRenderPlus.xaml 的交互逻辑
    /// </summary>
    public partial class JsonRenderPlus : Window
    {

        private ToolsProperty toolsProperty;
        private ResourceDictionary resourceDictionary;
        private Dictionary<string, JsonItems> keyValues;
        
        public JsonRenderPlus()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("pack://application:,,,/Commands;component/Resources/ButtonStyle.xaml");
            keyValues = new Dictionary<string, JsonItems>();
            string path = @"../../config/format.json";
            if (File.Exists(path))
            {
                FileStream fileStream=new FileStream(path,FileMode.Open,FileAccess.Read);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                string json = Encoding.UTF8.GetString(bytes).Trim();
                fileStream.Close();
                toolsProperty = JsonConvert.DeserializeObject<ToolsProperty>(json);
            }
            renderBtn();
        }
        private void renderBtn()
        {
            this.splBtnWrapper.Children.Clear();
            string[,] titles =
            {
                { "Equiptment",toolsProperty.Equiptment.Title },
                { "MainSpeed",toolsProperty.MainSpeed.Title },
                { "Measure",toolsProperty.Measure.Title },
                { "Monitor",toolsProperty.Monitor.Title },
                { "ProjectDic",toolsProperty.ProjectDic.Title},
                {"Range",toolsProperty.Range.Title},
                {"Schedule",toolsProperty.Schedule.Title},
                {"Section",toolsProperty.Section.Title},
                {"Space",toolsProperty.Space.Title},
                {"Video",toolsProperty.Video.Title}
            };
            JsonItems[] jsons =
            {
                toolsProperty.Equiptment,
                toolsProperty.MainSpeed,
                toolsProperty.Measure,
                toolsProperty.Monitor,
                toolsProperty.ProjectDic,
                toolsProperty.Range,
                toolsProperty.Schedule,
                toolsProperty.Section,
                toolsProperty.Space,
                toolsProperty.Video
            };
            int index = 0;
            while (index < titles.GetLength(0))
            {
                Button button = new Button();
                button.Name = titles[index, 0];
                button.Content = titles[index, 1];
                button.Resources = resourceDictionary;
                button.Tag = titles[index, 0];
                this.splBtnWrapper.Children.Add(button);
                keyValues.Add(titles[index, 0], jsons[index]);
                index++;
            }
        }

        private void splBtnWrapper_Click(object sender, RoutedEventArgs e)
        {
            this.splSubTools.Children.Clear();
            Button button = e.OriginalSource as Button;
            string title = button.Tag.ToString();
            if (keyValues.ContainsKey(title)&&!keyValues[title].IsChecked)
            {
                foreach (ChildrensItem item in keyValues[title].Childrens)
                {
                    Button btn = new Button();
                    btn.Name = item.Key;
                    btn.Content = item.Title;
                    btn.Tag = item.Form;
                    btn.Resources = resourceDictionary;
                    this.splSubTools.Children.Add(btn);
                }
                keyValues[title].IsChecked = true;
            }
            else
            {
                this.splSubTools.Children.Clear();
                keyValues[title].IsChecked = false;
            }
            foreach (string key in keyValues.Keys)
            {
                if (title != key)
                {
                    keyValues[key].IsChecked = false;
                }
            }
        }

        private void splSubTools_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;
            string format = String.Format("王俊你好！我是{0}", button.Tag);
            MessageBox.Show(format);
        }
    }
}
