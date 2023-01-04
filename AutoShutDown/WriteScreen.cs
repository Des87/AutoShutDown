using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShutDown
{
    internal class WriteScreen
    {
            [DllImport("User32.dll")]
            public static extern IntPtr GetDC(IntPtr hwnd);
            [DllImport("User32.dll")]
            public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
            [DllImport("User32.dll")]
            static extern bool GetCursorPos(ref Point cur_pos);

            int timecount = 60;

        public bool Write(Point startPoz)
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);
            Font a = new Font("Arial", 100);
            bool istrue = false;
            Point cur_pos = new();
            System.Threading.Timer timer = new System.Threading.Timer(Callback, null, 0, 1 * 1000);
            while (!istrue)
            {
                g.DrawString(timecount.ToString(), new Font("Arial", 100), Brushes.Blue, 20, 20);
                g.DrawString(timecount.ToString(), new Font("Arial", 100), Brushes.Red, 20, 20);
                g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(20,20,200,150));
                if (timecount == 0)
                {
                    istrue = true;
                }

                GetCursorPos(ref cur_pos);
                if (startPoz != cur_pos)
                {
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(20, 20, 200, 150));
                    g.Dispose();
                    ReleaseDC(IntPtr.Zero, desktopPtr);
                    return false;
                }
            }

            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
            return true;
        }

        private void Callback(object? state)
        {
            timecount--;
        }
    }
}
