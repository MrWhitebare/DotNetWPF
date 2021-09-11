using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UtilityWPFUI.Dialog
{
    /// <summary>
    /// FrmMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class FrmMessageBox : Window
    {
        public enum BoxIcon
        {
            //
            // 摘要:
            //     消息框未包含符号。
            None = 0,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个红色背景圆圈，圆圈中为白色 X 符号。
            Hand = 16,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个红色背景圆圈，圆圈中为白色 X 符号。
            Stop = 16,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个红色背景圆圈，圆圈中为白色 X 符号。
            Error = 16,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个圆圈，圆圈中为问号。 不再建议使用问号消息图标，因为这种图标无法清楚地表示特定类型的消息，并且作为问题的消息表述可应用于任何消息类型。
            //     此外，用户可能会将问号符号与帮助信息符合混淆。 因此，请不要在消息框中使用问号符号。 系统继续支持它包含的内容，只为满足反向兼容性。
            Question = 32,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个黄色背景三角形，三角形中为感叹号。
            Exclamation = 48,
            //
            // 摘要:
            //     消息框包含一个符号，该符号包含一个黄色背景三角形，三角形中为感叹号。
            Warning = 48,
            //
            // 摘要:
            //     消息框包含一个符号，该符号在圆圈中包含小写字母 i。
            Asterisk = 64,
            //
            // 摘要:
            //     消息框包含一个符号，该符号在圆圈中包含小写字母 i。
            Information = 64
        }

        public event MouseButtonEventHandler BtnOkMouseUp = null;
        public event MouseButtonEventHandler BtnCancelMouseUp = null;

        public FrmMessageBox()
        {
            InitializeComponent();

      /*      this.SizeChanged += FrmMessageBox_SizeChanged;
            this.btnOk.MouseUp += BtnOk_MouseUp;
            this.btnCancel.MouseUp += BtnCancel_MouseUp;
            this.btnClose.MouseUp += BtnClose_MouseUp;*/
        }

        private void BtnClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (BtnCancelMouseUp != null)
            {
                BtnCancelMouseUp(sender, e);
            }
        }

        private void BtnOk_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (BtnOkMouseUp != null)
            {
                BtnOkMouseUp(sender, e);
            }
        }

        public void Init() 
        {
            CommonBorder border = this.mainBorder;
            border.ImageMargin = new Thickness(14, 26, 16, 25);
            border.ImageSize = new Size(262, 128);
            border.Image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resource/Widget/posmessage_bg.png", UriKind.Absolute));
            border.TitleImageMargin = new Thickness(3, 13, 6, 0);
            border.TitleImageSize = new Size(937, 91);
            border.TitleImage = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resource/Widget/window_bg_top.png", UriKind.Absolute));
            border.BorderMargin = new Thickness(9, border.TitleImageMargin.Top + border.TitleHeight, 12, 22);
            border.Padding = new Thickness(0);
            border.Margin = new Thickness(0);
            border.VerticalAlignment = VerticalAlignment.Stretch;
            border.HorizontalAlignment = HorizontalAlignment.Stretch;

            //this.mainGrid.Margin = new Thickness(border.BorderMargin.Left, border.BorderMargin.Top - border.TitleHeight, border.BorderMargin.Right, border.BorderMargin.Bottom);
        }
    }
}
