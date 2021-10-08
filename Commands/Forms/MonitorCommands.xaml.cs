using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// MonitorCommands.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorCommands : Window
    {
        // 执行应用程序范围内的 Undo 操作的命令
        // 静态字段
        private static RoutedUICommand applicationUndo;

        public static RoutedUICommand ApplicationUndo
        {
            get { return applicationUndo; }
        }

        //静态构造函数用于初始化任何静态数据，或执行仅需执行一次的特定操作。
        //将在创建第一个实例或引用任何静态成员之前自动调用静态构造函数。
        static MonitorCommands()
        {
            applicationUndo = new RoutedUICommand("ApplicationUndo", "Application Undo", typeof(MonitorCommands));
        }

        public MonitorCommands()
        {
            InitializeComponent();
            // 保存之前组件属性状态
            this.AddHandler(CommandManager.PreviewExecutedEvent,
               new ExecutedRoutedEventHandler(CommandExecuted));
        }

        private void window_Unloaded(object sender, RoutedEventArgs e)
        {
            //组件卸载，移除事件
            this.RemoveHandler(CommandManager.PreviewExecutedEvent,
               new ExecutedRoutedEventHandler(CommandExecuted));
        }


        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // 忽略菜单按钮源
            if (e.Source is ICommandSource) return;

            //忽略应用程序的Undo
            if (e.Command == MonitorCommands.ApplicationUndo) return;

            // Could filter for commands you want to add to the stack
            // (for example, not selection events).

            TextBox txt = e.Source as TextBox;
            if (txt != null)
            {
                RoutedCommand cmd = (RoutedCommand)e.Command;

                CommandHistoryItem historyItem = new CommandHistoryItem(
                    cmd.Name, txt, "Text", txt.Text);

                ListBoxItem item = new ListBoxItem();
                item.Content = historyItem;
                lstHistory.Items.Add(historyItem);
            }
        }
        private void ApplicationUndoCommand_Executed(object sender, RoutedEventArgs e)
        {
            CommandHistoryItem historyItem = (CommandHistoryItem)lstHistory.Items[lstHistory.Items.Count - 1];
            if (historyItem.CanUndo) historyItem.Undo();
            lstHistory.Items.Remove(historyItem);
        }

        private void ApplicationUndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lstHistory == null || lstHistory.Items.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
    }

    public class CommandHistoryItem
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        public string CommandName
        {
            get;
            set;
        }

        /// <summary>
        /// 执行命令的元素
        /// </summary>
        public UIElement ElementActedOn
        {
            get;
            set;
        }
        /// <summary>
        /// 在目标元素中修改的属性
        /// </summary>
        public string PropertyActedOn
        {
            get;
            set;
        }
        /// <summary>
        /// 保存受影响元素之前的状态
        /// </summary>
        public object PreviousState
        {
            get;
            set;
        }

        public CommandHistoryItem(string commandName)
            : this(commandName, null, "", null)
        { }

        public CommandHistoryItem(string commandName, UIElement elementActedOn,
            string propertyActedOn, object previousState)
        {
            CommandName = commandName;
            ElementActedOn = elementActedOn;
            PropertyActedOn = propertyActedOn;
            PreviousState = previousState;
        }
        public bool CanUndo
        {
            get { return (ElementActedOn != null && PropertyActedOn != ""); }
        }

        public void Undo()
        {
            Type elementType = ElementActedOn.GetType();
            PropertyInfo property = elementType.GetProperty(PropertyActedOn);
            property.SetValue(ElementActedOn, PreviousState, null);
        }
    }
}
