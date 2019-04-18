using Microsoft.JScript;
using Microsoft.Win32;
using mshtml;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Flash
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //WindowStartupLocation = WindowStartupLocation.CenterScreen;
            double screeHeight = SystemParameters.FullPrimaryScreenHeight;
            double screeWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = screeHeight*0.001;

            this.Left = (screeWidth - this.Width);

            String rootPath = Directory.GetCurrentDirectory();
            string parentPath = Directory.GetParent(rootPath).FullName;//上级目录
            string topPath = Directory.GetParent(parentPath).FullName;//上上级目录

            string path = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            rk2.SetValue("Flash", "\""+path+"\"");
            rk2.Close();
            rk.Close();
            browser.Navigate(topPath + @"\hamster.swf");


        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
