﻿using System;
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

namespace LayoutPanels.Forms
{
    /// <summary>
    /// SimpleInkCanvas.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleInkCanvas : Window
    {
        public SimpleInkCanvas()
        {
            InitializeComponent();

            foreach (InkCanvasEditingMode mode in Enum.GetValues(typeof(InkCanvasEditingMode)))
            {
                cbxEditingMode.Items.Add(mode);
                cbxEditingMode.SelectedItem = inkCanvas.EditingMode;
            }
        }
    }
}
