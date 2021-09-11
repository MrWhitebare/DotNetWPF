using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UtilityWPFUI.Dialog
{
    /// <summary>
    /// 九宫格背景Border
    /// </summary>
    public class CommonBorder : Border
    {
        /// <summary>
        /// 标题高度
        /// </summary>
        public static readonly DependencyProperty TitleHeightProperty = DependencyProperty.Register("TitleHeight", typeof(double), typeof(CommonBorder), new FrameworkPropertyMetadata(new double(), FrameworkPropertyMetadataOptions.AffectsRender));
        public double TitleHeight
        {
            get { return (double)base.GetValue(TitleHeightProperty); }
            set { base.SetValue(TitleHeightProperty, value); }
        }

        /// <summary>
        /// 图片原始尺寸
        /// </summary>
        public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.Register("ImageSize", typeof(Size), typeof(CommonBorder), new FrameworkPropertyMetadata(new Size(), FrameworkPropertyMetadataOptions.AffectsRender));
        public Size ImageSize
        {
            get { return (Size)base.GetValue(ImageSizeProperty); }
            set { base.SetValue(ImageSizeProperty, value); }
        }

        /// <summary>
        /// 图片源
        /// </summary>
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(CommonBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 图片源
        /// </summary>
        public ImageSource Image
        {
            get { return (ImageSource)base.GetValue(ImageProperty); }
            set { base.SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// 图片四个边距
        /// </summary>
        public static readonly DependencyProperty ImageMarginProperty = DependencyProperty.Register("ImageMargin", typeof(Thickness), typeof(CommonBorder), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 图片四个边距
        /// </summary>
        public Thickness ImageMargin
        {
            get { return (Thickness)GetValue(ImageMarginProperty); }
            set { SetValue(ImageMarginProperty, value); }
        }

        /// <summary>
        /// 图片原始尺寸
        /// </summary>
        public static readonly DependencyProperty TitleImageSizeProperty = DependencyProperty.Register("TitleImageSize", typeof(Size), typeof(CommonBorder), new FrameworkPropertyMetadata(new Size(), FrameworkPropertyMetadataOptions.AffectsRender));
        public Size TitleImageSize
        {
            get { return (Size)base.GetValue(TitleImageSizeProperty); }
            set { base.SetValue(TitleImageSizeProperty, value); }
        }

        /// <summary>
        /// 图片源
        /// </summary>
        public static readonly DependencyProperty TitleImageProperty = DependencyProperty.Register("TitleImage", typeof(ImageSource), typeof(CommonBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 图片源
        /// </summary>
        public ImageSource TitleImage
        {
            get { return (ImageSource)base.GetValue(TitleImageProperty); }
            set { base.SetValue(TitleImageProperty, value); }
        }

        /// <summary>
        /// 图片四个边距
        /// </summary>
        public static readonly DependencyProperty TitleImageMarginProperty = DependencyProperty.Register("TitleImageMargin", typeof(Thickness), typeof(CommonBorder), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 图片四个边距
        /// </summary>
        public Thickness TitleImageMargin
        {
            get { return (Thickness)GetValue(TitleImageMarginProperty); }
            set { SetValue(TitleImageMarginProperty, value); }
        }

        /// <summary>
        /// 图片透明度
        /// </summary>
        public static readonly DependencyProperty ImageOpacityProperty = DependencyProperty.Register("ImageOpacity", typeof(double), typeof(CommonBorder), new FrameworkPropertyMetadata(1D, FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 图片透明度
        /// </summary>
        public double ImageOpacity
        {
            get { return (double)GetValue(ImageOpacityProperty); }
            set { SetValue(ImageOpacityProperty, value); }
        }

        /// <summary>
        /// 边框四个边距
        /// </summary>
        public static readonly DependencyProperty BorderMarginProperty = DependencyProperty.Register("BorderMargin", typeof(Thickness), typeof(CommonBorder), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// 边框四个边距
        /// </summary>
        public Thickness BorderMargin
        {
            get { return (Thickness)GetValue(BorderMarginProperty); }
            set { SetValue(BorderMarginProperty, value); }
        }

        /// <summary>
        /// 是否九宫格方式
        /// </summary>
        private bool IsNineGrid
        {
            get { return !ImageMargin.Equals(new Thickness()); }
        }

        protected override void OnRender(DrawingContext dc)
        {
            DrawImage(dc, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
        }

        private void DrawImage(DrawingContext dc, Rect rect)
        {
            ImageSource source = Image;

            if (source != null)
            {
                double opacity = ImageOpacity;

                if (IsNineGrid)
                {
                    Thickness margin = Clamp(ImageMargin, new Size(source.Width, source.Height), rect.Size);

                    double[] xGuidelines = { 0, margin.Left, rect.Width - margin.Right, rect.Width };
                    double[] yGuidelines = { 0, margin.Top, rect.Height - margin.Bottom, rect.Height };
                    GuidelineSet guidelineSet = new GuidelineSet(xGuidelines, yGuidelines);
                    guidelineSet.Freeze();

                    dc.PushGuidelineSet(guidelineSet);

                    double[] x = { rect.Left, rect.Left + margin.Left, rect.Right - margin.Right, rect.Right };
                    double[] y = { rect.Top, rect.Top + margin.Top, rect.Bottom - margin.Bottom, rect.Bottom };
                    double[] lx = { 0, margin.Left, ImageSize.Width - margin.Right, ImageSize.Width };
                    double[] ly = { 0, margin.Top, ImageSize.Height - margin.Bottom, ImageSize.Height };
                    for (int i = 0; i < 3; ++i)
                    {
                        for (int j = 0; j < 3; ++j)
                        {
                            int tlx = (int)lx[j];
                            int tly = (int)ly[i];
                            int tlw = (int)(lx[j + 1] - lx[j]);
                            int tlh = (int)(ly[i + 1] - ly[i]);
                            int tx = (int)x[j];
                            int ty = (int)y[i];
                            int tw = (int)Math.Max(0D, (x[j + 1] - x[j]));
                            int th = (int)Math.Max(0D, (y[i + 1] - y[i]));

                            dc.DrawRectangle(new ImageBrush(new CroppedBitmap((BitmapSource)source, new Int32Rect(tlx, tly, tlw, tlh))), null, new Rect(tx, ty, tw, th));
                        }
                    }

                    dc.Pop();
                }
                else
                {
                    ImageBrush brush = new ImageBrush(source);
                    brush.Opacity = opacity;

                    dc.DrawRectangle(brush, null, rect);
                }

                //绘制顶部图片
                ImageSource sourceTitleImage = TitleImage;
                if (sourceTitleImage != null)
                {
                    Thickness margin = Clamp(TitleImageMargin, new Size(sourceTitleImage.Width, sourceTitleImage.Height), rect.Size);

                    int tlx = (int)((TitleImageSize.Width - rect.Width + margin.Left + margin.Right) / 2.0);
                    int tly = 0;
                    int tlw = (int)rect.Width;
                    int tlh = (int)TitleImageSize.Height;
                    int tx = (int)margin.Left;
                    int ty = (int)margin.Top;
                    int tw = (int)(rect.Width - margin.Left - margin.Right);
                    int th = (int)TitleImageSize.Height;

                    dc.DrawRectangle(new ImageBrush(new CroppedBitmap((BitmapSource)sourceTitleImage, new Int32Rect(tlx, tly, tlw, tlh))), null, new Rect(tx, ty, tw, th));
                }

                double borderWidth = rect.Width - BorderMargin.Left - BorderMargin.Right;
                double borderHeight = rect.Height - BorderMargin.Top - BorderMargin.Bottom;
                if (borderWidth > 0 && borderHeight > 0)
                {
                    Pen pen = new Pen(new SolidColorBrush(Color.FromArgb(255, 40, 190, 200)), 1.0);
                    dc.DrawRectangle(null, pen, new Rect(BorderMargin.Left, BorderMargin.Top, borderWidth, borderHeight));
                }
            }
        }

        private static Thickness Clamp(Thickness margin, Size firstMax, Size secondMax)
        {
            double left = Clamp(margin.Left, firstMax.Width, secondMax.Width);
            double top = Clamp(margin.Top, firstMax.Height, secondMax.Height);
            double right = Clamp(margin.Right, firstMax.Width - left, secondMax.Width - left);
            double bottom = Clamp(margin.Bottom, firstMax.Height - top, secondMax.Height - top);

            return new Thickness(left, top, right, bottom);
        }

        private static double Clamp(double value, double firstMax, double secondMax)
        {
            return Math.Max(0, Math.Min(Math.Min(value, firstMax), secondMax));
        }
    }
}
