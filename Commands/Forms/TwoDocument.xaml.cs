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
using System.IO;
using Commands.Utils;
using Newtonsoft.Json;

namespace Commands.Forms
{
    /// <summary>
    /// TwoDocument.xaml 的交互逻辑
    /// </summary>
    public partial class TwoDocument : Window
    {
        private string congfigPath;
        private Image icon;
        public TwoDocument()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            congfigPath = this.GetType().Assembly.Location;
            string path =@OperateAppConfig.GetappSettingsConfig(congfigPath,"languagePath");
            Language language=LoadedLanguage(path);
            ChangeLanguage(language);
            bool isChinese = bool.Parse(OperateAppConfig.GetappSettingsConfig(congfigPath, "isChinese"));
            InitIcon();
            if (isChinese)
                mItChina.Icon = icon;
            else
                mItEnglish.Icon = icon;
        }

        /// <summary>
        /// 读取语言包
        /// </summary>
        /// <param name="path">语言包路径</param>
        /// <returns></returns>
        private Language LoadedLanguage(string path)
        {
            Language language=null;
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                string json = Encoding.UTF8.GetString(bytes).Trim();
                fileStream.Close();
                language = JsonConvert.DeserializeObject<Language>(json);
            }
            return language;
        }

        /// <summary>
        /// 改变语言类型
        /// </summary>
        /// <param name="language">语言包实体类</param>
        private void ChangeLanguage(Language language)
        {
            if (language == null) return;
            MenuFile.Header = language.Menu.File.Title;
            MenuNew.Header = language.Menu.File.New;
            MenuOpen.Header = language.Menu.File.Open;
            MenuSave.Header = language.Menu.File.Save;
            MenuSaveAs.Header = language.Menu.File.SaveAs;
            MenuClose.Header = language.Menu.File.Close;

            MenuOption.Header = language.Menu.Options.Title;
            MenuSetting.Header = language.Menu.Options.Setting.Title;
            mItChina.Header = language.Menu.Options.Setting.zhCh;
            mItEnglish.Header = language.Menu.Options.Setting.English;

            btnNew.Content = language.ToolBar.toolBarFile.New;
            btnOpen.Content = language.ToolBar.toolBarFile.Open;
            btnSave.Content = language.ToolBar.toolBarFile.Save;

            btnCut.Content = language.ToolBar.toolBarSelf.Cut;
            btnCopy.Content = language.ToolBar.toolBarSelf.Copy;
            btnPaste.Content = language.ToolBar.toolBarSelf.Paste;
        }

        private void InitIcon()
        {
            icon = new Image();
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.Margin = new Thickness(3, 0, 0, 0);
            ImageSource imageSource = new BitmapImage(new Uri("pack://application:,,,/Commands;component/Resources/Image/Ok.png"));
            icon.Source = imageSource;
        }

        private void mItChina_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem menu = e.OriginalSource as System.Windows.Controls.MenuItem;
            if (menu.Icon == null)
            {
                mItEnglish.Icon = null;
                menu.Icon = icon;
                OperateAppConfig.UpdateappSettingsConfig(congfigPath, "languagePath", "../../Language/zh-CN.json");
                OperateAppConfig.UpdateappSettingsConfig(congfigPath, "isChinese", true.ToString());
                string path = @OperateAppConfig.GetappSettingsConfig(congfigPath, "languagePath");
                Language language = LoadedLanguage(path);
                ChangeLanguage(language);
            }
        }

        private void mItEnglish_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem menu = e.OriginalSource as System.Windows.Controls.MenuItem;
            if (menu.Icon == null)
            {
                mItChina.Icon = null;
                menu.Icon = icon;
                OperateAppConfig.UpdateappSettingsConfig(congfigPath, "languagePath", "../../Language/en.json");
                OperateAppConfig.UpdateappSettingsConfig(congfigPath, "isChinese", false.ToString());
                string path = @OperateAppConfig.GetappSettingsConfig(congfigPath, "languagePath");
                Language language = LoadedLanguage(path);
                ChangeLanguage(language);
            }
        }
    }
}
