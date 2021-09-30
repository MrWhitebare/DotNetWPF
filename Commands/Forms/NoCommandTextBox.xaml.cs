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

namespace Commands.Forms
{
    /// <summary>
    /// NoCommandTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class NoCommandTextBox : Window
    {
        public NoCommandTextBox()
        {
            InitializeComponent();

            //禁用剪切功能
            txtWrapper.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, null, SuppressCommand));

            //禁用复制功能
            txtWrapper.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.C, ModifierKeys.Control));

            //禁用粘贴功能
            txtWrapper.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.V, ModifierKeys.Control));
        }

        private void SuppressCommand(object sender,CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            e.Handled = true;
        }
    }
}
