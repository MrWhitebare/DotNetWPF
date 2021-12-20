using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RoutedEvents.Utils
{
    public class TreeItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 结点显示图片
        /// </summary>
        public BitmapImage Image { get; set; }
        /// <summary>
        /// 结点显示文本
        /// </summary>
        public string Name{ get;set;}

        /// <summary>
        /// 结点类型
        /// </summary>
        public string Type { get;set;}

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeItem Parent { get; set; }
    
        /// <summary>
        /// 子节点集合
        /// </summary>
        public ObservableCollection<TreeItem> Children { get; set; }

        private bool m_isAdd=false;

        /// <summary>
        /// 拖动到目标结点时增加到统计目录
        /// </summary>
        public bool IsAdd
        {
            get { return m_isAdd; }
            set
            {
                if(m_isAdd!= value)
                {
                    m_isAdd=value;
                    if (m_isAdd)
                        m_isAdd = false;
                    if(PropertyChanged!= null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsAdd"));
                }
            }
        }

        private bool m_isAddIn = false;

        /// <summary>
        /// 拖动到目标结点时增加到子目录标志
        /// </summary>
        public bool IsAddIn { 
            get { return m_isAddIn; }
            set
            {
                if(m_isAddIn!= value)
                {
                    m_isAddIn=value;
                    if(m_isAddIn)
                        m_isAddIn = false;
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsAddIn"));
                }
            }
        }
    }
}
