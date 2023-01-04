using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShutDown
{
    internal class Counter
    {
        public async void ShutDownProcess()
        {
            Point start_pos = new();
            GetCursorPos(ref start_pos);
            int counter = 0;
            int setter = 26 * 60;
            while (counter != setter)
            {
                Point cur_pos = new();
                GetCursorPos(ref cur_pos);
                Thread.Sleep(1000);
                if (start_pos == cur_pos)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                    start_pos = cur_pos;
                }

                if (counter + 2 == setter)
                {
                    WriteScreen w = new WriteScreen();
                    var istrue = w.Write(start_pos);
                }
            }
        }
        [DllImport("user32.dll")]

        static extern bool GetCursorPos(ref Point cur_pos);

    }

}
