using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Markup;

namespace NonCompiledXaml
{
    /// <summary>
    /// WindowRender.xaml 的交互逻辑
    /// </summary>
    public partial class WindowRender : Window
    {
        public WindowRender()
        {
            InitializeComponent();
        }

        private void InitializeComponent(string xamlFile)
        {
            //初始化窗体
            this.Width = this.Height = 285;
            this.Left = this.Top = 100;
            this.Title = "自动加载 XAML文件";

            DependencyObject rootElement;

            using (FileStream fs = new FileStream(xamlFile, FileMode.Open))
            {
                rootElement = (DependencyObject) XamlReader.Load(fs);
            }

            this.Content = rootElement;
            FrameworkElement frameworkElement = (FrameworkElement)rootElement;
            btnChange = (Button)frameworkElement.FindName("btnChange");

            btnChange.Click += new RoutedEventHandler(BtnChange_Click);

        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            btnChange.Content = "Thank you.";
        }
    }
}
