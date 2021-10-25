using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Drawing.Utils
{
    public enum EllipsisPlacement
    {
        /// <summary>
        /// 左侧
        /// </summary>
        Left,
        /// <summary>
        /// 中间
        /// </summary>
        Center,
        /// <summary>
        /// 右侧
        /// </summary>
        Right
    }
    public class tbxWithEllipsisUtils:TextBox
    {
        /// <summary>
        /// 原始文本的合适长度
        /// </summary>
        private int _lastFitLen = 0;

        /// <summary>
        /// 原始文本的最后长度
        /// </summary>
        private int _lastLongLen;

        /// <summary>
        /// 当前分配给原始文本的长度
        /// </summary>
        private int _curLen;

        /// <summary>
        /// 记录是否变化
        /// </summary>
        private bool _externalChange = true;

        /// <summary>
        /// 获取焦点时禁用省略号
        /// </summary>
        private bool _internalEnabled = true;

        private string _longText = "";

        private bool _externalEnabled = true;

        private bool _useLongTextForToolTip;

        private EllipsisPlacement _placement;

        /// <summary>
        /// 原始内容，设置此项和设置Text属性具有相同的效果
        /// </summary>
        public string LongText
        {
            get { return _longText; }
            set
            {
                _longText = value ?? "";
                PrepareForLayout();
            }
        }

        /// <summary>
        /// 省略号位置
        /// </summary>
        public EllipsisPlacement EllipsisPlacement
        {
            get
            {
                return _placement;
            }
            set
            {
                if (_placement != value)
                {
                    _placement = value;
                    if (_DoEllipsis)
                    {
                        PrepareForLayout();
                    }
                }
            }
        }

        /// <summary>
        /// 是否启用省略号，如果启用了，就会截断文字，显示省略号。当文本获取焦点时，暂时失效
        /// </summary>
        public bool IsEllipsisEnabled
        {
            get { return _externalEnabled; }
            set
            {
                _externalEnabled = value;
                PrepareForLayout();
                if (_DoEllipsis)
                {
                    TextBoxWithEllipsis_LayoutUpdated(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 修改控件提示， 如果为true，则当LongText过长时，工具提示将设置为LongText。
        /// 如果为false，工具提示将设置为null，除非用户将其设置为LongText以外的其他值。
        /// </summary>
        public bool UseLongTextForToolTip
        {
            get { return _useLongTextForToolTip; }
            set
            {
                if (_useLongTextForToolTip != value)
                {
                    _useLongTextForToolTip = value;
                    if (value)
                    {
                        //文本太长，修改提示为原始文本
                        if (ExtentWidth > ViewportWidth || Text != _longText)
                        {
                            ToolTip = _longText;
                        }
                    }
                    else
                    {
                        //不处理提示，置为默认值
                        if (_longText.Equals(ToolTip))
                        {
                            ToolTip = null;
                        }
                    }
                }
            }
        }

        public double FudgePix{get;set;}

        private bool _DoEllipsis { get { return IsEllipsisEnabled && _internalEnabled; } }

        public tbxWithEllipsisUtils()
        {
            //是否只读文本框显示插入符号
            IsReadOnlyCaretVisible = true;

            //初始化自定义属性
            IsEllipsisEnabled = true;
            UseLongTextForToolTip = true;
            FudgePix = 3.0;
            _placement = EllipsisPlacement.Right;//默认右边
            _internalEnabled = true;

            LayoutUpdated += new EventHandler(TextBoxWithEllipsis_LayoutUpdated);//改变布局
            SizeChanged += new SizeChangedEventHandler(TextBoxWithEllipsis_SizeChanged);//改变大小
        }

        /// <summary>
        /// 重写了OnTextChanged事件，以便在搜索适合的最长子字符串时在内部更改Text属性时避免引发TextChanged事件
        /// 如果在外部更改了文本，则在使用截断的版本（IsEllipsisEnabled）重写文本之前，将新文本复制到LongText中
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (_externalChange)
            {
                _longText = Text ?? "";
                if (UseLongTextForToolTip) ToolTip = _longText;
                PrepareForLayout();
                base.OnTextChanged(e);
            }
        }

        /// <summary>
        /// 获取焦点时隐藏省略号
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            _internalEnabled = false;
            SetText(_longText);
            base.OnGotKeyboardFocus(e);
        }

        /// <summary>
        /// 失去焦点时显示省略号
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            _internalEnabled = true;
            PrepareForLayout();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// 通过布局事件修改长文本，添加省略号
        /// </summary>
        private void PrepareForLayout()
        {
            _lastFitLen = 0;
            _lastLongLen = _longText.Length;
            _curLen = _longText.Length;

            //触发布局事件，处理省略号
            SetText(_longText);
        }

        /// <summary>
        /// 跳过TextChanged来修改文字
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            if (Text != text)
            {
                _externalChange = false;
                Text = text; // 触发布局事件
                _externalChange = true;
            }
        }

        /// <summary>
        /// 文本或者大小改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxWithEllipsis_LayoutUpdated(object sender, EventArgs e)
        {
            if (_DoEllipsis)
            {
                //这将执行二分查找以确定适合可见区域的最大longText子串。使用递归的方式，因为如果在此处设置文本属性，则会再次引发此事件。
                if (ViewportWidth + FudgePix < ExtentWidth)
                {
                    //长度太长
                    _lastLongLen = _curLen;
                }
                else
                {
                    //长度合适
                    _lastFitLen = _curLen;
                }
                //测试一个新的子字符串，其长度介于最后一个已知适合的长度和最后一个已知太长的长度之间。
                int newLen = (_lastFitLen + _lastLongLen) / 2;
                if (_curLen == newLen)
                {
                    if (UseLongTextForToolTip)
                    {
                        if (Text == _longText)
                        {
                            ToolTip = null;
                        }
                        else
                        {
                            ToolTip = _longText;
                        }
                    }
                }
                else
                {
                    _curLen = newLen;
                    //在不引发TextChanged事件的情况下设置文本属性。但是会触发LayoutUpdated事件。
                    CalcText();
                }
            }
            else if (UseLongTextForToolTip)
            {
                if (ViewportWidth < ExtentWidth)
                {
                    ToolTip = _longText;
                }
                else
                {
                    ToolTip = null;
                }
            }
        }

        /// <summary>
        /// 计算省略号的位置
        /// </summary>
        private void CalcText()
        {
            switch (_placement)
            {
                case EllipsisPlacement.Right:
                    SetText(_longText.Substring(0, _curLen) + "\u2026");
                    break;
                case EllipsisPlacement.Center:
                    int firstLen = _curLen / 2;
                    int secondLen = _curLen - firstLen;
                    SetText(_longText.Substring(0, firstLen) + "\u2026" + _longText.Substring(_longText.Length - secondLen));
                    break;
                case EllipsisPlacement.Left:
                    int start = _longText.Length - _curLen;
                    SetText("\u2026" + _longText.Substring(start));
                    break;
                default:
                    throw new Exception("Unexpected switch value: " + _placement.ToString());
            }

        }

        private void TextBoxWithEllipsis_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_DoEllipsis && e.NewSize.Width != e.PreviousSize.Width)
            {
                //重新计算文字长度，添加省略号
                PrepareForLayout();
            }
        }
    }
}
