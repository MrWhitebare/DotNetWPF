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

namespace DataBindings.Forms
{
    /// <summary>
    /// ElementToElementBinding.xaml 的交互逻辑
    /// </summary>
    public partial class ElementToElementBinding : Window
    {
        public ElementToElementBinding()
        {
            InitializeComponent();
        }

        private void btnSetSmall_Click(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = 2;
        }

        private void btnSetNormal_Click(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = this.FontSize;
        }

        private void btnSetLarge_Click(object sender, RoutedEventArgs e)
        {
            tbkSampleText.FontSize = 30;
        }

        private void btnGetBoundObject_Click(object sender, RoutedEventArgs e)
        {
            Binding binding = BindingOperations.GetBinding(tbxBound, TextBox.TextProperty);
            MessageBox.Show("Bound" + binding.Path.Path + "to source element" + binding.ElementName);

            BindingExpression expression = BindingOperations.GetBindingExpression(tbxBound, TextBlock.TextProperty);
            MessageBox.Show("Bound" + expression.ResolvedSourcePropertyName + "with data" + ((TextBlock)expression.ResolvedSource).FontSize);
        }
    }
}
