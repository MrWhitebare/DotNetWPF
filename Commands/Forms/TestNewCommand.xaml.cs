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
    /// TestNewCommand.xaml 的交互逻辑
    /// </summary>
    public partial class TestNewCommand : Window
    {
        public TestNewCommand()
        {
            InitializeComponent();
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command triggered by" + e.Source.ToString());
        }

        private void OepnCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open command triggered by" + e.Source.ToString());
        }

        private void btnDoCommand_Click(object sender, RoutedEventArgs e)
        {
            this.CommandBindings[0].Command.Execute(null);
            this.CommandBindings[1].Command.Execute(null);
        }
    }
}
