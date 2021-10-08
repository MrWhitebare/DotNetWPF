using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Commands.Forms
{
    /// <summary>
    /// CustomControlWithCommand.xaml 的交互逻辑
    /// </summary>
    public partial class CustomControlWithCommand : Window
    {
        public CustomControlWithCommand()
        {
            InitializeComponent();
        }

        public static RoutedCommand FontUpdateCommand = new RoutedCommand();

        public void SliderUpdateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;

            if (source != null)
            {
                if (e.Parameter != null)
                {
                    try
                    {
                        if ((int)e.Parameter > 0 && (int)e.Parameter <= 60)
                        {
                            source.FontSize = (int)e.Parameter;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("in Command \n Parameter: " + e.Parameter);
                    }

                }
            }
        }

        public void SliderUpdateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;

            if (source != null)
            {
                if (source.IsReadOnly)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }
            }
        }
        private void OnReadOnly_Checked(object sender, RoutedEventArgs e)
        {
            if (tbxTarget != null)
            {
                tbxTarget.IsReadOnly = true;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private void OnReadOnly_Unchecked(object sender, RoutedEventArgs e)
        {
            if (tbxTarget != null)
            {
                tbxTarget.IsReadOnly = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }

    // Slider值转化为int 类型
    [ValueConversion(typeof(double), typeof(int))]
    public class FontStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string fontSize = (string)value;
            int iFont;

            try
            {
                iFont = Int32.Parse(fontSize);
                return iFont;
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(double), typeof(int))]
    public class FontDoubleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fontSize = (double)value;
            return (int)fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
