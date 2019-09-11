using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NSFW.Server
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            // Show
            //ShowWindow(handle, SW_SHOW);

            var timer = new Timer(5);

            var cont = 0;

            timer.Elapsed += (sender, eventArgs) =>
            {
                System.Diagnostics.Process.Start("http://google.com");
                cont++;
                
                if (cont <= 300) return;
                timer.Enabled = false;
                ShowWindow(handle, SW_SHOW);
                Console.WriteLine("Tick Tock Madafaka");

            };

            

            timer.Enabled = true;

            Console.Read();
        
        }
    }
}
