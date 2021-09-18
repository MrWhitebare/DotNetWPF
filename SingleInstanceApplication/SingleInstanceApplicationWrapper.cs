using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleInstanceApplication
{
    /// <summary>
    /// 单例程序接口容器
    /// </summary>
    class SingleInstanceApplicationWrapper:WindowsFormsApplicationBase
    {
        //WindowsFormsApplicationBase WPF 封装提供服务
        public SingleInstanceApplicationWrapper()
        {
            //启动单例应用程序
            this.IsSingleInstance = true;
        }

        private WpfApp app;
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            //重写OnStartup 并创建WPF应用
            app = new WpfApp();
            app.Run();
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            //该方法提供了访问命令行参数的功能
            //可调用`WPF`应用程序类中的方法显示新的窗口
            base.OnStartupNextInstance(eventArgs);
            if (eventArgs.CommandLine.Count > 0)
            {
                app.ShowDocument(eventArgs.CommandLine[0]);
            }
        }
    }
}
