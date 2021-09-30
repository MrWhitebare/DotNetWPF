using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Commands.Utils
{
    class OperateAppConfig
    {
        /// <summary>
        /// 获取配置文件结点数据
        /// </summary>
        /// <param name="file">配置文件位置</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetappSettingsConfig(string file,string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            string appValue = config.AppSettings.Settings[key].Value.ToString();
            return appValue;
        }

        /// <summary>
        /// 更新配置文件结点
        /// </summary>
        /// <param name="file">配置文件位置</param>
        /// <param name="key">键</param>
        /// <param name="newValue">新值</param>
        public static void UpdateappSettingsConfig(string file, string key,string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            if (config.AppSettings.Settings[key].Value.ToString() != null)
            {
                config.AppSettings.Settings.Remove(key);
            }
            KeyValueConfigurationElement element = new KeyValueConfigurationElement(key, newValue);
            config.AppSettings.Settings.Add(element);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
