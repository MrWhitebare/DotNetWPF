using System.Windows;

namespace Drawing.Utils
{
    public class JavascriptCallCSharp
    {
        public void Show(string Message)
        {
            MessageBox.Show(Message);
            System.Diagnostics.Process.Start(@"C:\Users\17669\Documents\MyWork\记录\C#学习\C#API.pdf");
        }
    }
}
