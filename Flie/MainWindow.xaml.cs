using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flie
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("gdi32")]
        private static extern int GetPixel(int hdc, int nXPos, int nYPos);
        [DllImport("user32")]
        private static extern int GetWindowDC(int hwnd);
        [DllImport("user32")]
        private static extern int ReleaseDC(int hWnd, int hDC);
        public MainWindow()
        {
            InitializeComponent();
            //string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            //using (StreamWriter sw = new StreamWriter("names.txt"))
            //{
            //    foreach (string s in names)
            //    {
            //        sw.WriteLine(s);

            //    }
            //}

            // 从文件中读取并显示每行
            string line = "";
            using (StreamReader sr = new StreamReader("names.hex"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(null);
            int lDC = GetWindowDC(0);
            int intColor = GetPixel(lDC, (int)point.X, (int)point.Y);
            ReleaseDC(0, lDC);
            byte b = (byte)((intColor >> 0x10) & 0xffL);
            byte g = (byte)((intColor >> 8) & 0xffL);
            byte r = (byte)(intColor & 0xffL);
            Console.WriteLine("r={0} g={1} b={2}",r,g,b);
        }
    }
}
