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

namespace Controls.Forms
{
    /// <summary>
    /// CheckBoxList.xaml 的交互逻辑
    /// </summary>
    public partial class CheckBoxList : Window
    {
        public CheckBoxList()
        {
            InitializeComponent();
        }

        private void lstCheckBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is CheckBox)
            {
                lstCheckBox.SelectedItem = e.OriginalSource;
            }
            if (lstCheckBox.SelectedItem == null) return;
            tbkSelection.Text = String.Format("You chose item at position {0}.\r\nChecked state is {1}.",
                lstCheckBox.SelectedIndex,((CheckBox)lstCheckBox.SelectedItem).IsChecked);
        }

        private void btnCheckAll_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (CheckBox item in this.lstCheckBox.Items)
            {
                if (item.IsChecked==true)
                {
                    stringBuilder.Append(item.Content + " is Checked.");
                    stringBuilder.Append("\r\n");
                }
            }
            tbkSelection.Text = stringBuilder.ToString();
        }
    }
}
